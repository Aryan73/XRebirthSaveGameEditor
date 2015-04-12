using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class LicenceData
    {
        #region Members
        XmlNode LicenseNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Construnctors
        public LicenceData(XmlNode licenseNode, CatDatExtractor cde)
        {
            LicenseNode = licenseNode;
            this.cde = cde;
        }

        public LicenceData(string factions, string type, XmlNode parent, CatDatExtractor cde)
        {
            LicenseNode = parent.OwnerDocument.CreateElement("license");
            LicenseNode.Attributes.Append(parent.OwnerDocument.CreateAttribute("type"));
            LicenseNode.Attributes["type"].Value = type;
            LicenseNode.Attributes.Append(parent.OwnerDocument.CreateAttribute("factions"));
            LicenseNode.Attributes["factions"].Value = factions;
            parent.AppendChild(LicenseNode);
        }
        #endregion

        #region Properties
        public string Type
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(LicenseNode, "type");
            }
        }

        public string Factions
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(LicenseNode, "factions");
            }
        }
        #endregion

        public void Remove()
        {
            LicenseNode.ParentNode.RemoveChild(LicenseNode);
        }

        public void AddFaction(string faction)
        {
            XMLFunctions.SetSafeAttribute(LicenseNode, "factions", XMLFunctions.GetSafeAttribute(LicenseNode, "factions") + " " + faction);
        }
    }
}
