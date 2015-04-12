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
    public partial class FormShipEditor : Form
    {
        #region Members
        static FormShipEditor instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        ShipData Ship = null;
        FormShipEditorInfo ShipInfoForm = null;
        #endregion

        #region Constructors
        private FormShipEditor()
        {
            InitializeComponent();
        }

        private FormShipEditor(ShipData ship, CatDatExtractor cde)
        {
            InitializeComponent();
            Ship = ship;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormShipEditor Instance(ShipData ship, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormShipEditor(ship, cde);
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
                    ShipInfoForm.RemoveInstance();
                    ShipInfoForm = null;
                    instance = null;
                }
            }
        }

        public void ChangeFormState()
        {
            if (ShipInfoForm == null)
            {
                ShipInfoForm = FormShipEditorInfo.Instance(Ship, cde);
                ShipInfoForm.TopLevel = false;
                tabPageShipInfo.Controls.Add(ShipInfoForm);
                ShipInfoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                ShipInfoForm.Dock = DockStyle.Fill;
                ShipInfoForm.ChangeFormState();
                ShipInfoForm.Show();
            }
        }

        public void ResizeElements()
        {
        }
        #endregion
    }
}
