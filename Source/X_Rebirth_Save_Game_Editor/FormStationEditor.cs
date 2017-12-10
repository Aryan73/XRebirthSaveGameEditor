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
    public partial class FormStationEditor : Form
    {
        #region Members
        static FormStationEditor instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        StationData Station = null;
        FormStationEditorInfo StationInfoForm = null;
        //FormStationEditorCargo StationCargoForm = null;
        #endregion

        #region Constructors
        public FormStationEditor()
        {
            InitializeComponent();
        }

        private FormStationEditor(StationData station, CatDatExtractor cde)
        {
            InitializeComponent();
            Station = station;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormStationEditor Instance(StationData station, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormStationEditor(station, cde);
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
                    StationInfoForm.RemoveInstance();
                    StationInfoForm = null;
                    //StationCargoForm.RemoveInstance();
                    //StationCargoForm = null;
                    instance = null;
                }
            }
        }

        public void ChangeFormState()
        {
            if (StationInfoForm == null)
            {
                StationInfoForm = FormStationEditorInfo.Instance(Station, cde);
                StationInfoForm.TopLevel = false;
                tabPageStationInfo.Controls.Add(StationInfoForm);
                StationInfoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                StationInfoForm.Dock = DockStyle.Fill;
                StationInfoForm.ChangeFormState();
                StationInfoForm.Show();
            }
            //if (StationCargoForm == null)
            //{
            //    StationCargoForm = FormStationEditorCargo.Instance(Station, cde);
            //    StationCargoForm.TopLevel = false;
            //    tabPageStationCargo.Controls.Add(StationCargoForm);
            //    StationCargoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //    StationCargoForm.Dock = DockStyle.Fill;
            //    StationCargoForm.ChangeFormState();
            //    StationCargoForm.Show();
            //}
        }
        #endregion
    }
}
