using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    /// <summary>
    /// TODO: Create structs for software
    /// TODO: Change settings by using the structs
    /// </summary>
    public class ShipSoftwareData
    {
        #region Members
        XmlNode ShipSoftwareNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shipSoftwareNode"></param>
        public ShipSoftwareData(XmlNode shipSoftwareNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipSoftwareNode = shipSoftwareNode;
        }

        public ShipSoftwareData(string macro, string softwareSlot, XmlNode shipNode, CatDatExtractor cde)
        {
            // Create software
            XmlElement connection = shipNode.OwnerDocument.CreateElement("connection");
            XmlAttribute connectionAtt = shipNode.OwnerDocument.CreateAttribute("connection");
            connectionAtt.Value = softwareSlot;
            connection.Attributes.Append(connectionAtt);
            XmlElement component = shipNode.OwnerDocument.CreateElement("component");
            XmlAttribute componentAttClass = shipNode.OwnerDocument.CreateAttribute("clas");
            componentAttClass.Value = "software";
            component.Attributes.Append(componentAttClass);
            XmlAttribute componentAttmacro = shipNode.OwnerDocument.CreateAttribute("macro");
            componentAttmacro.Value = macro;
            component.Attributes.Append(componentAttmacro);
            XmlAttribute componentAttConn = shipNode.OwnerDocument.CreateAttribute("connection");
            componentAttConn.Value = "softwareconnection";
            component.Attributes.Append(componentAttConn);
            XmlAttribute componentAttId = shipNode.OwnerDocument.CreateAttribute("id");
            componentAttId.Value = XMLFunctions.DetermineNewId(shipNode.OwnerDocument);
            component.Attributes.Append(componentAttId);
            connection.AppendChild(component);

            XmlNode insertAfter = null;

            if (SoftwareSlot == 2)
            {
                insertAfter = XMLFunctions.FindChild(shipNode.FirstChild, "connections").SelectSingleNode("connection[@connection='connection_software01']");
            }

            if (insertAfter == null)
            {
                insertAfter = XMLFunctions.FindChild(shipNode.FirstChild, "connections").SelectSingleNode("connection[@connection='storage']");
            }
            XMLFunctions.FindChild(shipNode.FirstChild, "connections").InsertAfter(connection, insertAfter);

            this.cde = cde;
            ShipSoftwareNode = connection;
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
                    return ShipSoftwareNode.Attributes["connection"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve connection name. this is a fatal error.", ex);
                }
            }
        }

        /// <summary>
        /// Get or set the macro for the software.
        /// </summary>
        public string Macro
        {
            get
            {
                try
                {
                    return ShipSoftwareNode.FirstChild.Attributes["macro"].Value;
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
                    ShipSoftwareNode.FirstChild.Attributes["macro"].Value = value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to set macro.", ex);
                }
            }
        }

        /// <summary>
        /// Get the software slot
        /// </summary>
        public int SoftwareSlot
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConnectionName.Substring(ConnectionName.Length - 2));
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve software slot number.", ex);
                }
            }
        }

        public void Remove()
        {
            ShipSoftwareNode.ParentNode.RemoveChild(ShipSoftwareNode);
        }
        #endregion
    }
}
