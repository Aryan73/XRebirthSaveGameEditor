using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipEngineData
    {
        #region Members
        XmlNode ShipEngineNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipEngineData(XmlNode shipEngineNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipEngineNode = shipEngineNode;
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
                    return ShipEngineNode.Attributes["connection"].Value;
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
                    return ShipEngineNode.FirstChild.Attributes["macro"].Value;
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
                    ShipEngineNode.FirstChild.Attributes["macro"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to set macro.", ex);
                }
            }
        }

        public string BoosterMacro
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(ShipEngineNode.FirstChild, "connections").FirstChild.FirstChild.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve booster macro.", ex);
                }
            }
            set
            {
                try
                {
                    XMLFunctions.FindChild(ShipEngineNode.FirstChild, "connections").FirstChild.FirstChild.Attributes["macro"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to set booster macro.", ex);
                }
            }
        }

        public string BoosterRecharge
        {
            get
            {
                try
                {
                    return XMLFunctions.FindChild(XMLFunctions.FindChild(ShipEngineNode.FirstChild, "connections").FirstChild.FirstChild, "boost").Attributes["recharge"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve booster recharge rate.", ex);
                }
            }
            set
            {
                try
                {
                    XMLFunctions.FindChild(XMLFunctions.FindChild(ShipEngineNode.FirstChild, "connections").FirstChild.FirstChild, "boost").Attributes["recharge"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to set booster recharge rate.", ex);
                }
            }
        }
        #endregion
    }
}
