using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class UniverseSearchData
    {
        public bool Clusters = false;
        public bool Regions = false;
        public bool Sectors = false;
        public bool Zones = false;
        public bool Highways = false;
        public bool CelestialBodies = false;
        public bool BuildingCVs = false;
        public bool OtherShips = false;
        public bool Stations = false;
        public bool NPCs = false;
        public string Faction = "";

        public void Reset()
        {
            Clusters = false;
            Regions = false;
            Sectors = false;
            Zones = false;
            Highways = false;
            CelestialBodies = false;
            BuildingCVs = false;
            OtherShips = false;
            Stations = false;
            NPCs = false;
            Faction = "";
        }

        public void ResetAreasOnly()
        {
            Clusters = false;
            Regions = false;
            Sectors = false;
            Zones = false;
            Highways = false;
            CelestialBodies = false;
        }

        public void ResetObjectsOnly()
        {
            BuildingCVs = false;
            OtherShips = false;
            Stations = false;
            NPCs = false;
        }
    }
}
