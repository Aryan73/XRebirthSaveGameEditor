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
    public partial class FormStationEditorQueued : Form
    {
        #region Members
        static FormStationEditorQueued instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        StationData Station = null;
        #endregion

        #region Constructors
        public FormStationEditorQueued()
        {
            InitializeComponent();
        }

        private FormStationEditorQueued(StationData station, CatDatExtractor cde)
        {
            InitializeComponent();
            Station = station;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormStationEditorQueued Instance(StationData station, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormStationEditorQueued(station, cde);
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
            //textBoxStationName.Text = Station.StationName;
            //textBoxStationMacro.Text = Station.StationMacro;
            //textBoxStationId.Text = Station.StationId;
            //textBoxStationKnownTo.Text = Station.StationKnownTo;

            //comboBoxStationOwner.Items.AddRange(cde.GetAllFactions().ToArray());
            //comboBoxStationOwner.SelectedItem = Station.StationOwner;
        }

        private void comboBoxShipOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Station.StationOwner = comboBoxShipOwner.SelectedItem.ToString();
        }
        #endregion
    }
}
