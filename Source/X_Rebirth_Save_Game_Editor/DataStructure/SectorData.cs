using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class SectorData
    {
        #region Members
        XmlNode SectorNode = null;
        string SectorName = null;

        List<HighwayData> Highways = new List<HighwayData>();
        List<ZoneData> Zones = new List<ZoneData>();
        List<ZoneData> TempZones = new List<ZoneData>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public SectorData(XmlNode sectorNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;

                // 1 Sector: <connection connection="cluster_b_sector04_connection"> -> <component class="sector" macro="cluster_b_sector04_macro" connection="cluster" knownto="player" id="[0x17267]">
                SectorNode = sectorNode.FirstChild;
                SectorName = sectorNode.Attributes["connection"].Value;

                XmlNode childNode = XMLFunctions.FindChild(SectorNode, "connections").FirstChild;
                while (childNode != null)
                {
                    try
                    {
                        if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "zone"
                            && childNode.FirstChild.Attributes["macro"].Value.ToLower() == "tempzone"
                            )
                        {
                            TempZones.Add(new ZoneData(childNode, cde));
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "zone")
                        {
                            Zones.Add(new ZoneData(childNode, cde));
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "highway")
                        {
                            Highways.Add(new HighwayData(childNode, cde));
                        }
                        else
                        {
                            throw new Exception("Not a zone or highway. This is a " + childNode.FirstChild.Attributes["class"].Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to add child to sector", ex);
                    }

                    childNode = childNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse sector.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            TreeNodeCollection secNodes;
            if (searchData.Sectors)
            {
                nodes.Add(SectorName, SectorName);
                nodes[SectorName].Tag = this;
                secNodes = nodes[SectorName].Nodes;
            }
            else
            {
                secNodes = nodes;
            }

            foreach (HighwayData highway in Highways)
            {
                highway.GetTreeView(secNodes, searchData);
            }

            foreach (ZoneData zone in Zones)
            {
                zone.GetTreeView(secNodes, searchData);
            }

            foreach (ZoneData zone in TempZones)
            {
                zone.GetTreeView(secNodes, searchData);
            }
        }

        /// <summary>
        /// Retrieves a lists of skunks. The list should be 0 or 1
        /// </summary>
        /// <returns></returns>
        public List<ShipData> GetSkunks()
        {
            List<ShipData> skunks = new List<ShipData>();
            try
            {
                Zones.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Failed while searching skunk in Zones", ex);
            }

            try
            {
                TempZones.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Failed while searching skunk in TempZones", ex);
            }

            try
            {
                Highways.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Failed while searching skunk in Highways", ex);
            }

            return skunks;
        }
        #endregion
    }
}
