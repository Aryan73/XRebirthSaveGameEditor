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
    public class HighwayData
    {
        #region Members
        XmlNode HighwayNode = null;
        string HighwayName = null;
        List<ShipData> Ships = new List<ShipData>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public HighwayData(XmlNode highwayNode, CatDatExtractor cde)
        {
            // 1 Celestialbody: <connection connection="region_zone_011_connection"> -> <component class="celestialbody" component="cluster_b" connection="space" id="[0x1b5e7]">
            try
            {
                this.cde = cde;
                HighwayNode = highwayNode.FirstChild;
                HighwayName = highwayNode.Attributes["connection"].Value;

                XmlNode childNode = XMLFunctions.FindChild(HighwayNode, "connections").FirstChild;

                while (childNode != null)
                {
                    try
                    {
                        if (childNode.Attributes["connection"].Value == "ships")
                        {
                            Ships.Add(new ShipData(childNode, cde));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to add Highway child", ex);
                    }
                    childNode = childNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse Highway node.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            TreeNodeCollection highNodes;
            if (searchData.Highways)
            {
                nodes.Add(HighwayName, HighwayName);
                nodes[HighwayName].Tag = this;
                highNodes = nodes[HighwayName].Nodes;
            }
            else
            {
                highNodes = nodes;
            }

            foreach (ShipData ship in Ships)
            {
                ship.GetTreeView(highNodes, searchData);
            }
        }

        /// <summary>
        /// Retrieves a lists of skunks. The list should be 0 or 1
        /// </summary>
        /// <returns></returns>
        public List<ShipData> GetSkunks()
        {
            return Ships.Where(a => a.IsSkunk()).ToList();
        }
        #endregion
    }
}
