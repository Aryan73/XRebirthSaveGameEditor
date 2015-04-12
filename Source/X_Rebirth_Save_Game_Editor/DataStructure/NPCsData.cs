using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class NPCsData
    {
        #region Members
        CatDatExtractor cde = null;
        public List<NPCData> NPCs = new List<NPCData>();
        #endregion

        #region Construnctors
        public NPCsData(XmlNode saveGame, CatDatExtractor cde)
        {
            this.cde = cde;
            //component class="npc"
            foreach (XmlNode node in saveGame.SelectNodes("//component[@class='npc']"))
            {
                NPCs.Add(new NPCData(node.ParentNode, cde));
            }
        }
        #endregion

        public List<NPCData> this[string OwnerName]
        {
            get
            {
                return NPCs.Where(a => a.Owner == OwnerName).ToList();
            }
        }

        public List<string> NPCNames
        {
            get
            {
                return NPCs.Select(a => a.Name).ToList();
            }
        }

        public List<string> GetAllTypes()
        {
            return NPCs.Select(a => a.Type).Distinct().ToList();
        }
    }
}
