using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class ShipWeaponCycleSlotData
    {
        // TODO: Since this is not used yet it is nit implemented correctly.
        #region Members
        XmlNode WeaponCycleSlotNode = null;
        string WeaponCycleSlotRef = null;
        List<KeyValuePair<string, int>> WeaponCycleCycle = new List<KeyValuePair<string, int>>();
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public ShipWeaponCycleSlotData(XmlNode weaponCycleSlotNode, CatDatExtractor cde)
        {
            try
            {
                this.cde = cde;
                WeaponCycleSlotNode = weaponCycleSlotNode;
                WeaponCycleSlotRef = WeaponCycleSlotNode.Attributes["ref"].Value;

                XmlNode childNode = WeaponCycleSlotNode.FirstChild;
                while (childNode != null)
                {
                    XmlAttribute indexAt = WeaponCycleSlotNode.Attributes["Index"];
                    int index = 0;

                    if (indexAt != null)
                    {
                        index = Convert.ToInt32(indexAt.Value);
                    }
                    WeaponCycleCycle.Add(new KeyValuePair<string, int>(WeaponCycleSlotNode.Attributes["ref"].Value, index));
                    childNode = childNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to parse weapon cycle slots", ex);
            }
        }
        #endregion

        public void RemoveWeaponSlot()
        {
            WeaponCycleSlotNode.RemoveChild(WeaponCycleSlotNode.FirstChild);
            WeaponCycleCycle.RemoveAt(1);
        }

        public void AddWeaponSlot(string weaponMacro, int index)
        {
            WeaponCycleSlotNode.AppendChild(WeaponCycleSlotNode.OwnerDocument.CreateElement("slot"));
            XmlAttribute attIndex = WeaponCycleSlotNode.OwnerDocument.CreateAttribute("index");
            attIndex.Value = index.ToString();
            WeaponCycleSlotNode.FirstChild.Attributes.Append(attIndex);
            XmlAttribute attRef = WeaponCycleSlotNode.OwnerDocument.CreateAttribute("ref");
            attRef.Value = weaponMacro;
            WeaponCycleSlotNode.FirstChild.Attributes.Append(attRef);
        }

        public bool ActiveWeaponSlot()
        {
            return WeaponCycleSlotNode.FirstChild != null;
        }

        public string WeaponMacro
        {
            get
            {
                if (!ActiveWeaponSlot())
                {
                    return "";
                }
                return WeaponCycleSlotNode.FirstChild.Attributes["ref"].Value;
            }
            set
            {
                WeaponCycleSlotNode.FirstChild.Attributes["ref"].Value = value;
            }
        }

        public int WeaponSlotIndex
        {
            get
            {
                if (!ActiveWeaponSlot())
                {
                    return -1;
                }

                XmlAttribute att = WeaponCycleSlotNode.FirstChild.Attributes["index"];
                if (att == null)
                {
                    return -1;
                }

                try
                {
                    int val = Convert.ToInt32(att.Value);
                    return val;
                }
                catch (Exception ex)
                {
                    Logger.Warning("Unable to convert index to int. That is strange...", ex);
                    return 0;
                }
            }
            set
            {
                if (!ActiveWeaponSlot())
                {
                    Logger.Warning("Cannot set index for inactive weaponslot.");
                }

                XmlAttribute att = WeaponCycleSlotNode.FirstChild.Attributes["index"];
                if (att == null)
                {
                    att = WeaponCycleSlotNode.OwnerDocument.CreateAttribute("index");
                    WeaponCycleSlotNode.FirstChild.Attributes.Prepend(att);
                }

                att.Value = value.ToString();
            }
        }

        public string WeaponSlotConnection
        {
            get
            {
                return WeaponCycleSlotNode.Attributes["ref"].Value;
            }
        }
    }
}
