using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipWeaponData
    {
        #region Members
        XmlNode ShipWeaponNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipWeaponData(XmlNode shipWeaponNode, CatDatExtractor cde)
        {
            this.cde = cde;
            ShipWeaponNode = shipWeaponNode;
        }
/*
        <connection connection="conn_primaryweapon_impuls">
<component class="playerweapon" macro="weapon_player_impulse_mk1_macro" connection="shipconnection" lastshottime="0" ammunition="-1" targetseen="0" id="[0xc68]">
<offset>
<position x="-3.294" y="-0.1191" z="-2.88" />
</offset>
<shootcontroller class="playerprimary" shooter="[0xc68]" starttime="118.091" angle="0.0872665" />
<connections />
</component>
</connection>
 */

        public ShipWeaponData(string macro, string connection, XmlNode shipNode, CatDatExtractor cde)
        {
            this.cde = cde;

            ShipWeaponNode = shipNode.OwnerDocument.CreateElement("connection");
            XmlAttribute shipWeaponNodeAtt = shipNode.OwnerDocument.CreateAttribute("connection");
            shipWeaponNodeAtt.Value = connection;
            ShipWeaponNode.Attributes.Append(shipWeaponNodeAtt);
            XmlNode comp = shipNode.OwnerDocument.CreateElement("component");
            XmlAttribute compClass = shipNode.OwnerDocument.CreateAttribute("class");
            compClass.Value = "playerweapon";
            comp.Attributes.Append(compClass);
            XmlAttribute compMacro = shipNode.OwnerDocument.CreateAttribute("macro");
            compMacro.Value = macro;
            comp.Attributes.Append(compMacro);
            XmlAttribute compConn = shipNode.OwnerDocument.CreateAttribute("connection");
            if (connection.Contains("beam"))
            {
                compConn.Value = "shipconnection01";
            }
            else
            {
                compConn.Value = "shipconnection";
            }
            comp.Attributes.Append(compConn);
            XmlAttribute compLastShot = shipNode.OwnerDocument.CreateAttribute("lastshottime");
            compLastShot.Value = "0";
            comp.Attributes.Append(compLastShot);
            XmlAttribute compAmm = shipNode.OwnerDocument.CreateAttribute("ammunition");
            compAmm.Value = "-1";
            comp.Attributes.Append(compAmm);
            XmlAttribute compTar = shipNode.OwnerDocument.CreateAttribute("targetseen");
            compTar.Value = "0";
            comp.Attributes.Append(compTar);
            XmlAttribute compId = shipNode.OwnerDocument.CreateAttribute("id");
            string shooter = XMLFunctions.DetermineNewId(shipNode.OwnerDocument);
            compId.Value = shooter;
            comp.Attributes.Append(compId);
            comp.AppendChild(shipNode.OwnerDocument.ImportNode(cde.GetPlayerConnectionOffset(connection), true));
            XmlNode shoot = shipNode.OwnerDocument.CreateElement("shootcontroller");
            XmlAttribute shootClass = shipNode.OwnerDocument.CreateAttribute("class");
            shootClass.Value = "playerprimary";
            shoot.Attributes.Append(shootClass);
            XmlAttribute shootShoot = shipNode.OwnerDocument.CreateAttribute("shooter");
            shootShoot.Value = shooter;
            shoot.Attributes.Append(shootShoot);
            XmlAttribute shootST = shipNode.OwnerDocument.CreateAttribute("starttime");
            shootST.Value = "1";
            shoot.Attributes.Append(shootST);
            XmlAttribute shootAngle = shipNode.OwnerDocument.CreateAttribute("angle");
            shootAngle.Value = "0.0872665";
            shoot.Attributes.Append(shootAngle);
            comp.AppendChild(shoot);
            XmlNode connections = shipNode.OwnerDocument.CreateElement("connections");
            comp.AppendChild(connections);
            ShipWeaponNode.AppendChild(comp);
            XMLFunctions.FindChild(shipNode.FirstChild, "connections").InsertAfter(ShipWeaponNode, XMLFunctions.FindChild(shipNode.FirstChild, "connections").SelectSingleNode("connection[@connection='primaryship']"));
        }
        #endregion

        public void Remove()
        {
            ShipWeaponNode.ParentNode.RemoveChild(ShipWeaponNode);
        }

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
                    return ShipWeaponNode.Attributes["connection"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Uanable to retrieve connection name. this is a fatal error.", ex);
                }
            }
        }

        /// <summary>
        /// Get or set the macro for the weapon.
        /// </summary>
        public string Macro
        {
            get
            {
                try
                {
                    return ShipWeaponNode.FirstChild.Attributes["macro"].Value;
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
                    ShipWeaponNode.FirstChild.Attributes["macro"].Value = value;
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
