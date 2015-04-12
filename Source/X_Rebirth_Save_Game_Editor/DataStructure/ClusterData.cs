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
    public class ClusterData
    {
        #region Members
        XmlNode ClusterNode = null;
        string ClusterName = null;
        List<RegionData> Regions = new List<RegionData>();
        List<SectorData> Sectors = new List<SectorData>();
        List<CelestialbodyData> Celestialbodys = new List<CelestialbodyData>();
        List<HighwayData> Highways = new List<HighwayData>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructor
        public ClusterData(XmlNode clusterNode, CatDatExtractor cde)
        {
            // 1 Cluster: <connection connection="cluster_b_connection"> -> <component class="cluster" macro="cluster_b_macro" connection="galaxy" knownto="player" id="[0x1712f]">
            try
            {
                ClusterNode = clusterNode.FirstChild;
                ClusterName = clusterNode.Attributes["connection"].Value;

                XmlNode childNode = XMLFunctions.FindChild(ClusterNode, "connections").FirstChild;

                while (childNode != null)
                {
                    try
                    {
                        if (childNode.FirstChild == null)
                        {
                            Logger.Info("Cluster child does not have child. No parse needed");
                        }
                        else if (childNode.FirstChild.Attributes["class"] == null)
                        {
                            Logger.Info("Cluster child does not have a class. No parse needed");
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value == null)
                        {
                            Logger.Info("Cluster child class does not have a value. No parse needed");
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "region")
                        {
                            Regions.Add(new RegionData(childNode, cde));
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "sector")
                        {
                            Sectors.Add(new SectorData(childNode, cde));
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "celestialbody")
                        {
                            Celestialbodys.Add(new CelestialbodyData(childNode, cde));
                        }
                        else if (childNode.FirstChild.Attributes["class"].Value.ToLower() == "highway")
                        {
                            Highways.Add(new HighwayData(childNode, cde));
                        }
                        else
                        {
                            Logger.Warning("Not a handled cluster child node type.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to add cluster child node type.", ex);
                    }

                    childNode = childNode.NextSibling;
                }
                this.cde = cde;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get ClusterNode data.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            TreeNodeCollection clustNodes;
            if (searchData.Clusters)
            {
                nodes.Add(ClusterName, ClusterName);
                nodes[ClusterName].Tag = this;
                clustNodes = nodes[ClusterName].Nodes;
            }
            else
            {
                clustNodes = nodes;
            }

            foreach (RegionData region in Regions)
            {
                region.GetTreeView(clustNodes, searchData);
            }

            foreach (SectorData sector in Sectors)
            {
                sector.GetTreeView(clustNodes, searchData);
            }

            foreach (CelestialbodyData Cel in Celestialbodys)
            {
                Cel.GetTreeView(clustNodes, searchData);
            }

            foreach (HighwayData highway in Highways)
            {
                highway.GetTreeView(clustNodes, searchData);
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
                Regions.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Exception occurred while scanning regions for skunk.", ex);
            }

            try
            {
               Sectors.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Exception occurred while scanning sectors for skunk.", ex);
            }

            try
            {
                Highways.ForEach(a => skunks.AddRange(a.GetSkunks()));
            }
            catch (Exception ex)
            {
                Logger.Error("Exception occurred while scanning highways for skunk.", ex);
            }

            return skunks;
        }
        #endregion
    }
}
