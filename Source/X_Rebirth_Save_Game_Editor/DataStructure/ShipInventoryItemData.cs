using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipInventoryItemData
    {
        #region Members
        XmlNode ShipInventoryItemNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipInventoryItemData(XmlNode shipInventoryItemNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipInventoryItemNode = shipInventoryItemNode;
        }
        #endregion

        #region Properties
        public string Ware
        {
            get
            {
                try
                {
                    return ShipInventoryItemNode.Attributes["ware"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve ware for inventory. There is something wrong with this save.", ex);
                }
            }
        }

        public Int64 amount
        {
            get
            {
                try
                {
                    XmlAttribute amount = ShipInventoryItemNode.Attributes["amount"];
                    if  (amount == null)
                    {
                        ShipInventoryItemNode.Attributes.Append(ShipInventoryItemNode.OwnerDocument.CreateAttribute("amount"));
                    }

                    amount = ShipInventoryItemNode.Attributes["amount"];
                    if (string.IsNullOrEmpty(amount.Value))
                    {
                        amount.Value = "1";
                    }

                    amount = ShipInventoryItemNode.Attributes["amount"];
                    try
                    {
                        return Convert.ToInt64(amount.Value);
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning("Current value is not an int. There is something wrong with this save.", ex);
                        amount.Value = "1";
                    }

                    return Convert.ToInt64(amount.Value);
                }
                catch (Exception ex)
                {
                    Logger.Warning("Unable to retrieve amount for inventory. There is something wrong with this save.", ex);
                    return 1;
                }
            }
            set
            {
                try
                {
                    ShipInventoryItemNode.Attributes["amount"].Value = value.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve amount for inventory. There is something wrong with this save.", ex);
                }
            }
        }

        public void RemoveNode()
        {
            try
            {
                ShipInventoryItemNode.ParentNode.RemoveChild(ShipInventoryItemNode);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to remove node.", ex);
            }
        }
        #endregion
    }
}
