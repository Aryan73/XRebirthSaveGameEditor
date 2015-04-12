using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipShieldData
    {
        #region Members
        XmlNode ShipShieldNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipShieldData(XmlNode shipShieldNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipShieldNode = shipShieldNode;
// behind: <connection connection="connection_dock_s01" macro="connection_dock_s01">
//            <connection connection="shields">
//<component class="shieldgenerator" macro="shieldgenerator_player_bal_mk4_macro" connection="connection01" id="[0xc5c]">
//<offset default="1" />
//<connections />
//</component>
//</connection>
// At the end
//            <connection connection="shieldgenerators">
//<component class="shieldgenerator" macro="shieldgenerator_player_cap_mk3_macro" connection="connection01" id="[0xc72]">
//<offset default="1" />
//<connections />
//</component>
//</connection>
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the connection name.
        /// </summary>
        public string ConnectionName
        {
            get
            {
                try
                {
                    return ShipShieldNode.Attributes["connection"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve connection name. this is a fatal error.", ex);
                }
            }
        }

        /// <summary>
        /// Get or set the macro for the shield.
        /// </summary>
        public string Macro
        {
            get
            {
                try
                {
                    return ShipShieldNode.FirstChild.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve macro.", ex);
                }
            }
            set
            {
                try
                {
                    ShipShieldNode.FirstChild.Attributes["macro"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to set macro.", ex);
                }
            }
        }
        #endregion
    }
}
