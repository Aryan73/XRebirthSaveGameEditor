using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipCockpitData
    {
        #region Members
        XmlNode ShipCockpitNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipCockpitData(XmlNode shipCockpitNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                ShipCockpitNode = shipCockpitNode;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse cockpit", ex);
            }
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
                    return ShipCockpitNode.Attributes["connection"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve the connection identifier. This is a fatal error!", ex);
                }
            }
        }

        /// <summary>
        /// Get or set the macro for the cockpit.
        /// </summary>
        public string Macro
        {
            get
            {
                try
                {
                    return ShipCockpitNode.FirstChild.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve the macro for the cockpit", ex);
                }
            }
            set
            {
                try
                {
                    ShipCockpitNode.FirstChild.Attributes["macro"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to set the macro for the cockpit", ex);
                }
            }
        }
        #endregion
    }
}
