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
    public class NPCData
    {
        #region Members
        XmlNode NPCNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructor
        public NPCData(XmlNode npcNode, CatDatExtractor cde)
        {
            NPCNode = npcNode;
            this.cde = cde;
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(NPCNode.ChildNodes[0], "name");
            }
            set
            {
                XMLFunctions.SetSafeAttribute(NPCNode.ChildNodes[0], "name", value);
            }
        }

        public string Owner
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(NPCNode.ChildNodes[0], "owner");
            }
            set
            {
                XMLFunctions.SetSafeAttribute(NPCNode.ChildNodes[0], "owner", value);
            }
        }

        public string Macro
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(NPCNode.ChildNodes[0], "macro");
            }
            //set for now do not allow to set macro
            //{
            //    XMLFunctions.SetSafeAttribute(NPCNode.ChildNodes[0], "macro", value);
            //}
        }

        public string Connection
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(NPCNode.ChildNodes[0], "connection");
            }
            //set for now do not allow to set connection
            //{
            //    XMLFunctions.SetSafeAttribute(NPCNode.ChildNodes[0], "connection", value);
            //}
        }

        public string Type
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(XMLFunctions.FindChild(NPCNode.ChildNodes[0], "entity"), "type");
            }
        }

        public ushort Boarding
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("boarding");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("boarding" ,value);
            }
        }

        public ushort Combat
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("combat");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("combat", value);
            }
        }

        public ushort Engineering
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("engineering");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("engineering", value);
            }
        }

        public ushort Leadership
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("leadership");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("leadership", value);
            }
        }

        public ushort Management
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("management");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("management", value);
            }
        }

        public ushort Morale
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("morale");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("morale", value);
            }
        }

        public ushort Navigation
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("navigation");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("navigation", value);
            }
        }

        public ushort Science
        {
            get
            {
                ushort res = 0;
                XmlNode node = GetSkillNode("science");

                if (ushort.TryParse(XMLFunctions.GetSafeAttribute(node, "value"), out res))
                {
                    return res;
                }
                return 0;
            }
            set
            {
                SetSkillNode("science", value);
            }
        }
        #endregion

        #region Functions
        public XmlNode GetSkillNode(string skill)
        {
            XmlNode node = XMLFunctions.FindChild(NPCNode.ChildNodes[0], "skills").FirstChild;

            while (node != null)
            {
                if (XMLFunctions.GetSafeAttribute(node, "type") == skill)
                {
                    return node;
                }
                node = node.NextSibling;
            }

            return null;
        }

        public void SetSkillNode(string skill, ushort value)
        {
            if (value > 5)
            {
                Logger.Warning("Warning value higher than 5. reset to 5.");
                value = 5;
            }

            XmlNode node = GetSkillNode(skill);

            if (node == null)
            {
                node = NPCNode.OwnerDocument.CreateElement("skill");
                XmlAttribute att = NPCNode.OwnerDocument.CreateAttribute("type");
                att.Value = skill;
                node.Attributes.Append(att);
                XMLFunctions.FindChild(NPCNode.ChildNodes[0], "skills").AppendChild(node);
            }

            XMLFunctions.SetSafeAttribute(node, "value", value.ToString());
        }
        #endregion
    }
}
