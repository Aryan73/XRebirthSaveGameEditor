using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class FactionData
    {
        #region Members
        XmlNode FactionNode = null;
        CatDatExtractor cde = null;
        List<LicenceData> LisencesCache = null;
        List<RelationData> RelationsCache = null;
        #endregion

        #region Construnctors
        public FactionData(XmlNode factionNode, CatDatExtractor cde)
        {
            FactionNode = factionNode;
            this.cde = cde;
        }

        public FactionData(string factionName, XmlNode parent, CatDatExtractor cde)
        {
            FactionNode = parent.OwnerDocument.CreateElement("faction");
            FactionNode.Attributes.Append(parent.OwnerDocument.CreateAttribute("id"));
            FactionNode.Attributes["id"].Value = factionName;
        }
        #endregion

        public List<LicenceData> Licences
        {
            get
            {
                if (LisencesCache == null)
                {
                    LisencesCache = new List<LicenceData>();
                    XmlNode node = XMLFunctions.FindChild(FactionNode, "licences");

                    if (node == null)
                    {
                        return LisencesCache;
                    }

                    foreach (XmlNode license in node.ChildNodes)
                    {
                        LisencesCache.Add(new LicenceData(license, cde));
                    }
                }

                return LisencesCache;
            }
        }

        public List<RelationData> Relations
        {
            get
            {
                if (RelationsCache == null)
                {
                    RelationsCache = new List<RelationData>();
                    XmlNode node = XMLFunctions.FindChild(FactionNode, "relations");

                    if (node == null)
                    {
                        return RelationsCache;
                    }
                    XmlNodeList relationList = node.SelectNodes("relation");
                    foreach (XmlNode relation in relationList)
                    {
                        RelationsCache.Add(new RelationData(relation, cde));
                    }
                }

                return RelationsCache;
            }
        }

        public void AddRelation(string faction, float value)
        {
            XmlNode relationsNode = XMLFunctions.FindChild(FactionNode, "relations");
            if (relationsNode == null)
            {
                relationsNode = FactionNode.OwnerDocument.CreateElement("relations");
                FactionNode.AppendChild(relationsNode);
            }

            Relations.Add(new RelationData(faction, value, XMLFunctions.FindChild(FactionNode, "relations"), cde));
        }

        public void RemoveRelation(RelationData relation)
        {
            relation.Remove();
            Relations.Remove(relation);
            if (Relations.Count <= 0)
            {
                FactionNode.RemoveChild(XMLFunctions.FindChild(FactionNode, "relations"));
            }
        }

        public void AddLicence(string licence, string faction)
        {
            XmlNode licencesNode = XMLFunctions.FindChild(FactionNode, "licences");
            if (licencesNode == null)
            {
                licencesNode = FactionNode.OwnerDocument.CreateElement("licences");
                FactionNode.AppendChild(licencesNode);
            }

            if (Licences.Exists(a => a.Type == licence))
            {
                Licences.First(a => a.Type == licence).AddFaction(faction);
            }
            else
            {
                Licences.Add(new LicenceData(faction, licence, licencesNode, cde));
            }
        }

        public void RemoveLicence(LicenceData licence)
        {
            licence.Remove();
            Licences.Remove(licence);
            if (Licences.Count <= 0)
            {
                FactionNode.RemoveChild(XMLFunctions.FindChild(FactionNode, "licences"));
            }
        }

        public string FactionName
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(FactionNode, "id");
            }
        }
    }
}
