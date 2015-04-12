using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Enumarators;
using X_Rebirth_Save_Game_Editor.Helper;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipData
    {
        #region Members
        XmlNode ShipNode = null;
        CatDatExtractor cde = null;

        private List<ShipAmmunitionItemData> ammunition = null;
        private List<NPCData> npcs = null;
        private Dictionary<int, ShipStorageData> ShipStorage = new Dictionary<int, ShipStorageData>();

        private string shipName = "";

        #region Skunk
        List<ShipWeaponCycleSlotData> WeaponCycleSlot = new List<ShipWeaponCycleSlotData>();
        public List<ShipSoftwareData> InstalledSoftware = new List<ShipSoftwareData>();
        public List<ShipShieldData> InstalledShields = new List<ShipShieldData>();
        public List<ShipEngineData> InstalledEngines = new List<ShipEngineData>();
        public List<ShipWeaponData> InstalledWeapons = new List<ShipWeaponData>();
        public ShipScannerData InstalledScanner = null;
        public ShipCockpitData ShipCockpit = null;
        #endregion
        #endregion

        #region Constructors
        public ShipData(XmlNode shipNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                ShipNode = shipNode;

                XmlNode childNode = null;
                //<shields> ???

                // Storages
                XmlNode storage = null;
                storage = shipNode.SelectSingleNode("//connection[@connection='connection_storage01']");
                if (storage != null)
                {
                    ShipStorage.Add(1, new ShipStorageData(storage, cde));
                }

                storage = null;
                storage = shipNode.SelectSingleNode("//connection[@connection='connection_storage02']");
                if (storage != null)
                {
                    ShipStorage.Add(2, new ShipStorageData(storage, cde));
                }

                storage = null;
                storage = shipNode.SelectSingleNode("//connection[@connection='connection_storage03']");
                if (storage != null)
                {
                    ShipStorage.Add(3, new ShipStorageData(storage, cde));
                }


                #region Skunk
                if (IsSkunk()) // Some prats should only be handled for skunk at the moment
                {

                    try
                    {
                        //<weaponcycle>
                        childNode = XMLFunctions.FindChild(ShipNode.FirstChild, "weaponcycle");

                        if (childNode != null)
                        {
                            childNode = childNode.FirstChild;

                            while (childNode != null)
                            {
                                try
                                {
                                    WeaponCycleSlot.Add(new ShipWeaponCycleSlotData(childNode, cde));
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error("Unable to add weaponcycle.", ex);
                                }
                                childNode = childNode.NextSibling;
                            }
                        }
                        else
                        {
                            throw new Exception("weaponcycle child node not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to parse weaponcycle.", ex);
                    }

                    try
                    {
                        //<connections>
                        childNode = XMLFunctions.FindChild(ShipNode.FirstChild, "connections");

                        if (childNode != null)
                        {
                            childNode = childNode.FirstChild;

                            while (childNode != null)
                            {
                                try
                                {
                                    if (childNode.Attributes["connection"].Value == "connection_software01"
                                        || childNode.Attributes["connection"].Value == "connection_software02"
                                        || childNode.Attributes["connection"].Value == "connection_software03"//Just in case
                                        || childNode.Attributes["connection"].Value == "connection_software04"//Just in case
                                        )
                                    {
                                        InstalledSoftware.Add(new ShipSoftwareData(childNode, cde));
                                    }
                                    else if (childNode.Attributes["connection"].Value == "scannerconnection")
                                    {
                                        InstalledScanner = new ShipScannerData(childNode, cde);
                                    }
                                    else if (childNode.Attributes["connection"].Value == "shields"
                                            || childNode.Attributes["connection"].Value == "shieldgenerators"
                                            )
                                    {// I need it!
                                        InstalledShields.Add(new ShipShieldData(childNode, cde));
                                    }
                                    else if (childNode.Attributes["connection"].Value == "engine_r"
                                            || childNode.Attributes["connection"].Value == "engine_l"
                                            )
                                    {// I need it!
                                        InstalledEngines.Add(new ShipEngineData(childNode, cde));
                                    }
                                    else if (childNode.Attributes["connection"].Value == "conn_primaryweapon_shotgun"
                                            || childNode.Attributes["connection"].Value == "conn_primaryweapon_impuls"
                                            || childNode.Attributes["connection"].Value == "conn_primaryweapon_beam"
                                            || childNode.Attributes["connection"].Value == "conn_primaryweapon_plasma"
                                            || childNode.Attributes["connection"].Value == "conn_primaryweapon_mg"
                                            )
                                    {// I need it!
                                        InstalledWeapons.Add(new ShipWeaponData(childNode, cde));
                                    }
                                    else if (childNode.Attributes["connection"].Value == "cockpit")
                                    {// I need it!
                                        ShipCockpit = new ShipCockpitData(childNode, cde);
                                    }
                                    else if (childNode.Attributes["connection"].Value == "connection_radar01")
                                    {// Do I need it?
                                    }
                                    else if (childNode.Attributes["connection"].Value == "connection_dock_s01")
                                    {// Do I need it?
                                    }
                                    else if (childNode.Attributes["connection"].Value == "tagweaponconnection01")
                                    {// Do I need it?
                                    }
                                    else if (childNode.Attributes["connection"].Value == "weaponconnection4")
                                    {// Do I need it?
                                    }
                                    else if (childNode.Attributes["connection"].Value == "weaponconnection3")
                                    {// Do I need it?
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error("Unable to add this ship conection", ex);
                                }

                                childNode = childNode.NextSibling;
                            }
                        }
                        else
                        {
                            throw new Exception("connections child node not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to parse connections.", ex);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse ship.", ex);
            }
        }
        #endregion

        #region Methods
        public string GetInstalledEngine()
        {
            try
            {
                if (InstalledEngines[0].Macro != InstalledEngines[1].Macro)
                {
                    InstalledEngines[0].Macro = InstalledEngines[1].Macro;
                    Logger.Warning("The installed engines are not the same! This is erronous. Made sure they are the same. Engine 1(" + InstalledEngines[0].Macro + "), Engine 2(" + InstalledEngines[1].Macro + ")");
                }

                return InstalledEngines[0].Macro;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to retrieve the engine data.", ex);
            }
        }

        public void SetInstalledEngine(string engineMacro)
        {
            try
            {
                InstalledEngines[0].Macro = engineMacro;
                InstalledEngines[1].Macro = engineMacro;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to set the engine data.", ex);
            }
        }

        public string GetInstalledWeapon(string weaponConnectionType)
        {
            try
            {
                if (string.IsNullOrEmpty(weaponConnectionType))
                {
                    weaponConnectionType = "";
                    throw new Exception("weaponConnectionType may not be null or empty.");
                }

                List<ShipWeaponData> temp = InstalledWeapons.Where(a => a.ConnectionName == weaponConnectionType).ToList();
                if (temp.Count == 1)
                {
                    return temp.First().Macro;
                }
                else if (temp.Count > 1)
                {
                    Logger.Warning("Error Multiple weapons of type Found!");
                    return "Error Multiple Found!";
                }
                else
                {
                    return "None";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to retrieve the weapon data of type" + weaponConnectionType, ex);
            }
        }

        public void SetInstalledWeapon(string weaponConnectionType, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(weaponConnectionType))
                {
                    weaponConnectionType = "null";
                    throw new Exception("weaponConnectionType may not be null or empty.");
                }

                if (string.IsNullOrEmpty(value))
                {
                    value = "null";
                    throw new Exception("value may not be null or empty.");
                }

                List<ShipWeaponData> temp = InstalledWeapons.Where(a => a.ConnectionName == weaponConnectionType).ToList();
                if (temp.Count == 1
                    && value != "None"
                    )
                {
                    temp.First().Macro = value;
                    WeaponCycleSlot.Where(a => a.WeaponSlotConnection == weaponConnectionType).First().WeaponMacro = value;
                }
                else if (temp.Count == 1
                    && value == "None"
                    )
                {
                    temp.First().Remove();
                    InstalledWeapons.Remove(temp.First());
                    WeaponCycleSlot.Where(a => a.WeaponSlotConnection == weaponConnectionType).First().RemoveWeaponSlot();
                    RearrangeWeaponSlotIndexes();
                }
                else if (temp.Count > 1)
                {
                    Logger.Warning("Error Multiple weapons of type Found!");
                }
                else
                {
                    InstalledWeapons.Add(new ShipWeaponData(value, weaponConnectionType, ShipNode, cde));
                    WeaponCycleSlot.Where(a => a.WeaponSlotConnection == weaponConnectionType).First().AddWeaponSlot(value, 1);
                    RearrangeWeaponSlotIndexes();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to set the weapon data of type" + weaponConnectionType, ex);
            }
        }

        public void RearrangeWeaponSlotIndexes()
        {
            int i = 1;
            // Reorder
            foreach (ShipWeaponCycleSlotData slot in WeaponCycleSlot.Where(a => a.WeaponSlotConnection.StartsWith("conn_primaryweapon")))
            {
                if (slot.WeaponSlotIndex > 0)
                {
                    slot.WeaponSlotIndex = i;
                    i++;
                }
            }
        }

        /// <summary>
        /// If the macro is unit_player_ship_macro then the ship is the skunk.
        /// </summary>
        /// <returns></returns>
        public bool IsSkunk()
        {
            if (ShipMacro.StartsWith("unit_player_ship_") && ShipMacro.EndsWith("macro")) return true;
            return false;
        }

        /// <summary>
        /// If the macro is units_size_xl_builder_ship_macro then the ship is the skunk.
        /// </summary>
        /// <returns></returns>
        public bool IsBuildingCV()
        {
            if (ShipMacro == "units_size_xl_builder_ship_macro") return true;
            return false;
        }

        /// <summary>
        /// If the owner matches returns true.
        /// </summary>
        /// <param name="owner">Provide the owner name. The default is player.</param>
        /// <returns></returns>
        public bool IsOwnedBy(string owner = "player")
        {
            if (ShipOwner == owner) return true;
            return false;
        }

        public void AddAmmunition(string macro, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(macro))
                {
                    throw new Exception("macro must contain a value");
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("value must contain a value");
                }

                try
                {
                    Convert.ToInt64(value);
                }
                catch (Exception ex)
                {
                    throw new Exception("value must contain a valid integer value", ex);
                }

                XmlNode childNode = XMLFunctions.FindChild(ShipNode.FirstChild, "ammunition");
                XmlNode newAmmoNode = null;

                if (childNode == null)
                {
                    XmlNode previousChildNode = XMLFunctions.FindChild(ShipNode.FirstChild, "shields");
                    childNode = ShipNode.OwnerDocument.CreateElement("ammunition");
                    childNode.AppendChild(ShipNode.OwnerDocument.CreateElement("available"));
                    ShipNode.FirstChild.InsertAfter(childNode, previousChildNode);
                }

                childNode = childNode.FirstChild;

                try
                {
                    newAmmoNode = childNode.OwnerDocument.CreateNode(XmlNodeType.Element, "item", "");
                    newAmmoNode.Attributes.Append(childNode.OwnerDocument.CreateAttribute("macro"));
                    newAmmoNode.Attributes.Append(childNode.OwnerDocument.CreateAttribute("amount"));
                    newAmmoNode.Attributes["macro"].Value = macro;
                    newAmmoNode.Attributes["amount"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create the new inventory node", ex);
                }

                try
                {
                    childNode.AppendChild(newAmmoNode);
                    Ammunition.Add(new ShipAmmunitionItemData(newAmmoNode, cde));
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

        public void RemoveAmmunition(string macro)
        {
            List<ShipAmmunitionItemData> tempList = null;
            try
            {
                tempList = Ammunition.Where(a => a.Ware == macro).ToList();

                if (tempList.Count > 1)
                {
                    throw new Exception("There is more than one ware entry of that type. That can't be right!");
                }
                else if (tempList.Count < 1)
                {
                    throw new Exception("There is no ware entry of that type.");
                }

                ShipAmmunitionItemData temp = tempList.First();
                temp.RemoveNode();
                Ammunition.Remove(temp);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to remove ware entry", ex);
            }
        }

        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            if (((searchData.OtherShips && !IsBuildingCV())
                    || (searchData.BuildingCVs && IsBuildingCV())
                    )
                && (searchData.Faction == "All"
                    || IsOwnedBy(searchData.Faction)
                    )
                && !IsSkunk()
                )
            {
                nodes.Add(ShipId, ShipName);
                nodes[ShipId].Tag = this;
            }
        }
        #endregion

        #region Properties
        #region Skunk
        public string InstalledShield1
        {
            get
            {
                try
                {
                    return InstalledShields[0].Macro;
                }
                catch (Exception ex)
                {
                    throw new Exception("Shield 1 does not exist.", ex);
                } 
            }
            set
            {
                try
                {
                    InstalledShields[0].Macro = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Shield 1 does not exist.", ex);
                } 
            }
        }

        public string InstalledShield2
        {
            get
            {
                try
                {
                    return InstalledShields[1].Macro;
                }
                catch (Exception ex)
                {
                    throw new Exception("Shield 2 does not exist.", ex);
                } 
            }
            set
            {
                try
                {
                    InstalledShields[1].Macro = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Shield 1 does not exist.", ex);
                } 
            }
        }

        public string InstalledSoftware1
        {
            get
            {
                try
                {
                    List<ShipSoftwareData> tempSoft = InstalledSoftware.Where(a => a.SoftwareSlot == 1).ToList();

                    if (tempSoft.Count < 1
                        || tempSoft.First() == null
                        )
                    {
                        return "None";
                    }
                    else
                    {
                        return tempSoft.First().Macro;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Software 1 does not exist.", ex);
                } 
            }
            set
            {
                try
                {
                    List<ShipSoftwareData> tempSoft = InstalledSoftware.Where(a => a.SoftwareSlot == 1).ToList();

                    if ((tempSoft.Count < 1
                        || tempSoft.First() == null
                        ) && value != "None")
                    {
                        if (tempSoft.Count < 1)
                        {
                            InstalledSoftware.Add(new ShipSoftwareData(value, "connection_software01", ShipNode, cde));
                        }
                    }
                    else if (tempSoft.Count > 0
                            &&  tempSoft.First() != null
                            &&  value == "None"
                            )
                    {
                        tempSoft.First().Remove();
                        InstalledSoftware.Remove(tempSoft.First());
                    }
                    else if (value != "None")
                    {
                        tempSoft.First().Macro = value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Software 1 does not exist.", ex);
                } 
            }
        }

        public string InstalledSoftware2
        {
            get
            {
                try
                {
                    List<ShipSoftwareData> tempSoft = InstalledSoftware.Where(a => a.SoftwareSlot == 2).ToList();

                    if (tempSoft.Count < 1
                        || tempSoft.First() == null
                        )
                    {
                        return "None";
                    }
                    else
                    {
                        return tempSoft.First().Macro;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Software 2 does not exist.", ex);
                } 
            }
            set
            {
                try
                {
                    List<ShipSoftwareData> tempSoft = InstalledSoftware.Where(a => a.SoftwareSlot == 2).ToList();

                    if ((tempSoft.Count < 1
                        || tempSoft.First() == null
                        ) && value != "None")
                    {
                        if (tempSoft.Count < 1)
                        {
                            InstalledSoftware.Add(new ShipSoftwareData(value, "connection_software02", ShipNode, cde));
                        }
                    }
                    else if (tempSoft.Count > 0
                            && tempSoft.First() != null
                            && value == "None"
                            )
                    {
                        tempSoft.First().Remove();
                        InstalledSoftware.Remove(tempSoft.First());
                    }
                    else if (value != "None")
                    {
                        tempSoft.First().Macro = value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Software 2 does not exist.", ex);
                } 
            }
        }
        #endregion
        public List<ShipAmmunitionItemData> Ammunition
        {
            get
            {
                // Initialize
                if (ammunition == null)
                {
                    ammunition = new List<ShipAmmunitionItemData>();

                    try
                    {
                        XmlNode childNode = null;
                        childNode = XMLFunctions.FindChild(ShipNode.FirstChild, "ammunition");
                        if (childNode != null)
                        {
                            childNode = XMLFunctions.FindChild(childNode, "available").FirstChild;

                            while (childNode != null)
                            {
                                try
                                {
                                    Ammunition.Add(new ShipAmmunitionItemData(childNode, cde));
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error("Unable to add ammunition.", ex);
                                }
                                childNode = childNode.NextSibling;
                            }
                        }
                        else
                        {
                            throw new Exception("ammunition child node not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning("Unable to parse ammunition.", ex);
                    }
                }
                return ammunition;
            }
        }

        public List<NPCData> NPCs
        {
            get
            {
                if(npcs == null)
                {
                    npcs = new List<NPCData>();

                    // Get All NPCs on ship
                    foreach (XmlNode node in ShipNode.SelectNodes("//component[@class='npc']"))
                    {
                        npcs.Add(new NPCData(node.ParentNode, cde));
                    }
                }
                return npcs;
            }
        }
        /// <summary>
        /// Get the connection name
        /// </summary>
        public string ConnectionName
        {
            get
            {
                try
                {
                    return ShipNode.Attributes["connection"].Value;
                }
                catch
                {
                    return "";
                } 
            }
        }

        /// <summary>
        /// Get the ship class
        /// </summary>
        public string ShipClass
        {
            get
            {
                try
                {
                    return ShipNode.FirstChild.Attributes["class"].Value;
                }
                catch
                {
                    return "";
                } 
            }
        }

        public string ShipKnownTo
        {
            get
            {
                try
                {
                    return ShipNode.FirstChild.Attributes["knownto"].Value;
                }
                catch
                {
                    return "";
                }
            }
        }

        public string ShipConnection
        {
            get
            {
                try
                {
                    return ShipNode.FirstChild.Attributes["connection"].Value;
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Get or set the ships owner
        /// </summary>
        public string ShipOwner
        {
            get
            {
                try
                {
                    if (ShipNode.FirstChild.Attributes["owner"] == null)
                    {
                        return "None";
                    }
                    return ShipNode.FirstChild.Attributes["owner"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve ship owner this is a fatal error.", ex);
                } 
            }
            set
            {
                try
                {
                    ShipNode.FirstChild.Attributes["owner"].Value = value;

                    // also set owner for NPCs
                    foreach (NPCData npc in NPCs)
                    {
                        npc.Owner = value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to set ship owner this is a fatal error.", ex);
                } 
            }
        }

        public string ShipMacro
        {
            get
            {
                try
                {
                    return ShipNode.FirstChild.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve ship macro this is a fatal error.", ex);
                } 
            }
        }

        public string ShipId
        {
            get
            {
                try
                {
                    return ShipNode.FirstChild.Attributes["id"].Value;
                }
                catch
                {
                    return "";
                }
            }
        }

        public string ShipName
        {
            get
            {
                if (ShipNode.FirstChild.Attributes["name"] != null)
                {
                    return ShipNode.FirstChild.Attributes["name"].Value;
                }

                if (shipName == "")
                {
                    try
                    {
                        shipName = cde.GetDefaultShipName(ShipClass, ShipMacro);
                    }
                    catch
                    {
                        shipName = "";
                    }
                }
                return shipName;
            }
            set
            {
                XMLFunctions.SetSafeAttribute(ShipNode.FirstChild, "name", value);
            }
        }
        #endregion        
    }
}
