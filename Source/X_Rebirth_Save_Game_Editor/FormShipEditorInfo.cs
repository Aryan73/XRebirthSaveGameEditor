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
    public partial class FormShipEditorInfo : Form
    {
        #region Members
        static FormShipEditorInfo instance = null;
        static object LockInstance = new object();
        CatDatExtractor cde = null;
        ShipData Ship = null;
        #endregion

        #region Constructors
        private FormShipEditorInfo()
        {
            InitializeComponent();
        }

        private FormShipEditorInfo(ShipData ship, CatDatExtractor cde)
        {
            InitializeComponent();
            Ship = ship;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormShipEditorInfo Instance(ShipData ship, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormShipEditorInfo(ship, cde);
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
            textBoxShipName.Text = Ship.ShipName;
            textBoxShipMacro.Text = Ship.ShipMacro;
            textBoxShipClass.Text = Ship.ShipClass;
            textBoxShipId.Text = Ship.ShipId;
            textBoxShipKnownTo.Text = Ship.ShipKnownTo;
            textBoxShipConnection.Text = Ship.ShipConnection;

            comboBoxShipOwner.Items.AddRange(cde.GetAllFactions().ToArray());
            comboBoxShipOwner.SelectedItem = Ship.ShipOwner;
        }

        public void ResizeElements()
        {
        }
        #endregion

        private void textBoxShipName_TextChanged(object sender, EventArgs e)
        {
            Ship.ShipName = textBoxShipName.Text;
        }

        private void comboBoxShipOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ship.ShipOwner = comboBoxShipOwner.SelectedItem.ToString();
        }
    }
}
