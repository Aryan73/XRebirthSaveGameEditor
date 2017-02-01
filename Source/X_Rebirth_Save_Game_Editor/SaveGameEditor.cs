using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using X_Rebirth_Save_Game_Editor.DataStructure;
using X_Rebirth_Save_Game_Editor.Logging;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor
{
    public class SaveGameEditor
    {
        #region Members
        XmlDocument SaveGame = null;
        public GalaxyData Galaxy = null;
        public SaveGameInfoData SaveGameInfo = null;
        public FactionsData Factions = null;
        public NPCsData NPCs = null;
        string SaveGamePath = null;
        string SaveGameName = null;
        CatDatExtractor cde = null;
        public bool SaveGameLoaded = false;
        #endregion

        #region Constructor
        public SaveGameEditor(string savePath, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                LoadNewSaveGame(savePath);
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(savePath)) savePath = "";
                throw new Exception("Unable to create SaveGameEditor for path " + savePath, ex);
            }
        }
        #endregion

        #region Methods
        #region FileHandling
        public void LoadNewSaveGame(string savePath)
        {
            if (XMLLoaded())
            {
                UnloadSaveGame();
            }
            XmlNode saveGameNode = null;
            XmlNode universeNode = null;
            try
            {
                // Load the XML file into memory
                SaveGame = null; // This makes sure the old data is properly disposed of
                SaveGame = new XmlDocument();
                // Test on the file extension
                string ext = Path.GetExtension(savePath);
                if (ext == ".xml")
                {
                    SaveGame.Load(savePath);
                }
                else if (ext == ".gz")
                {
                    using (FileStream fileStream = new FileStream(savePath, FileMode.Open))
                    {
                        using (GZipStream zipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                        {
                            using (XmlReader xmlReader = XmlReader.Create(zipStream, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Auto }))
                            {
                                xmlReader.MoveToContent();
                                XmlDocument xmlDocument = new XmlDocument();
                                SaveGame.Load(xmlReader);
                            }
                        }
                    }
                }
                
                saveGameNode = XMLFunctions.FindChild(SaveGame, "savegame");
                universeNode = XMLFunctions.FindChild(saveGameNode, "universe");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load XMLDocument into memory. There probably is an issue with XMLs structure.", ex);
            }

            try
            {
                int pos = savePath.LastIndexOf('\\') + 1;

                SaveGamePath = savePath.Substring(0, pos);
                SaveGameName = savePath.Substring(pos);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to split save game path.", ex);
            }

            try
            {
                // Create backup
                string location = SaveGamePath + "Backup " + DateTime.Now.ToString("yyyy-MM-dd HH mm ss") + "\\";

                if (!System.IO.Directory.Exists(location))
                {
                    System.IO.Directory.CreateDirectory(location);
                }
                System.IO.File.Copy(SaveGamePath + SaveGameName, location + SaveGameName);
                //Save(true); // TODO: This was extremely slow, Temporarily disabled
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to backup the XML file.", ex);
            }

            // Get info level refference
            try
            {
                SaveGameInfo = new SaveGameInfoData(XMLFunctions.FindChild(saveGameNode, "info"), cde);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse savegame info.", ex);
            }

            // Get Galaxy level refference
            try
            {
                Galaxy = new GalaxyData(XMLFunctions.FindChild(universeNode, "component"), cde);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse galaxy.", ex);
            }

            // Get factions level refference
            try
            {
                Factions = new FactionsData(XMLFunctions.FindChild(universeNode, "factions"), cde);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse savegame factions.", ex);
            }

            // Get all NPCs
            try
            {
                NPCs = new NPCsData(saveGameNode, cde);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse savegame NPCs.", ex);
            }

            SaveGameLoaded = true;
        } 

        public void UnloadSaveGame()
        {
            SaveGameLoaded = false;
            SaveGame = null;
            SaveGamePath = null;
            SaveGameName = null;
        }

        public bool XMLLoaded()
        {
            if (SaveGame == null)
            {
                return false;
            }

            return true;
        }

        public void Save(bool humanReadable = false, bool backup = false)
        {
            string location = "";
            XmlWriterSettings settings = null;
            try
            {
                if (XMLLoaded())
                {

                    try
                    {
                        location = SaveGamePath
                                 + (backup ? "Backup " + DateTime.Now.ToString("yyyy-MM-dd HH mm ss") + "\\" : "");


                        if (!System.IO.Directory.Exists(location))
                        {
                            System.IO.Directory.CreateDirectory(location);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to write determine or create savefile location.", ex);
                    }
                    
                    try
                    {
                        settings = new XmlWriterSettings();
                        settings.Encoding = Encoding.UTF8;
                        settings.Indent = true;
                        settings.IndentChars = "";
                        settings.NewLineOnAttributes = false;
                        settings.NewLineChars = "\n";
                        settings.NewLineHandling = System.Xml.NewLineHandling.None;
                        settings.OmitXmlDeclaration = false;
                        if (humanReadable)
                        {
                            settings.CloseOutput = true;
                            settings.ConformanceLevel = ConformanceLevel.Auto;
                            settings.NewLineOnAttributes = false;
                            settings.CheckCharacters = true;
                            settings.DoNotEscapeUriAttributes = true;
                            settings.WriteEndDocumentOnClose = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to create and set XmlWriterSettings.", ex);
                    }

                    try
                    {
                        XmlWriter writer = XmlWriter.Create(location + SaveGameName, settings);
                        SaveGame.Save(writer);
                        //SaveGame.WriteTo(writer);
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (location == null)
                        {
                            location = "null";
                        }
                        throw new Exception("Unable to write XML to file:" + location, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to write savegame(" + location + ").", ex);
            }
        }
        #endregion

        #region DataRetrieval
        #region Player data
        public string PlayerMoney
        {
            // TODO add all money locations
            get
            {
                // Check that all money locations have an equal amount
                if (SaveGameInfo.PlayerMoney != Galaxy.GetPlayer().AccountAmount)
                {
                    Galaxy.GetPlayer().AccountAmount = SaveGameInfo.PlayerMoney;
                    MessageBox.Show("Not all money locations for player are equal changing them.");
                }
                return SaveGameInfo.PlayerMoney;
            }
            set
            {
                // Set money in all locations
                SaveGameInfo.PlayerMoney = value;
                Galaxy.GetPlayer().AccountAmount = value;
            }
        }
        #endregion
        #endregion
        #endregion
    }

    // Clusters: <connections>
    // 1 Cluster: <connection connection="cluster_b_connection"> -> <component class="cluster" macro="cluster_b_macro" connection="galaxy" knownto="player" id="[0x1712f]">
    // 1 Region: <connection connection="region_zone_011_connection"> -> <component class="region" macro="region_zone_011_macro" connection="cluster" id="[0x17266]">
    // 1 Sector: <connection connection="cluster_b_sector04_connection"> -> <component class="sector" macro="cluster_b_sector04_macro" connection="cluster" knownto="player" id="[0x17267]">
    // Zones:
    // 1 Zone: <connection connection="tzonecluster_d_sector18_zone45_connection"> -> <component class="zone" macro="tzonecluster_d_sector18_zone45_macro" connection="sector" owner="canteran" knownto="player" id="[0x1c2c5]">
    // Ships in zone: <connections>
    // 1 ship: <connection connection="ships"> -> <component class="ship_m" macro="units_size_m_container_transporter_5_macro" connection="space" attackmethod="lowattentionattack" attacktime="23080.544" id="[0x1c2c6]">

    // skunk data: <connection connection="ships"> (Multiple the same...) <component class="ship_s" macro="unit_player_ship_macro" connection="space" attacker="[0x1b850]" attackmethod="hitbybullet" attacktime="47711.578" owner="player" id="[0x1b8ee]">
    // <shields> 292692
    // <ammunition> -> <available> 292708
    // <weaponcycle> 292718
    // <connections> -> 292751 (other data) 
}

