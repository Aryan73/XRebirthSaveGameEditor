using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class RelationData
    {
        // Note: the relation value between two factions is set on both faction relation node and should (ideally) be equal.
        #region Members
        XmlNode RelationNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Construnctors
        public RelationData(XmlNode relationNode, CatDatExtractor cde)
        {
            RelationNode = relationNode;
            this.cde = cde;
        }

        public RelationData(string faction, float relation, XmlNode parent, CatDatExtractor cde)
        {
            RelationNode = parent.OwnerDocument.CreateElement("relation");
            RelationNode.Attributes.Append(parent.OwnerDocument.CreateAttribute("faction"));
            RelationNode.Attributes["faction"].Value = faction;
            RelationNode.Attributes.Append(parent.OwnerDocument.CreateAttribute("relation"));
            RelationNode.Attributes["relation"].Value = relation.ToString();
            parent.AppendChild(RelationNode);
        }
        #endregion

        #region Properties
        public string faction
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(RelationNode, "faction");
            }
        }

        public float Relation
        {
            get
            {
                float f;
                if (float.TryParse(XMLFunctions.GetSafeAttribute(RelationNode, "relation"), out f))
                {
                    return f;
                }
                return 0;
            }
            set
            {
                XMLFunctions.SetSafeAttribute(RelationNode, "relation", value.ToString());
            }
        }
        #endregion

        public void Remove()
        {
            RelationNode.ParentNode.RemoveChild(RelationNode);
        }
    }
}
