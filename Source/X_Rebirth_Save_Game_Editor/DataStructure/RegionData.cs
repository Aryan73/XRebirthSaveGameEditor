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
    public class RegionData
    {
        #region Members
        XmlNode RegionNode = null;
        string RegionName = null;
        List<ShipData> Ships = new List<ShipData>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructor
        public RegionData(XmlNode regionNode, CatDatExtractor cde)
        {
            try
            {
                // 1 Region: <connection connection="region_zone_011_connection"> -> <component class="region" macro="region_zone_011_macro" connection="cluster" id="[0x17266]">
                RegionNode = regionNode.FirstChild;
                RegionName = regionNode.Attributes["connection"].Value;
                // Some region does not have any "connections" node.
                if (XMLFunctions.FindChild(RegionNode, "connections") != null)
                {
                    XmlNode childNode = XMLFunctions.FindChild(RegionNode, "connections").FirstChild;
                    this.cde = cde;

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
                            Logger.Error("Unable to add child to region.", ex);
                        }
                        childNode = childNode.NextSibling;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse region.", ex);
            }
        }
        #endregion

        #region Methods
        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            TreeNodeCollection regNodes;
            if (searchData.Regions)
            {
                nodes.Add(RegionName, RegionName);
                nodes[RegionName].Tag = this;
                regNodes = nodes[RegionName].Nodes;
            }
            else
            {
                regNodes = nodes;
            } 
            
            foreach (ShipData ship in Ships)
            {
                ship.GetTreeView(regNodes, searchData);
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
