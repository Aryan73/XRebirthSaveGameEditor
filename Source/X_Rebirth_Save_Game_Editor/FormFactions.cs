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
    public partial class FormFactions : Form
    {
        #region Members
        static FormFactions instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        FactionData Previousfaction = null;
        string StandardErrorText = "";
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        private FormFactions()
        {
        }

        private FormFactions(SaveGameEditor sge, string standardErrorText, CatDatExtractor cde)
        {
            InitializeComponent();
            this.sge = sge;
            StandardErrorText = standardErrorText;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public static FormFactions Instance(SaveGameEditor sge, string standardErrorText, CatDatExtractor cde)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormFactions(sge, standardErrorText, cde);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
        }

        public void ResizeElements()
        {
            splitContainer1.SplitterDistance = 25;
            splitContainer2.SplitterDistance = splitContainer2.Width / 2;
            int splitdis = splitContainerLicenses.Height - 60;
            splitContainerLicenses.SplitterDistance = splitdis;
            splitContainerRelations.SplitterDistance = splitdis;
            splitContainer3.SplitterDistance = 30;
            splitContainer4.SplitterDistance = 75;
            splitContainer5.SplitterDistance = 75;
            splitContainer6.SplitterDistance = 30;
            splitContainer7.SplitterDistance = 75;
            splitContainer8.SplitterDistance = 75;
        }
        #endregion

        private void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Previousfaction != null)
                {
                    Previousfaction.UpdateRelationPartners();
                }
                if (comboBoxFaction.SelectedItem != null
                    && comboBoxFaction.Items.Contains(comboBoxFaction.SelectedItem)
                    )
                {
                    Previousfaction = null;
                    dataGridViewRelations.DataSource = null;
                    dataGridViewLicenses.DataSource = null;
                    FactionData faction = sge.Factions[(string)comboBoxFaction.SelectedItem];

                    if (faction != null)
                    {
                        dataGridViewRelations.DataSource = faction.Relations;
                        dataGridViewLicenses.DataSource = faction.Licences;
                        Previousfaction = (string)comboBoxFaction.SelectedItem;
                        comboBox1.Items.AddRange(cde.GetAllFactions().Where(a => a != comboBoxFaction.Text && !((List<RelationData>)dataGridViewRelations.DataSource).Exists(b => b.faction == a)).ToArray());
                    }
                }
                else
                {
                    Previousfaction = null;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks engine.", ex);
                MessageBox.Show("Unable to set the skunks engine." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxFaction_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxFaction.SelectedIndexChanged -= comboBoxFaction_SelectedIndexChanged;
                comboBoxFaction.SelectedIndexChanged -= comboBoxFaction_SelectedIndexChanged;
                comboBoxFaction.Items.Clear();
                comboBoxFaction.Items.AddRange(sge.Factions.FationNames.ToArray());
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

        private void buttonAddRelation_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null || comboBox1.Items.Contains(comboBox1.SelectedItem))
            {
                MessageBox.Show("valid value must be selected from combobox");
                return;
            }

            float f;
            if (float.TryParse(textBox1.Text, out f))
            {
                sge.Factions[comboBoxFaction.Text].AddRelation(comboBox1.Text, f);
                comboBox1.Text = "";
                textBox1.Text = "";
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(cde.GetAllFactions().Where(a => a != comboBoxFaction.Text && !((List<RelationData>)dataGridViewRelations.DataSource).Exists(b => b.faction == a)).ToArray());
                dataGridViewRelations.DataSource = null;
                dataGridViewRelations.DataSource = sge.Factions[(string)comboBoxFaction.SelectedItem].Relations;
            }
            else
            {
                MessageBox.Show("has to be a number");
            }
        }

        private void buttonRemoveRelation_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewRelations.SelectedRows)
            {
                sge.Factions[comboBoxFaction.Text].RemoveRelation((RelationData)row.DataBoundItem);
            }
            dataGridViewRelations.DataSource = null;
            dataGridViewRelations.DataSource = sge.Factions[(string)comboBoxFaction.SelectedItem].Relations;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.AddRange(cde.GetAllLicenceTypes().ToArray());
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            if (comboBoxFaction.SelectedItem != null
                && comboBoxFaction.Items.Contains(comboBoxFaction.SelectedItem)
                && comboBox2.Items.Contains(comboBox2.Text))
            {
                List<LicenceData> ls = sge.Factions[comboBoxFaction.Text].Licences;
                List<string> f = new List<string>();
                if (ls.Exists(a => a.Type == comboBox2.Text))
                {
                    f .AddRange(ls.First(a => a.Type == comboBox2.Text).Factions.Split(' '));
                }
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(cde.GetAllFactionForLicense(comboBox2.Text).Where(a => !f.Exists(b => b == a)).ToArray());
            }
        }

        private void buttonRemoveLicense_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewLicenses.SelectedRows)
            {
                sge.Factions[comboBoxFaction.Text].RemoveLicence((LicenceData)row.DataBoundItem);
            }
            dataGridViewLicenses.DataSource = null;
            dataGridViewLicenses.DataSource = sge.Factions[(string)comboBoxFaction.SelectedItem].Licences;
        }

        private void buttonAddLicense_Click(object sender, EventArgs e)
        {
            if (comboBox3.Items.Contains(comboBox3.Text)
                && comboBox2.Items.Contains(comboBox2.Text)
                )
            {
                sge.Factions[comboBoxFaction.Text].AddLicence(comboBox2.Text, comboBox3.Text);
                comboBox3_DropDown(null, null);
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.Text = comboBox3.Items[0].ToString();
                }
                else
                {
                    comboBox3.Text = "";
                }
                dataGridViewLicenses.DataSource = null;
                dataGridViewLicenses.DataSource = sge.Factions[(string)comboBoxFaction.SelectedItem].Licences;
            }
        }

        // License governments are devided by spaces
    }
}
