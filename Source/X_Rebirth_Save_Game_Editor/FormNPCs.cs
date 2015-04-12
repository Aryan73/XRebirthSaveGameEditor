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
    public partial class FormNPCs : Form
    {
        #region Members
        static FormNPCs instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        CatDatExtractor cde = null;
        string StandardErrorText = "";
        #endregion

        #region Constructors
        private FormNPCs()
        {
        }

        private FormNPCs(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            InitializeComponent();
            this.sge = sge;
            this.cde = cde;
            StandardErrorText = standardErrorText;
        }
        #endregion

        #region Functions
        public static FormNPCs Instance(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormNPCs(sge, cde, standardErrorText);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
            comboBoxFaction_DropDown(null, null);
            if (comboBoxFaction.Items.Contains("player"))
            {
                comboBoxFaction.SelectedItem = comboBoxFaction.SelectedItem = "player";
            }

            comboBoxTypes.Items.AddRange(sge.NPCs.GetAllTypes().ToArray());
        }

        public void ResizeElements()
        {
            int split = splitContainer6.Height / 3;
            splitContainer1.SplitterDistance = 175;
            splitContainer2.SplitterDistance = splitContainer2.Height - 240;
            splitContainer3.SplitterDistance = 25;
            splitContainer4.SplitterDistance = 75;
            splitContainer5.SplitterDistance = splitContainer5.Width - 100;
            splitContainer6.SplitterDistance = split;
            splitContainer22.SplitterDistance = split;
            split = 25;
            splitContainer23.SplitterDistance = split;

            splitContainer7.SplitterDistance = split;
            splitContainer8.SplitterDistance = split;
            splitContainer9.SplitterDistance = split;
            splitContainer10.SplitterDistance = split;
            splitContainer11.SplitterDistance = split;
            splitContainer12.SplitterDistance = split;
            splitContainer13.SplitterDistance = split;
            split = 50;
            splitContainer14.SplitterDistance = split;
            splitContainer15.SplitterDistance = split;
            splitContainer16.SplitterDistance = split;
            splitContainer17.SplitterDistance = split;
            splitContainer18.SplitterDistance = split;
            splitContainer19.SplitterDistance = split;
            splitContainer20.SplitterDistance = split;
            splitContainer21.SplitterDistance = split;

        }
        #endregion

        private void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxFaction.SelectedItem != null
                    && comboBoxFaction.Items.Contains(comboBoxFaction.SelectedItem)
                    )
                {
                    dataGridViewNPCs.DataSource = null;
                    dataGridViewNPCs.DataSource = sge.NPCs[(string)comboBoxFaction.SelectedItem];
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

        private void buttonUpdateSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewNPCs.SelectedRows)
            {
                NPCData npc = (NPCData)row.DataBoundItem;
                if (!string.IsNullOrEmpty(textBoxBoarding.Text))
                {
                    npc.Boarding = ushort.Parse(textBoxBoarding.Text);
                }
                if (!string.IsNullOrEmpty(textBoxCombat.Text))
                {
                    npc.Combat = ushort.Parse(textBoxCombat.Text);
                }
                if (!string.IsNullOrEmpty(textBoxEngineering.Text))
                {
                    npc.Engineering = ushort.Parse(textBoxEngineering.Text);
                }
                if (!string.IsNullOrEmpty(textBoxLeadership.Text))
                {
                    npc.Leadership = ushort.Parse(textBoxLeadership.Text);
                }
                if (!string.IsNullOrEmpty(textBoxManagement.Text))
                {
                    npc.Management = ushort.Parse(textBoxManagement.Text);
                }
                if (!string.IsNullOrEmpty(textBoxMorale.Text))
                {
                    npc.Morale = ushort.Parse(textBoxMorale.Text);
                }
                if (!string.IsNullOrEmpty(textBoxNavigation.Text))
                {
                    npc.Navigation = ushort.Parse(textBoxNavigation.Text);
                }
                if (!string.IsNullOrEmpty(textBoxScience.Text))
                {
                    npc.Science = ushort.Parse(textBoxScience.Text);
                }
            }
            dataGridViewNPCs.DataSource = null;
            dataGridViewNPCs.DataSource = sge.NPCs[(string)comboBoxFaction.SelectedItem];
        }

        private void buttonUpdateAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewNPCs.Rows)
            {
                NPCData npc = (NPCData)row.DataBoundItem;
                if (!string.IsNullOrEmpty(textBoxBoarding.Text))
                {
                    npc.Boarding = ushort.Parse(textBoxBoarding.Text);
                }
                if (!string.IsNullOrEmpty(textBoxCombat.Text))
                {
                    npc.Combat = ushort.Parse(textBoxCombat.Text);
                }
                if (!string.IsNullOrEmpty(textBoxEngineering.Text))
                {
                    npc.Engineering = ushort.Parse(textBoxEngineering.Text);
                }
                if (!string.IsNullOrEmpty(textBoxLeadership.Text))
                {
                    npc.Leadership = ushort.Parse(textBoxLeadership.Text);
                }
                if (!string.IsNullOrEmpty(textBoxManagement.Text))
                {
                    npc.Management = ushort.Parse(textBoxManagement.Text);
                }
                if (!string.IsNullOrEmpty(textBoxMorale.Text))
                {
                    npc.Morale = ushort.Parse(textBoxMorale.Text);
                }
                if (!string.IsNullOrEmpty(textBoxNavigation.Text))
                {
                    npc.Navigation = ushort.Parse(textBoxNavigation.Text);
                }
                if (!string.IsNullOrEmpty(textBoxScience.Text))
                {
                    npc.Science = ushort.Parse(textBoxScience.Text);
                }
            }
            dataGridViewNPCs.DataSource = null;
            dataGridViewNPCs.DataSource = sge.NPCs[(string)comboBoxFaction.SelectedItem];
        }

        private void textBoxBoarding_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!(t.Text == "0"
                || t.Text == "1"
                || t.Text == "2"
                || t.Text == "3"
                || t.Text == "4"
                || t.Text == "5"
                ))
            {
                t.Text = "";
            }
        }

        private void buttonUpdateType_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewNPCs.Rows)
            {
                NPCData npc = (NPCData)row.DataBoundItem;
                if (npc.Type == comboBoxTypes.Text)
                {
                    if (!string.IsNullOrEmpty(textBoxBoarding.Text))
                    {
                        npc.Boarding = ushort.Parse(textBoxBoarding.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxCombat.Text))
                    {
                        npc.Combat = ushort.Parse(textBoxCombat.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxEngineering.Text))
                    {
                        npc.Engineering = ushort.Parse(textBoxEngineering.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxLeadership.Text))
                    {
                        npc.Leadership = ushort.Parse(textBoxLeadership.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxManagement.Text))
                    {
                        npc.Management = ushort.Parse(textBoxManagement.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxMorale.Text))
                    {
                        npc.Morale = ushort.Parse(textBoxMorale.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxNavigation.Text))
                    {
                        npc.Navigation = ushort.Parse(textBoxNavigation.Text);
                    }
                    if (!string.IsNullOrEmpty(textBoxScience.Text))
                    {
                        npc.Science = ushort.Parse(textBoxScience.Text);
                    }
                }
            }
            dataGridViewNPCs.DataSource = null;
            dataGridViewNPCs.DataSource = sge.NPCs[(string)comboBoxFaction.SelectedItem];
        }
    }
}
