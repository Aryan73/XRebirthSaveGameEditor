using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Rebirth_Save_Game_Editor.DataStructure;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormUniverseEditor : Form
    {
        #region Members
        static FormUniverseEditor instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        string StandardErrorText = "";
        CatDatExtractor cde = null;
        UniverseSearchData SearchData = new UniverseSearchData();
        Form subForm = null;
        #endregion

        #region Constructors
        private FormUniverseEditor()
        {
        }

        private FormUniverseEditor(SaveGameEditor sge, string standardErrorText, CatDatExtractor cde)
        {
            InitializeComponent();
            this.sge = sge;
            StandardErrorText = standardErrorText;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormUniverseEditor Instance(SaveGameEditor sge, string standardErrorText, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormUniverseEditor(sge, standardErrorText, cde);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
            comboBoxFaction_DropDown(null, null);
            SearchData.Faction = "All";
        }

        public void ResizeElements()
        {
            splitContainerMain.SplitterDistance = 200;
            splitContainerTreeView.SplitterDistance = 150;
            splitContainerCheckBox.SplitterDistance = 100;
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
        }
        #endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SearchData.Reset();
            SearchData.Faction = comboBoxFaction.SelectedItem.ToString();
            foreach(object item in checkedListBox1.CheckedItems)
            {
                switch(item.ToString())
                {
                    case "Clusters":
                        SearchData.Clusters = true;
                        break;
                    case "Regions":
                        SearchData.Regions = true;
                        break;
                    case "Sectors":
                        SearchData.Sectors = true;
                        break;
                    case "Zones":
                        SearchData.Zones = true;
                        break;
                    case "Highways":
                        SearchData.Highways = true;
                        break;
                    case "Celestial bodies":
                        SearchData.CelestialBodies = true;
                        break;         
                }
            }

            foreach (object item in checkedListBox2.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Building CVs":
                        SearchData.BuildingCVs = true;
                        break;
                    case "Other ships":
                        SearchData.OtherShips = true;
                        break;
                    case "Stations (Not yet)":
                        SearchData.Stations = true;
                        break;
                    case "NPCs (Not yet)":
                        SearchData.NPCs = true;
                        break;
                }
            }

            bool newState = e.NewValue == CheckState.Checked;

            switch (((CheckedListBox)sender).Items[e.Index].ToString())
            {
                case "Clusters":
                    SearchData.Clusters = newState;
                    break;
                case "Regions":
                    SearchData.Regions = newState;
                    break;
                case "Sectors":
                    SearchData.Sectors = newState;
                    break;
                case "Zones":
                    SearchData.Zones = newState;
                    break;
                case "Highways":
                    SearchData.Highways = newState;
                    break;
                case "Celestial bodies":
                    SearchData.CelestialBodies = newState;
                    break;
                case "Building CVs":
                    SearchData.BuildingCVs = newState;
                    break;
                case "Other ships":
                    SearchData.OtherShips = newState;
                    break;
                case "Stations (Not yet)":
                    SearchData.Stations = newState;
                    break;
                case "NPCs (Not yet)":
                    SearchData.NPCs = newState;
                    break;
            }
            treeViewNavigation.Nodes.Clear();
            sge.Galaxy.GetTreeView(treeViewNavigation.Nodes, SearchData);
        }

        private void comboBoxFaction_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxFaction.SelectedIndexChanged -= comboBoxFaction_SelectedIndexChanged;
                comboBoxFaction.SelectedIndexChanged -= comboBoxFaction_SelectedIndexChanged;
                comboBoxFaction.Items.Clear();
                comboBoxFaction.Items.Add("All");
                comboBoxFaction.Items.AddRange(sge.Factions.FationNames.ToArray());
                comboBoxFaction.SelectedItem = comboBoxFaction.Items[comboBoxFaction.Items.IndexOf("player")];
                comboBoxFaction.SelectedIndexChanged += comboBoxFaction_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                comboBoxFaction.SelectedIndexChanged -= comboBoxFaction_SelectedIndexChanged;
                comboBoxFaction.SelectedIndexChanged += comboBoxFaction_SelectedIndexChanged;
                Logger.Error("Unable to retrieve the list for the faction drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the faction drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchData.Faction = comboBoxFaction.SelectedItem.ToString();
            treeViewNavigation.Nodes.Clear();
            sge.Galaxy.GetTreeView(treeViewNavigation.Nodes, SearchData);
        }

        private void treeViewNavigation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (subForm != null)
            {
                splitContainerMain.Panel2.Controls.Remove(subForm);
                ((FormShipEditor)subForm).RemoveInstance();
                subForm = null;
            }

            if (e.Node.Tag.GetType().ToString() == "X_Rebirth_Save_Game_Editor.DataStructure.ShipData")
            {
                subForm = FormShipEditor.Instance((ShipData)e.Node.Tag, cde);
                subForm.TopLevel = false;
                splitContainerMain.Panel2.Controls.Add(subForm);
                subForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                subForm.Dock = DockStyle.Fill;
                ((FormShipEditor)subForm).ChangeFormState();
                subForm.Show();
            }
        }
    }
}
