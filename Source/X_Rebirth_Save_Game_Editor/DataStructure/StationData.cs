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
    public class StationData
    {
        #region Members
        XmlNode StationNode = null;
        CatDatExtractor cde = null;

        private List<NPCData> npcs = null;
        
        private string stationName = "";

        #region Shipyard
        // First node: the ship node, second node the ressources node
        private Dictionary<XmlNode, XmlNode> QueuedShips = new Dictionary<XmlNode, XmlNode>();
        #endregion

        #endregion

        #region Constructors
        public StationData(XmlNode stationNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                StationNode = stationNode;
                // ignored "main" nodes:
                // <listeners>
                // <events>
                // <offset>
                // <shields>
                // <turrets>
                // <signs>
                // <surface>
                // <ammunition>
                // <trade>
                // <economylog>
                // <lastglobalanimation>
                // <gravidar>
                // <snapshot>

                // iterate on building module nodes
                foreach(XmlNode buildmoduleNode in StationNode.SelectNodes(".//component[@class='buildmodule']"))
                {
                    XmlNode buildNode = buildmoduleNode.SelectSingleNode(".//build");
                    if (buildNode == null || buildNode.Attributes["state"].Value!= "waitingforresources")
                    {   //The module does not wait for ressources 
                        break;
                    }
                    // Select the ship currently queued
                    XmlNode queuedShipNode = buildmoduleNode.SelectSingleNode(".//component[contains(@class='ships')]");
                    if (queuedShipNode==null)
                    {
                        Logger.Warning("StationData, Shipyard buildmodule waitingforresources does not contains any ships");
                        break;
                    }
                    QueuedShips.Add(queuedShipNode, buildNode.SelectSingleNode(".//resources"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse station.", ex);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// If the macro contains "shipyard" then the station is a shipyard (of course).
        /// </summary>
        public bool IsShipyard()
        {
            if (StationMacro.Contains("shipyard")) { return true; }

            return false;
        }

        /// <summary>
        /// If the owner matches returns true.
        /// </summary>
        /// <param name="owner">Provide the owner name. The default is player.</param>
        /// <returns></returns>
        public bool IsOwnedBy(string owner = "player")
        {
            if (StationOwner == owner) return true;
            return false;
        }

        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            if (searchData.Stations && (searchData.Faction == "All" || IsOwnedBy(searchData.Faction)))
            {
                nodes.Add(StationId, StationName);
                nodes[StationId].Tag = this;
            }
        }

        /// <summary>
        /// clear the ressources required for ship construction
        /// </summary>
        /// <returns></returns>
        public void FillNeededRessources(XmlNode shipQueued)
        {
            Logger.Verbose("FillNeededRessources(XmlNode shipQueued) not yet implemented");
            return;
        }

        #endregion

        #region Properties
        public List<NPCData> NPCs
        {
            get
            {
                if(npcs == null)
                {
                    npcs = new List<NPCData>();

                    // Get All NPCs on station
                    foreach (XmlNode node in StationNode.SelectNodes(".//component[@class='npc']"))
                    {
                        npcs.Add(new NPCData(node.ParentNode, cde));
                    }
                }
                return npcs;
            }
        }

        public string StationKnownTo
        {
            get
            {
                try
                {
                    return StationNode.FirstChild.Attributes["knownto"].Value;
                }
                catch
                {
                    return "";
                }
            }
        }
        
        /// <summary>
        /// Get or set the station owner
        /// </summary>
        public string StationOwner
        {
            get
            {
                try
                {
                    if (StationNode.FirstChild.Attributes["owner"] == null)
                    {
                        return "None";
                    }
                    return StationNode.FirstChild.Attributes["owner"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve station owner this is a fatal error.", ex);
                } 
            }
            set
            {
                try
                {
                    StationNode.FirstChild.Attributes["owner"].Value = value;

                    // also set owner for NPCs
                    foreach (NPCData npc in NPCs)
                    {
                        npc.Owner = value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to set station owner this is a fatal error.", ex);
                } 
            }
        }

        public string StationMacro
        {
            get
            {
                try
                {
                    return StationNode.FirstChild.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve station macro this is a fatal error.", ex);
                } 
            }
        }

        public string StationId
        {
            get
            {
                try
                {
                    return StationNode.FirstChild.Attributes["id"].Value;
                }
                catch
                {
                    return "";
                }
            }
        }

        public string StationName
        {
            get
            {
                if (StationNode.FirstChild.Attributes["name"] != null)
                {
                    return StationNode.FirstChild.Attributes["name"].Value;
                }

                if (stationName == "")
                {
                    try
                    {
                        stationName = cde.GetDefaultStationName(StationMacro);
                    }
                    catch
                    {
                        stationName = "";
                    }
                }
                return stationName;
            }
            set
            {
                XMLFunctions.SetSafeAttribute(StationNode.FirstChild, "name", value);
            }
        }
        #endregion        
    }
}
