using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Rebirth_Save_Game_Editor.Logging;
using X_Rebirth_Save_Game_Editor.DataStructure;

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormShipEditorCargo : Form
    {
        #region Members
        static FormShipEditorCargo instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        ShipData Ship = null;
        #endregion

        #region Constructors
        private FormShipEditorCargo()
        {
            InitializeComponent();
        }

        private FormShipEditorCargo(ShipData ship, CatDatExtractor cde)
        {
            InitializeComponent();
            Ship = ship;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormShipEditorCargo Instance(ShipData ship, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormShipEditorCargo(ship, cde);
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
                    Ship = null;
                    instance = null;
                }
            }
        }

        public void ChangeFormState()
        {
            // Part related to Cargo
            try
            {
                dataGridViewCargo.DataSource = Ship.GetStoredItem();
                if (dataGridViewCargo.DataSource != null)
                {
                    dataGridViewCargo.Enabled = true;
                    buttonCargoAdd.Enabled = false;
                    buttonCargoDelete.Enabled = false;
                }
                else
                {
                    dataGridViewCargo.Enabled = false;
                    buttonCargoAdd.Enabled = false;
                    buttonCargoDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve needed ressources", ex);
                dataGridViewCargo.Enabled = false;
                FillCargoNeeded.Enabled = true;
            }
            // Part related to CV ships
            try
            {
                dataGridNeeded.DataSource = Ship.GetNeededRessources();
                if (dataGridNeeded.DataSource != null)
                {
                    dataGridNeeded.Enabled  = true;
                    FillCargoNeeded.Enabled = true;
                }
                else
                {
                    dataGridNeeded.Enabled  = false;
                    FillCargoNeeded.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve needed ressources", ex);
                dataGridNeeded.Enabled = false;
                FillCargoNeeded.Enabled = true;
            }
        }

        public void ResizeElements()
        {
        }
        #endregion

        private void FillCargoNeeded_Click(object sender, EventArgs e)
        {
            Ship.FillNeededRessources();
        }
    }
}