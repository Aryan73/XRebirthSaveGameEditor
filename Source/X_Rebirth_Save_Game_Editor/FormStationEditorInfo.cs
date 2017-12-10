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

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormStationEditorInfo : Form
    {
        #region Members
        static FormStationEditorInfo instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        StationData Station = null;
        #endregion

        #region Constructors
        private FormStationEditorInfo()
        {
            InitializeComponent();
        }

        private FormStationEditorInfo(StationData station, CatDatExtractor cde)
        {
            InitializeComponent();
            Station = station;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormStationEditorInfo Instance(StationData station, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormStationEditorInfo(station, cde);
                }

                return instance;
            }
        }

        public void RemoveInstance()
        {
            lock (LockInstance)
            {
                if (instance != null)
                {
                    Station = null;
                    instance = null;
                }
            }
        }

        public void ChangeFormState()
        {
            textBoxStationName.Text = Station.StationName;
            textBoxStationMacro.Text = Station.StationMacro;
            textBoxStationId.Text = Station.StationId;
            textBoxStationKnownTo.Text = Station.StationKnownTo;

            comboBoxStationOwner.Items.AddRange(cde.GetAllFactions().ToArray());
            comboBoxStationOwner.SelectedItem = Station.StationOwner;
        }

        public void ResizeElements()
        {
        }
        #endregion

        private void textBoxStationName_TextChanged(object sender, EventArgs e)
        {
            Station.StationName = textBoxStationName.Text;
        }

        private void comboBoxStationOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Station.StationOwner = comboBoxStationOwner.SelectedItem.ToString();
        }
    }
}
