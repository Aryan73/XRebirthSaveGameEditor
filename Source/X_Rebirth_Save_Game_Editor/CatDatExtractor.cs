using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using X_Rebirth_Save_Game_Editor.Logging;
using X_Rebirth_Save_Game_Editor.DataStructure.FIleData;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;
using System.ComponentModel;
using X_Rebirth_Save_Game_Editor.DataStructure;

namespace X_Rebirth_Save_Game_Editor
{
    public class CatDatExtractor
    {
        #region Members
        public string BasePath = null;
        public List<string> CatFiles = new List<string>();
        List<string> DatFiles = new List<string>();
        DirectoryObject Structure = null;
        Dictionary<string, Dictionary<string, string>> AllTypes = new Dictionary<string, Dictionary<string, string>>();
        Object AllTypesLock = new Object();
        Dictionary<string, string> ShipNamesCache = new Dictionary<string, string>();
        Dictionary<string, List<string>> BasketsCache = null;
        List<TypeObject> AllTypesNew = null;
        #endregion

        #region Constructors
        public CatDatExtractor(string fullPath)
        {
            string lastDir = null;
            List<string> catFilesTemp = new List<string>();
            try
            {
                BasePath = fullPath.Substring(0, fullPath.LastIndexOf("\\"));
                lastDir = BasePath.Substring(BasePath.LastIndexOf("\\") + 1);
                BasePath = BasePath + "\\";
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to determine X-Rebirth base path.", ex);
            }

            try
            {
                catFilesTemp = Directory.GetFiles(BasePath, "*.cat").ToList();
                DatFiles = Directory.GetFiles(BasePath, "*.dat").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get cat and dat files.", ex);
            }

            try
            {
                foreach (string cat in catFilesTemp)
                {
                    string catName = cat.Substring(cat.LastIndexOf("\\") + 1);
                    CatFiles.Add(catName);
                    System.IO.StreamReader file = new System.IO.StreamReader(cat);
                    string b = file.ReadLine();
                    uint start = 0;
                    while (b != null)
                    {
                        try
                        {
                            int i = b.LastIndexOf('.');
                            string a = b.Substring(0, i);
                            string[] c = b.Substring(i).Split(' ');
                            int size = Convert.ToInt32(c[1]);
                            if (Structure == null)
                            {
                                Structure = new DirectoryObject(null, BasePath, catName, a + c[0], start, size, Convert.ToInt64(c[2]), c[3], 0);
                            }
                            else
                            {
                                Structure.AddPath(catName, a + c[0], start, size, Convert.ToInt64(c[2]), c[3], 0);
                            }
                            b = file.ReadLine();
                            start += (uint)size;
                        }
                        catch (Exception ex)
                        {
                            if (b == null)
                            {
                                b = "";
                            }
                            Logger.Error("Error occurred while parsing line in cat file " + cat + " line: " + b, ex);
                        }
                    }
                }

                // Used to fill cache
                GetAllTypesCategories();

                // Async cache categories
                BackgroundWorker bw = new BackgroundWorker();

                // this allows our worker to report progress during work
                bw.WorkerReportsProgress = true;

                bw.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    GetAllTypesInCategory("wares");
                });

                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to parse cat files.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes)
        {
            nodes.Add("X-Rebirth");
            Structure.GetTreeView(nodes[0].Nodes);
            nodes[0].Expand();
        }

        public List<FileObject> GetFileList(List<string> node, string catFilter, string endsWith, string contains)
        {
            node.Remove("X-Rebirth");
            return Structure.GetFileList(node, -1, catFilter).Where(a => (string.IsNullOrEmpty(endsWith) || a.Path.EndsWith(endsWith)) && (string.IsNullOrEmpty(contains) || a.Path.Contains(contains))).ToList();
        }

        public List<string> GetAllTypesCategories()
        {
            if (AllTypes.Count <= 0)
            {
                XmlDocument commonxsd = new XmlDocument();
                commonxsd.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "common.xsd").GetFileAsString(BasePath));
                XmlNamespaceManager manager = new XmlNamespaceManager(commonxsd.NameTable);
                manager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
                XmlNode node = commonxsd.SelectSingleNode("//xs:simpleType[@name='infolibrarytypelookup']", manager);
                XmlNode child = node.FirstChild.FirstChild;
                while (child != null)
                {
                    AllTypes.Add(child.Attributes["value"].Value, new Dictionary<string, string>());
                    child = child.NextSibling;
                }
            }
            return AllTypes.Keys.ToList();
        }

        public Dictionary<string, string> GetAllTypesInCategory(string category)
        {
            try
            {
                lock (AllTypesLock)
                {
                    if (AllTypesNew == null)
                    {
                        AllTypesNew = new List<TypeObject>();

                        XmlDocument waresxml = new XmlDocument();
                        waresxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "wares.xml").GetFileAsString(BasePath));
                        XmlNodeList nodes = XMLFunctions.FindChild(waresxml, "wares").SelectNodes("ware");

                        foreach (XmlNode node in nodes)
                        {
                            try
                            {
                                AllTypesNew.Add(new TypeObject(node, this));

                                // Initialize
                            }
                            catch (Exception ex)
                            {
                                Logger.Warning("Unable to add ware of type " + category + " to the alltypes list.", ex);
                            }
                        }

                        XmlDocument shipsxml = new XmlDocument();
                        XmlDocument shipgroupsxml = new XmlDocument();
                        shipsxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "ships.xml").GetFileAsString(BasePath));
                        shipgroupsxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "shipgroups.xml").GetFileAsString(BasePath));

                        foreach (XmlNode node in nodes)
                        {
                            try
                            {
                                AllTypesNew.Add(new TypeObject(node, shipgroupsxml, this));
                            }
                            catch (Exception ex)
                            {
                                Logger.Warning("Unable to add ship of type " + category + " to the alltypes list.", ex);
                            }
                        }
                    }

                    if (AllTypes[category] == null)
                    {
                        return new Dictionary<string, string>();
                    }
                    else if (AllTypes[category].Count <= 0)
                    {
                        if  (   category == "inventory_wares"
                            ||  category == "wares"
                            ||  category == "weapontypes_primary"
                            ||  category == "weapontypes_secondary"
                            ||  category == "marines"
                            ||  category == "enginetypes"
                            ||  category == "scannertypes"
                            ||  category == "shieldtypes"
                            ||  category == "shiptypes_xs" // also a part to be found in wares and in shipgroups(as units_size_xs_ macros)
                            )
                        {
                            XmlDocument waresxml = new XmlDocument();
                            waresxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "wares.xml").GetFileAsString(BasePath));
                            XmlNodeList nodes = XMLFunctions.FindChild(waresxml, "wares").SelectNodes("ware");

                            foreach (XmlNode node in nodes)
                            {
                                try
                                {
                                    string val = node.Attributes["name"].Value;
                                    if (node.Attributes["transport"].Value == "inventory")
                                    {
                                        AllTypes["inventory_wares"].Add(node.Attributes["id"].Value, val);

                                        if (node.Attributes["id"].Value.StartsWith("spe_ammo_"))
                                        {
                                            AllTypes["weapontypes_secondary"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                        else if (node.Attributes["id"].Value.StartsWith("spe_unit_marine_"))
                                        {
                                            AllTypes["marines"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                        else if (node.Attributes["id"].Value.StartsWith("spe_drone_"))
                                        {
                                            AllTypes["shiptypes_xs"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                    }
                                    else if (node.Attributes["transport"].Value == "container"
                                        || node.Attributes["transport"].Value == "bulk"
                                        || node.Attributes["transport"].Value == "liquid"
                                        || node.Attributes["transport"].Value == "energy"
                                        )
                                    {
                                        AllTypes["wares"].Add(node.Attributes["id"].Value, val);
                                    }
                                    else if (node.Attributes["transport"].Value == "equipment")
                                    {
                                        if (node.Attributes["id"].Value.StartsWith("upg_pla_engine_"))
                                        {
                                            AllTypes["enginetypes"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                        else if (node.Attributes["id"].Value.StartsWith("upg_pla_scanner_")
                                            || node.Attributes["id"].Value.StartsWith("upg_pla_software_")
                                            )
                                        {
                                            AllTypes["scannertypes"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                        else if (node.Attributes["id"].Value.StartsWith("upg_pla_shield_"))
                                        {
                                            AllTypes["shieldgentypes"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                        else if (node.Attributes["id"].Value.StartsWith("upg_pla_weapon_"))
                                        {
                                            AllTypes["weapontypes_primary"].Add(XMLFunctions.FindChild(node, "component").Attributes["ref"].Value, val);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning("Unable to add ware of type " + category + " to the alltypes list.", ex);
                                }
                            }
                        }

                        if (category.StartsWith("shiptypes_"))
                        {
                            string[] cat = category.Split('_');
                            XmlDocument shipsxml = new XmlDocument();
                            XmlDocument shipgroupsxml = new XmlDocument();
                            shipsxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "ships.xml").GetFileAsString(BasePath));
                            shipgroupsxml.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "shipgroups.xml").GetFileAsString(BasePath));
                            XmlNodeList nodes = shipsxml.SelectNodes("//category[@size='ship_" + cat[1] + "']");

                            foreach (XmlNode node in nodes)
                            {
                                try
                                {
                                    string macro = null;
                                    XmlAttribute att1 = node.ParentNode.Attributes["macro"];
                                    if (att1 != null)
                                    {
                                        macro = node.ParentNode.Attributes["macro"].Value;
                                    }

                                    if (!string.IsNullOrEmpty(macro))
                                    {
                                        if (AllTypes[category].ContainsKey(att1.Value))
                                        {
                                            AllTypes[category][att1.Value] += " & " + node.ParentNode.Attributes["id"].Value;
                                        }
                                        else
                                        {
                                            AllTypes[category].Add(att1.Value, node.ParentNode.Attributes["id"].Value);
                                        }
                                    }
                                    else
                                    {
                                        att1 = node.ParentNode.Attributes["group"];
                                        XmlNode groupChildNode = shipgroupsxml.SelectSingleNode("//group[@name='" + att1.Value + "']").FirstChild;

                                        while (groupChildNode != null)
                                        {
                                            att1 = groupChildNode.Attributes["macro"];

                                            if (AllTypes[category].ContainsKey(att1.Value))
                                            {
                                                AllTypes[category][att1.Value] += " & " + node.ParentNode.Attributes["id"].Value;
                                            }
                                            else
                                            {
                                                AllTypes[category].Add(att1.Value, node.ParentNode.Attributes["id"].Value);
                                            }

                                            groupChildNode = groupChildNode.NextSibling;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warning("Unable to add ship of type " + category + " to the alltypes list.", ex);
                                }
                            }
                        }
                        GetTranslationCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve categories", ex);
            }

            return AllTypes[category];
        }

        public void GetTranslationCategory(string language = "44")
        {
            try
            {
                XmlDocument t = new XmlDocument();
                t.LoadXml(Structure.GetFile(new List<string>() { "t" }, "0001-L0" + language + ".xml").GetFileAsString(BasePath));
                XmlNode pageNode = null;
                XmlNode tNode = null;
                List<KeyValuePair<string, string>> l = null;

                foreach (KeyValuePair<string, Dictionary<string, string>> cat in AllTypes)
                {
                    try
                    {
                        pageNode = null;
                        tNode = null;
                        l = null;
                        l = cat.Value.Where(a => a.Value.StartsWith("{")).ToList();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to create list", ex);
                    }
                    foreach (KeyValuePair<string, string> pair in l)
                    {
                        try
                        {
                            // For case with two groups of name : "{20101,703} {20106,101}" it doesn't work
                            // A solution, replace "}{" by "," and count the size of iden to see how many place
                            string[] iden = pair.Value.Substring(1, pair.Value.Length - 2).Replace(" ", "").Split(',');

                            pageNode = t.SelectSingleNode("//page [@id='" + iden[0] + "']");
                            if (pageNode == null)
                            {
                                Logger.Warning("Unable to locate page node " + iden[0]);
                            }

                            tNode = pageNode.SelectSingleNode("t[@id='" + iden[1] + "']");

                            if (tNode == null)
                            {
                                Logger.Warning("Unable to locate t node "+ iden[1]+" in page id="+ iden[0]);
                            }

                            if (tNode.FirstChild == null)
                            {
                                Logger.Warning("Unable to locate first child of t node");
                            }

                            if (tNode.FirstChild.Value.StartsWith("{"))
                            {
                                AllTypes[cat.Key][pair.Key] = GetTranslation(tNode.FirstChild.Value.Substring(0, tNode.FirstChild.Value.IndexOf("}") + 1), language);
                            }

                            AllTypes[cat.Key][pair.Key] = tNode.FirstChild.Value;
                        }
                        catch (Exception ex)
                        {
                            Logger.Warning("Unable to parse " + pair.Value, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to translate categoeries", ex);
            }
        }

        public string GetTranslation(string identifier, string language = "44")
        {
            try
            {
                XmlDocument t = new XmlDocument();
                t.LoadXml(Structure.GetFile(new List<string>() { "t" }, "0001-L0" + language + ".xml").GetFileAsString(BasePath));
                string[] iden = identifier.Substring(1, identifier.Length - 2).Replace(" ", "").Split(',');
                XmlNode pageNode = t.SelectSingleNode("//page[@id='" + iden[0] + "']");
                if (pageNode == null)
                {
                    throw new Exception("Unable to locate page node");
                }
                XmlNode tNode = pageNode.SelectSingleNode("t[@id='" + iden[1] + "']");
                if (tNode == null)
                {
                    throw new Exception("Unable to locate t node");
                }

                if (tNode.FirstChild == null)
                {
                    throw new Exception("Unable to locate first child of t node");
                }

                if (tNode.FirstChild.Value.StartsWith("{"))
                {
                    return GetTranslation(tNode.FirstChild.Value.Substring(0, tNode.FirstChild.Value.IndexOf("}") + 1) , language);
                }

                return tNode.FirstChild.Value;
            }
            catch (Exception ex)
            {
                Logger.Warning("Translation failed for " + identifier + " in 0001-L0" + language + ".xml", ex);
                return "Translation failed!";
            }
        }

        public List<string> GetPlayerWeaponConnectionList()
        {
            XmlDocument t = new XmlDocument();
            t.LoadXml(Structure.GetFile(new List<string>() { "assets", "units", "player", "macros" }, "unit_player_ship_macro.xml").GetFileAsString(BasePath));
            XmlNode weaponSlotNodes = XMLFunctions.FindChild(XMLFunctions.FindChild(XMLFunctions.FindChild(t, "macros").FirstChild, "properties"), "weapons");
            List<string> retList = new List<string>();

            foreach (XmlNode weaponSlotNode in weaponSlotNodes)
            {
                string refValue = weaponSlotNode.Attributes["ref"].Value;
                if (weaponSlotNode.Attributes["ref"].Value.StartsWith("conn_primaryweapon"))
                {
                    retList.Add(refValue);
                }
            }
            return retList;
        }

        public XmlNode GetPlayerConnectionOffset(string connection)
        {
            XmlDocument t = new XmlDocument();
            t.LoadXml(Structure.GetFile(new List<string>() { "assets", "units", "player" }, "unit_player_ship.xml").GetFileAsString(BasePath));

            return t.SelectSingleNode("//connection[@name='" + connection + "']").FirstChild; ;
        }

        public List<string> GetAllFactions()
        {
            XmlDocument t = new XmlDocument();
            t.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "factions.xml").GetFileAsString(BasePath));
            List<string> retList = new List<string>();
            
            foreach (XmlNode node in XMLFunctions.FindChild(t, "factions").ChildNodes)
            {
                if (node.Name == "faction")
                {
                    retList.Add(node.Attributes["id"].Value);
                }
            }

            return retList;
        }

        public List<string> GetAllLicenceTypes()
        {
            XmlDocument t = new XmlDocument();
            t.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "factions.xml").GetFileAsString(BasePath));
            List<string> retList = new List<string>();

            XmlNodeList list = t.SelectNodes("//licence");

            foreach (XmlNode node in list)
            {
                if ( node.Attributes["type"] != null
                    && !retList.Contains(node.Attributes["type"].Value))
                {
                    retList.Add(node.Attributes["type"].Value);
                }
            }

            return retList;
        }

        public List<string> GetAllFactionForLicense(string licence)
        {
            XmlDocument t = new XmlDocument();
            t.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "factions.xml").GetFileAsString(BasePath));
            List<string> retList = new List<string>();
            XmlNodeList list = t.SelectNodes("//licence[@type='" + licence + "']");

            foreach (XmlNode node in list)
            {
                XmlNode pnode = node.ParentNode.ParentNode;
                if  (   pnode.Name == "faction"
                    &&  pnode.Attributes["id"] != null
                    )
                {
                    retList.Add(pnode.Attributes["id"].Value);
                }
            }

            return retList;
        }

        public string GetDefaultShipName(string shipClass, string shipMacro)
        {
            if (ShipNamesCache.Keys.Contains(shipMacro))
            {
                return ShipNamesCache[shipMacro];
            }

            XmlDocument t = new XmlDocument();
            try
            {
                shipClass = shipClass.Replace("ship", "size");
                t.LoadXml(Structure.GetFile(new List<string>() { "assets", "units", shipClass, "Macros" }, shipMacro + ".xml").GetFileAsString(BasePath));
                string name = t.SelectSingleNode("//identification").Attributes["name"].Value;
                if (name.StartsWith("{"))
                {
                    name = GetTranslation(name);
                }

                ShipNamesCache.Add(shipMacro, name);
                return name;
            }
            catch
            {
                ShipNamesCache.Add(shipMacro, shipMacro);
                return shipMacro;
            }
        }

        /// <summary>
        /// Stated this but it seems like it's no longer needed.
        /// </summary>
        /// <param name="baskets"></param>
        /// <returns></returns>
        public List<string> GetProductsInBasket(string baskets)
        {
            if (BasketsCache == null)
            {
                BasketsCache = new Dictionary<string, List<string>>();

                XmlDocument t = new XmlDocument();

                t.LoadXml(Structure.GetFile(new List<string>() { "libraries" }, "baskets.xml").GetFileAsString(BasePath));
                XmlNode basket = t.FirstChild.FirstChild;

                while (basket == null)
                {
                    // Missing implementation

                    basket = basket.NextSibling;
                }
            }

            if (BasketsCache.Keys.Contains(baskets))
            {
                return BasketsCache[baskets];
            }

            return new List<string>();
        }
        #endregion
    }
}
