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

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormKnownTypes : Form
    {
        #region Members
        static FormKnownTypes instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        CatDatExtractor cde = null;
        string StandardErrorText = "";
        #endregion

        #region Constructors
        private FormKnownTypes()
        {
        }

        private FormKnownTypes(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            InitializeComponent();
            this.sge = sge;
            this.cde = cde;
            StandardErrorText = standardErrorText;
        }
        #endregion

        #region Functions
        public static FormKnownTypes Instance(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormKnownTypes(sge, cde, standardErrorText);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
            try
            {
                comboBoxKnownTypes.Items.Clear();
                comboBoxKnownTypes.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypesCategories().ToArray());
                comboBoxKnownTypes.SelectedIndex = 0;
                comboBoxKnownTypes.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve known type categories", ex);
                comboBoxKnownTypes.Text = "Error";
                comboBoxKnownTypes.Enabled = false;
            }
            try
            {
                listBoxKnownTypes.Items.Clear();
                listBoxKnownTypes.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypes(comboBoxKnownTypes.Text).ToArray());
                listBoxKnownTypes.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve known types", ex);
                listBoxKnownTypes.Text = "Error";
                listBoxKnownTypes.Enabled = false;
            }
        }

        public void ResizeElements()
        {
            int splitpos = this.Width / 2 + 10;
            splitContainer1.SplitterDistance = 25;
            splitContainer2.SplitterDistance = splitpos;
            splitContainer3.SplitterDistance = splitpos;
            splitpos = splitpos - 20;
            splitContainer4.SplitterDistance = splitpos;
            splitContainer5.SplitterDistance = splitpos;
        }
        #endregion

        #region Events
        private void comboBoxKnownTypes_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxKnownTypes.Items.Clear();
                comboBoxKnownTypes.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypesCategories().ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error("comboBoxKnownTypes_DropDown: Unable to retrieve comboBoxKnownTypes.", ex);
            }
        }

        private void comboBoxKnownTypes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxKnownTypes.Items.Contains(comboBoxKnownTypes.Text))
                {
                    listBoxKnownTypes.Items.Clear();
                    listBoxKnownTypes.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypes(comboBoxKnownTypes.Text).ToArray());
                    listBoxUnknownTypes.Items.Clear();
                    listBoxUnknownTypes.Items.AddRange(cde.GetAllTypesInCategory(comboBoxKnownTypes.Text).Where(a => !listBoxKnownTypes.Items.Contains(a.Key)).Select(a => a.Value + "/" + a.Key).ToArray());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the known list.", ex);
                MessageBox.Show("Unable to set the known list." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxUnknownTypesList_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxKnownTypes_DropDown(null, null);
                comboBoxUnknownTypesList.Items.Clear();
                comboBoxUnknownTypesList.Items.AddRange(cde.GetAllTypesCategories().Where(a => !comboBoxKnownTypes.Items.Contains(a)).ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error("comboBoxUnknownTypesList_DropDown: Unable to update drop down box.", ex, true);
            }
        }

        private void buttonAddKnownTypes_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxKnownTypes.Items.Contains(comboBoxKnownTypes.Text))
                {
                    List<string> items = new List<string>();
                    foreach (string item in listBoxUnknownTypes.SelectedItems)
                    {
                        items.Add(item.Split('/').Last());
                    }

                    sge.Galaxy.GetPlayer().AddKnownTypesToCategory(comboBoxKnownTypes.Text, items);

                    comboBoxKnownTypes_TextChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to add types to category.", ex);
            }
        }

        private void buttonAddKnownTypeList_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUnknownTypesList.Items.Contains(comboBoxUnknownTypesList.Text))
                {
                    sge.Galaxy.GetPlayer().AddKnownTypeCategory(comboBoxUnknownTypesList.Text);
                    comboBoxUnknownTypesList_DropDown(null, null);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("buttonAddKnownTypeList_Click: Unable to add known type category.", ex, true);
            }
        }
        #endregion
    }
}
