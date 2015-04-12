using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipAmmunitionItemData
    {
        #region Members
        XmlNode ShipAmmunitionItemNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipAmmunitionItemData(XmlNode shipAmmunitionItemNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipAmmunitionItemNode = shipAmmunitionItemNode;
        }
        #endregion

        #region Properties
        public string Ware
        {
            get
            {
                try
                {
                    return ShipAmmunitionItemNode.Attributes["macro"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve macro for ammunition. There is something wrong with this save.", ex);
                }
            }
        }

        public Int64 amount
        {
            get
            {
                try
                {
                    return Convert.ToInt64(ShipAmmunitionItemNode.Attributes["amount"].Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve amount for ammunition. There is something wrong with this save.", ex);
                }
            }
            set
            {
                
                try
                {
                    ShipAmmunitionItemNode.Attributes["amount"].Value = value.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve amount for ammunition. There is something wrong with this save.", ex);
                }
            }
        }

        public void RemoveNode()
        {
            try
            {
                ShipAmmunitionItemNode.ParentNode.RemoveChild(ShipAmmunitionItemNode);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to remove node.", ex);
            }
        }
        #endregion
    }
}
