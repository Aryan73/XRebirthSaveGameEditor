using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class SaveGameInfoData
    {
        #region Members
        XmlNode SaveGameInfoNode = null;
        CatDatExtractor cde = null;
        public List<PatchInfoData> Patches = new List<PatchInfoData>();
        #endregion

        #region Constructors
        public SaveGameInfoData(XmlNode saveGameInfoNode, CatDatExtractor cde)
        {
            SaveGameInfoNode = saveGameInfoNode;
            this.cde = cde;
            XmlNode patches = XMLFunctions.FindChild(saveGameInfoNode, "patches");

            if (patches != null)
            {
                XmlNode patch = patches.FirstChild;

                while (patch != null)
                {
                    Patches.Add(new PatchInfoData(patch, cde));
                    patch = patch.NextSibling;
                }
            }
        }
        #endregion

        #region Functions
        public void RemovePatch(PatchInfoData patch)
        {
            patch.Remove();
            Patches.Remove(patch);
            if (Patches.Count <= 0)
            {
                SaveGameInfoNode.RemoveChild(XMLFunctions.FindChild(SaveGameInfoNode, "patches"));
            }
        }
        #endregion

        #region Properties
        public string SaveGameName
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "save").Attributes["name"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute name does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute name does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string SaveGameDate
        {
            get
            {
                try
                {
                    return XMLFunctions.ConvertEpochToDateTime(XMLFunctions.FindChild(SaveGameInfoNode, "save").Attributes["date"].Value).ToString();
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute name does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute name does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string PlayerName
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "player").Attributes["name"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute player name does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute player name does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string PlayerMoney
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "player").Attributes["money"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute player money does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute player money does not exist. Is there something wrong with the save file?";
                }
            }
            set
            {
                XmlNode playerNode = null;
                try
                {
                    playerNode = XMLFunctions.FindChild(SaveGameInfoNode, "player");
                    if (playerNode == null)
                    {
                        throw new Exception("No player node found.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to locate player node. Is there something wrong with your save game?", ex);
                }

                try
                {
                    playerNode.Attributes["money"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to money attribute in player node. Is there something wrong with your save game?", ex);
                }
            }
        }

        public string GameCurrentVersion
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "game").Attributes["version"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute game version does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute game version does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string GameCurrentBuild
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "game").Attributes["build"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute game build does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute game build does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string GameCreationVersion
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "game").Attributes["original"].Value;
                }
                catch 
                {
                    Logger.Info("Attribute game original does not exist. Your save game was created in this version of X-Rebirth.");
                    return "Attribute game original does not exist. Your save game was created in this version of X-Rebirth";
                }
            }
        }

        public string GameTime
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "game").Attributes["time"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute game time does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute game time does not exist. Is there something wrong with the save file?";
                }
            }
        }

        public string GameStart
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(SaveGameInfoNode, "game").Attributes["start"].Value;
                }
                catch (Exception ex)
                {
                    Logger.Error("Attribute game start does not exist. Is there something wrong with the save file?", ex);
                    return "Attribute game start does not exist. Is there something wrong with the save file?";
                }
            }
        }
        #endregion
    }
}
