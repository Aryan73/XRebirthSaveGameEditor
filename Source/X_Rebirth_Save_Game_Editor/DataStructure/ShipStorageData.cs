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
    class ShipStorageData
    {
        #region Members
        XmlNode ShipStorageNode = null;
        CatDatExtractor cde = null;
        List<ShipStorageItemData> ShipStorageItems = null;
        #endregion

        #region Constructors
        public ShipStorageData(XmlNode shipStorageNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                ShipStorageNode = shipStorageNode;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse ship storage.", ex);
            }
        }
        #endregion

        #region Methods
        public void addItem(string ware, Int64 amount)
        {
            try
            {
                if (string.IsNullOrEmpty(ware))  { throw new Exception("ware must contain a value");  }
                if (amount <= 0) { throw new Exception("amount must be greather than 0"); }

                XmlNode summarydNode = ShipStorageNode.SelectSingleNode(".//summary");
                XmlNode newItemNode = null;

                try
                {
                    newItemNode = summarydNode.OwnerDocument.CreateNode(XmlNodeType.Element, "ware", "");
                    newItemNode.Attributes.Append(summarydNode.OwnerDocument.CreateAttribute("ware"));
                    newItemNode.Attributes["ware"].Value = ware;
                    if (amount > 1)
                    {
                        newItemNode.Attributes.Append(summarydNode.OwnerDocument.CreateAttribute("amount"));
                        newItemNode.Attributes["amount"].Value = amount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create the new item node", ex);
                }

                try
                {
                    summarydNode.AppendChild(newItemNode);
                    ShipStorageItems.Add(new ShipStorageItemData(newItemNode, cde));
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to list the new item", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to add new item in storage", ex);
            }
        }
        #endregion

        #region Properties
        public string Connection
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode, "connection");
            }
        }

        public string Macro
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode, "macro");
            }
        }

        public string ComponentMacro
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode.FirstChild, "macro");
            }
        }

        public string Class
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode.FirstChild, "class");
            }
        }

        public List<ShipStorageItemData> Items
        {
            get
            {
                if (ShipStorageItems == null)
                {
                    try
                    {
                        ShipStorageItems = new List<ShipStorageItemData>();
                        foreach (XmlNode node in ShipStorageNode.SelectNodes(".//ware"))
                        {
                            ShipStorageItems.Add(new ShipStorageItemData(node, cde));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to get cargo", ex);
                    }
                }
                return ShipStorageItems;
            }
        }

        public XmlNode shipStorageNode
        {
            get
            {
                return ShipStorageNode;
            }
        }
        #endregion
    }
}
