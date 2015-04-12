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
    public class GalaxyData
    {
        #region Members
        List<ClusterData> Clusters = new List<ClusterData>();
        XmlNode GalaxyNode = null;
        ShipData Skunk = null;
        PlayerData Player = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public GalaxyData(XmlNode galaxyNode, CatDatExtractor cde)
        {
            try
            {
                GalaxyNode = galaxyNode;
                XmlNode childNode = XMLFunctions.FindChild(GalaxyNode, "connections").FirstChild;
                while (childNode != null)
                {
                    try
                    {
                        if (childNode.Attributes["connection"].Value.ToLower() != "clusters")
                        {
                            Clusters.Add(new ClusterData(childNode, cde));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to parse child of galaxy.", ex);
                    }
                    
                    childNode = childNode.NextSibling;
                }

                GetSkunk();
                this.cde = cde;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse galaxy node.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            foreach (ClusterData cluster in Clusters)
            {
                cluster.GetTreeView(nodes, searchData);
            }
        }

        /// <summary>
        /// Retrieves a lists of skunks. The list should be 0 or 1
        /// </summary>
        /// <returns></returns>
        public ShipData GetSkunk()
        {
            if (Skunk == null)
            {
                List<ShipData> skunks = new List<ShipData>();
                try
                {
                    Clusters.ForEach(a => skunks.AddRange(a.GetSkunks()));
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed while searching clusters for the skunk.", ex);
                }

                if (skunks.Count == 1)
                {
                    Skunk = skunks.First();
                }
                else if (skunks.Count > 1)
                {
                    throw new Exception("More than one skunk found. Thats wierd :P");
                }
                else
                {
                    XmlNode skunkNode = GalaxyNode.SelectSingleNode("//component[contains(@macro, 'unit_player_ship_')]");
                    if (skunkNode != null)
                    {
                        Skunk = new ShipData(skunkNode.ParentNode, cde);
                    }
                    else
                    {
                        throw new Exception("No skunk found in XML. Thats wierd :P");
                    }
                }

                if(Skunk == null)
                {
                    throw new Exception("No skunk found. Thats wierd :P");
                }
            }

            return Skunk;
        }

        public PlayerData GetPlayer()
        {
            if (Player == null)
            {
                XmlNode playerNode = GalaxyNode.SelectSingleNode("//connection[@connection='connection_player']");
                Player = new PlayerData(playerNode, cde);
            }

            return Player;
        }
        #endregion
    }
}
