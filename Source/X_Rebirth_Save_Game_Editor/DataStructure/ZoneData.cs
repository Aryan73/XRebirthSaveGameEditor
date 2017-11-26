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
    public class ZoneData
    {
        #region Members
        XmlNode ZoneNode = null;
        string ZoneName = null;
        List<ShipData> Ships = new List<ShipData>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ZoneData(XmlNode zoneNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                // 1 Zone: <connection connection="tzonecluster_d_sector18_zone45_connection"> -> <component class="zone" macro="tzonecluster_d_sector18_zone45_macro" connection="sector" owner="canteran" knownto="player" id="[0x1c2c5]">
                ZoneNode = zoneNode.FirstChild;
                ZoneName = zoneNode.Attributes["connection"].Value;
                // Some zone does not have any "connections" node.
                if (XMLFunctions.FindChild(ZoneNode, "connections") != null)
                {
                    XmlNode childNode = XMLFunctions.FindChild(ZoneNode, "connections").FirstChild;

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
                            Logger.Error("Unable to add child node for zone", ex);
                        }
                        childNode = childNode.NextSibling;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse zone node", ex);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Retrieves a lists of skunks. The list should be 0 or 1
        /// </summary>
        /// <returns></returns>
        public List<ShipData> GetSkunks()
        {
            return Ships.Where(a => a.IsSkunk()).ToList();
        }
        #endregion

        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            TreeNodeCollection zoneNodes;
            if (searchData.Zones)
            {
                nodes.Add(ZoneName, ZoneName);
                nodes[ZoneName].Tag = this;
                zoneNodes = nodes[ZoneName].Nodes;
            }
            else
            {
                zoneNodes = nodes;
            }

            foreach (ShipData ship in Ships)
            {
                ship.GetTreeView(zoneNodes, searchData);
            }
        }
    }
}
