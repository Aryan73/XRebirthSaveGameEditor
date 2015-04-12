using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipScannerData
    {
        #region Members
        XmlNode ShipScannerNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipScannerData(XmlNode shipScannerNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipScannerNode = shipScannerNode;
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
                    return ShipScannerNode.Attributes["connection"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve connection name. this is a fatal error.", ex);
                }
            }
        }

        /// <summary>
        /// Get or set the macro for the scanner.
        /// </summary>
        public string Macro
        {
            get
            {
                try
                {
                    return ShipScannerNode.FirstChild.Attributes["macro"].Value;
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
                    ShipScannerNode.FirstChild.Attributes["macro"].Value = value;
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
