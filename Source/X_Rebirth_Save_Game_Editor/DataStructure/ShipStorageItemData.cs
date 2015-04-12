using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    class ShipStorageItemData
    {
        #region Members
        XmlNode ShipStorageItemNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipStorageItemData(XmlNode shipStorageItemNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                ShipStorageItemNode = shipStorageItemNode;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse ship storage.", ex);
            }
        }
        #endregion

        #region Properties
        public string Ware
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageItemNode, "ware");
            }
        }

        public Int64 Amount
        {
            get
            {
                Int64 ret;

                if (Int64.TryParse(XMLFunctions.GetSafeAttribute(ShipStorageItemNode, "amount"), out ret))
                {
                    return ret;
                }

                return 0;
            }
            set
            {
                string val = value.ToString();

                XMLFunctions.SetSafeAttribute(ShipStorageItemNode, "amount", val);
            }
        }
        #endregion
    }
}
