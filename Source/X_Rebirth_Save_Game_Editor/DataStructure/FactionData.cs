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
    public class FactionData
    {
        #region Members
        XmlNode FactionNode = null;
        CatDatExtractor cde = null;
        FactionsData factionsData = null;
        List<LicenceData> LisencesCache = null;
        List<RelationData> RelationsCache = null;
        // Ideally (to be similar to the savegame file), the boosters are member of the RelationData Lists
        List<BoosterData> RelationsBoosterCache = null;
        #endregion

        #region Construnctors
        public FactionData(XmlNode factionNode, CatDatExtractor cde, FactionsData factionsData)
        {
            FactionNode = factionNode;
            this.cde = cde;
            this.factionsData = factionsData;
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

        public List<BoosterData> Boosters
        {
            get
            {
                if (RelationsBoosterCache == null)
                {
                    RelationsBoosterCache = new List<BoosterData>();
                    XmlNode node = XMLFunctions.FindChild(FactionNode, "relations");

                    if (node == null)
                    {
                        return RelationsBoosterCache;
                    }
                    XmlNodeList boosterList = node.SelectNodes("booster");
                    foreach (XmlNode booster in boosterList)
                    {
                        RelationsBoosterCache.Add(new BoosterData(booster, cde));
                    }
                }

                return RelationsBoosterCache;
            }
        }

        public void AddRelation(string faction, float value)
        {
            // On the selected faction toward the targeted one
            XmlNode relationsNode = XMLFunctions.FindChild(FactionNode, "relations");
            if (relationsNode == null)
            {
                relationsNode = FactionNode.OwnerDocument.CreateElement("relations");
                FactionNode.AppendChild(relationsNode);
            }
            Relations.Add(new RelationData(faction, value, XMLFunctions.FindChild(FactionNode, "relations"), cde));

            // On the targeted faction toward the selected
            string SelectedFaction = FactionName;
            FactionData TargetedFaction = factionsData[faction];
            relationsNode = XMLFunctions.FindChild(TargetedFaction.FactionNode, "relations");
            if (relationsNode == null)
            {
                relationsNode = TargetedFaction.FactionNode.OwnerDocument.CreateElement("relations");
                TargetedFaction.FactionNode.AppendChild(relationsNode);
            }
            TargetedFaction.Relations.Add(new RelationData(faction, value, XMLFunctions.FindChild(TargetedFaction.FactionNode, "relations"), cde));
        }

        public void RemoveRelation(RelationData relation)
        {
            relation.Remove();
            Relations.Remove(relation);
            if (Relations.Count <= 0 && Boosters.Count <= 0)
            {
                // Only removed if both Relations and Boosters are null (they have the same parent node "relations" in save file).
                FactionNode.RemoveChild(XMLFunctions.FindChild(FactionNode, "relations"));
            }
        }

        public void UpdateRelationPartners()
        {
            foreach (RelationData partner in RelationsCache)
            {
                float relation = partner.Relation;
                string partnerName = partner.faction;
                FactionData TargetedFaction = factionsData[partnerName];
                RelationData TheRelation = null;
                foreach (RelationData TempRelation in TargetedFaction.Relations)
                {
                    if (TempRelation.faction == FactionName) { TheRelation = TempRelation; }
                }
                if (TheRelation != null)
                {
                    TheRelation.Relation = relation;
                }
                else { Logger.Error("A partner did not found the current faction in its relation list."); }
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

        public void AddBooster(string faction, float value, float time)
        {
            XmlNode relationsNode = XMLFunctions.FindChild(FactionNode, "relations");
            if (relationsNode == null)
            {
                relationsNode = FactionNode.OwnerDocument.CreateElement("relations");
                FactionNode.AppendChild(relationsNode);
            }
            Boosters.Add(new BoosterData(faction, value, time, XMLFunctions.FindChild(FactionNode, "relations"), cde));
        }

        public void RemoveBooster(BoosterData booster)
        {
            booster.Remove();
            Boosters.Remove(booster);
            if (Boosters.Count <= 0 && Relations.Count <= 0)
            {
                // Only removed if both Relations and Boosters are null (they have the same parent node "relations" in save file).
                FactionNode.RemoveChild(XMLFunctions.FindChild(FactionNode, "relations"));
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
