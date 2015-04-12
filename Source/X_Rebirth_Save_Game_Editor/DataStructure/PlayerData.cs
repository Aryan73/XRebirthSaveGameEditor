using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class PlayerData
    {
        #region Members
        XmlNode PlayerNode = null;
        XmlNodeList PlayerAccounts = null;
        XmlNode MoneyStatNode = null;
        public List<ShipInventoryItemData> PlayerInventory = new List<ShipInventoryItemData>();
        Dictionary<string, List<string>> PlayerKnown = new Dictionary<string, List<string>>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public PlayerData(XmlNode playerNode, CatDatExtractor cde)
        {
            PlayerNode = playerNode;
            XmlNode childNode = null;

            this.cde = cde;

            try
            {
                childNode = XMLFunctions.FindChild(PlayerNode.FirstChild, "inventory").FirstChild;

                while (childNode != null)
                {
                    try
                    {
                        PlayerInventory.Add(new ShipInventoryItemData(childNode, cde));
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to add player inventory item.", ex);
                    }
                    childNode = childNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to parse inventory", ex);
            }

            try
            {
                childNode = XMLFunctions.FindChild(PlayerNode.FirstChild, "known").FirstChild;

                while (childNode != null)
                {
                    try
                    {
                        List<string> ids = new List<string>();
                        XmlNode childSubNode = childNode.FirstChild;
                        XmlAttribute att = childNode.Attributes["type"];
                        if (att == null)
                        {
                            Logger.Warning("The entry in the known list does not have a type.");
                        }
                        else
                        {
                            while (childSubNode != null)
                            {
                                try
                                {
                                    ids.Add(childSubNode.Attributes["id"].Value);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error("Unable to create known list item", ex);
                                }
                                childSubNode = childSubNode.NextSibling;
                            }
                            PlayerKnown.Add(childNode.Attributes["type"].Value, ids);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to create known list", ex);
                    }
                    childNode = childNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse known. This is a fatal error.", ex);
            }
        }
        #endregion

        #region Methods
        public List<string> GetKnownTypesCategories()
        {
            return PlayerKnown.Keys.ToList(); ;
        }

        public void AddKnownTypeCategory(string category)
        {
            XmlNode newNode = PlayerNode.OwnerDocument.CreateNode(XmlNodeType.Element, "entries", "");
            XmlAttribute att = PlayerNode.OwnerDocument.CreateAttribute("type");
            att.Value = category;
            newNode.Attributes.Append(att);
            XMLFunctions.FindChild(PlayerNode.FirstChild, "known").AppendChild(newNode);
            PlayerKnown.Add(category, new List<string>());
        }

        public void AddKnownTypesToCategory(string category, List<string> types)
        {
            XmlNode categoryNode = null;
            foreach (XmlNode node in XMLFunctions.FindChild(PlayerNode.FirstChild, "known").ChildNodes)
            {
                if (node.Attributes["type"].Value == category)
                {
                    categoryNode = node;
                    break;
                }
            }

            if (categoryNode == null)
            { 
                Logger.Error("Cannot find category " + category + " to add types.");
                return;
            }

            foreach (string type in types)
            {
                XmlNode newNode = PlayerNode.OwnerDocument.CreateNode(XmlNodeType.Element, "entry", ""); 
                XmlAttribute att = PlayerNode.OwnerDocument.CreateAttribute("id");
                att.Value = type;
                newNode.Attributes.Append(att);
                categoryNode.AppendChild(newNode);
                PlayerKnown[category].Add(type);
            }
        }

        public List<string> GetKnownTypes(string category, string contains = "")
        {
            try
            {
                if (string.IsNullOrEmpty(category))
                {
                    throw new Exception("The category string is empty. That's no good!");
                }

                if (!PlayerKnown.Keys.Contains(category))
                {
                    throw new Exception("Known category " + category + " does not exist. What's up?");
                }

                if (string.IsNullOrEmpty(contains))
                {
                    return PlayerKnown[category];
                }
                else
                {
                    return PlayerKnown[category].Where(a => a.Contains(contains)).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve known types in category.", ex);
                return new List<string>();
            }
        }

        public void AddToPlayerInventory(string ware, string amount)
        {
            try
            {
                if (string.IsNullOrEmpty(ware))
                {
                    throw new Exception("ware must contain a value");
                }

                if (string.IsNullOrEmpty(amount))
                {
                    throw new Exception("amount must contain a value");
                }

                try
                {
                    Convert.ToInt64(amount);
                }
                catch (Exception ex)
                {
                    throw new Exception("amount must contain a valid integer value", ex);
                }

                XmlNode childNode = XMLFunctions.FindChild(PlayerNode.FirstChild, "inventory");
                XmlNode newInventoryNode = null;

                if (childNode == null)
                {
                    XmlNode previousChildNode = XMLFunctions.FindChild(PlayerNode.FirstChild, "account");
                    childNode = PlayerNode.OwnerDocument.CreateElement("inventory");
                    PlayerNode.FirstChild.InsertAfter(childNode, previousChildNode);
                    //throw new Exception("Unable to locate inventory node");
                }

                try
                {
                    newInventoryNode = childNode.OwnerDocument.CreateNode(XmlNodeType.Element, "ware", "");
                    newInventoryNode.Attributes.Append(childNode.OwnerDocument.CreateAttribute("ware"));
                    newInventoryNode.Attributes.Append(childNode.OwnerDocument.CreateAttribute("amount"));
                    newInventoryNode.Attributes["ware"].Value = ware;
                    newInventoryNode.Attributes["amount"].Value = amount;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create the new inventory node", ex);
                }

                try
                {
                    childNode.AppendChild(newInventoryNode);
                    PlayerInventory.Add(new ShipInventoryItemData(newInventoryNode, cde));
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to add the new inventory node", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add new player inventory item", ex);
            }
        }

        public void RemoveFromPlayerInventory(string ware)
        {
            List<ShipInventoryItemData> tempList = null;
            try
            {
                tempList = PlayerInventory.Where(a => a.Ware == ware).ToList();

                if (tempList.Count > 1)
                {
                    throw new Exception("There is more than one ware entry of that type. That can't be right!");
                }
                else if (tempList.Count < 1)
                {
                    throw new Exception("There is no ware entry of that type.");
                }

                ShipInventoryItemData temp = tempList.First();
                temp.RemoveNode();
                PlayerInventory.Remove(temp);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to remove ware entry", ex);
            }
        }
        #endregion

        #region Properties
        public string AccountAmount
        {
            // Factions -> Player -> Account
            // connection_npc_betty -> Computer -> Account
            // character_argon_yisha_macro -> Account
            // <stat id="money_player" value="100000" />
            // id="[0x45]"
            //For now all locations here
            get
            {
                try
                {
                    if (PlayerAccounts == null)
                    {
                        // Get players accounts
                        PlayerAccounts = PlayerNode.OwnerDocument.SelectNodes("//account[@id='" + XMLFunctions.FindChild(PlayerNode.FirstChild, "account").Attributes["id"].Value + "']");
                    }
                    if (MoneyStatNode == null)
                    {
                        MoneyStatNode = PlayerNode.OwnerDocument.SelectSingleNode("//stat[@id='money_player']");
                    }
                    return XMLFunctions.FindChild(PlayerNode.FirstChild, "account").Attributes["amount"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve the account amount for the cockpit", ex);
                }
            }
            set
            {
                try
                {
                    foreach (XmlNode account in PlayerAccounts)
                    {
                        account.Attributes["amount"].Value = value;
                    }
                    MoneyStatNode.Attributes["value"].Value = value;
                    XMLFunctions.FindChild(PlayerNode.FirstChild, "account").Attributes["amount"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to set the account amount for the cockpit", ex);
                }
            }
        }
        #endregion
    }
}
