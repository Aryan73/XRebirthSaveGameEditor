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
            try
            {
                dataGridNeeded.DataSource = Ship.GetNeededRessources();
                dataGridNeeded.Enabled = false; // User don't have to use it, just read.
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve needed ressources", ex);
                dataGridNeeded.Enabled = false;
            }
        }

        public void ResizeElements()
        {
        }
        #endregion
    }
}
