using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class FactionsData
    {
        #region Members
        XmlNode FactionsNode = null;
        CatDatExtractor cde = null;
        public List<FactionData> Factions = new List<FactionData>();
        #endregion

        #region Construnctors
        public FactionsData(XmlNode factionsNode, CatDatExtractor cde)
        {
            FactionsNode = factionsNode;
            this.cde = cde;

            foreach (XmlNode node in factionsNode.ChildNodes)
            {
                Factions.Add(new FactionData(node, cde, this));
            }
        }
        #endregion
        
        public FactionData AddFactionData(string name)
        {
            Factions.Add(new FactionData(name, FactionsNode, cde, this));
            return this[name];
        }

        public FactionData this[string factionName]
        {
            get
            {
                List<FactionData> factions = Factions.Where(a => a.FactionName == factionName).ToList();

                if (factions.Count > 0)
                {
                    return factions.First();
                }
                return null;
            }
        }

        public List<string> FationNames
        {
            get
            {
                return Factions.Select(a => a.FactionName).ToList();
            }
        }
                
    }
}
