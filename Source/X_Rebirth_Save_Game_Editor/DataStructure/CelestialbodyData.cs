using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class CelestialbodyData
    {
        XmlNode CelestialbodyNode = null;
        string CelestialbodyName = null;
        CatDatExtractor cde = null;

        public CelestialbodyData(XmlNode celestialbodyNode, CatDatExtractor cde)
        {
            // 1 Celestialbody: <connection connection="region_zone_011_connection"> -> <component class="celestialbody" component="cluster_b" connection="space" id="[0x1b5e7]">
            try
            {
                CelestialbodyNode = celestialbodyNode.FirstChild;
                CelestialbodyName = celestialbodyNode.Attributes["connection"].Value;
                this.cde = cde;
            }
            catch (Exception ex)
            {
                Logger.Warning("Unable to create CelestialbodyData.", ex);
            }
        }

        public void GetTreeView(TreeNodeCollection nodes, UniverseSearchData searchData)
        {
            if (searchData.CelestialBodies)
            {
                nodes.Add(CelestialbodyName, CelestialbodyName);
                nodes[CelestialbodyName].Tag = this;
            }
        }
    }
}
