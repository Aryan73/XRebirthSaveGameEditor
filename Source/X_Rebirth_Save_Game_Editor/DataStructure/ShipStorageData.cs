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
    class ShipStorageData
    {
        #region Members
        XmlNode ShipStorageNode = null;
        CatDatExtractor cde = null;
        List<ShipStorageItemData> ShipStorageItems = null;
        #endregion

        #region Constructors
        public ShipStorageData(XmlNode shipStorageNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                ShipStorageNode = shipStorageNode;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse ship storage.", ex);
            }
        }
        #endregion

        #region Properties
        public string Connection
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode, "connection");
            }
        }

        public string Macro
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode, "macro");
            }
        }

        public string ComponentMacro
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode.FirstChild, "macro");
            }
        }

        public string Class
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(ShipStorageNode.FirstChild, "class");
            }
        }

        public List<ShipStorageItemData> Items
        {
            get
            {
                if (ShipStorageItems == null)
                {
                    try
                    {
                        foreach (XmlNode node in ShipStorageNode.FirstChild.FirstChild.FirstChild.ChildNodes)
                        {
                            ShipStorageItems.Add(new ShipStorageItemData(node, cde));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to get cargo", ex);
                    }
                }

                return ShipStorageItems;
            }
        }
        #endregion
    }
}
