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
    public partial class FormSaveGameInfo : Form
    {
        #region Members
        static FormSaveGameInfo instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        string StandardErrorText;
        #endregion

        #region Constructors
        private FormSaveGameInfo()
        {
        }

        private FormSaveGameInfo(SaveGameEditor sge, string standardErrorText)
        {
            InitializeComponent();
            this.sge = sge;
            StandardErrorText = standardErrorText;
        }
        #endregion

        #region Functions
        public static FormSaveGameInfo Instance(SaveGameEditor sge, string standardErrorText)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormSaveGameInfo(sge, standardErrorText);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
            labelSaveGameName.Text = "Save game name: " + sge.SaveGameInfo.SaveGameName;
            labelSaveGameDate.Text = "Save game date: " + sge.SaveGameInfo.SaveGameDate;
            labelGameCurrentVersion.Text = "Game current version: " + sge.SaveGameInfo.GameCurrentVersion + " - " + sge.SaveGameInfo.GameCurrentBuild;
            labelGameCreationVersion.Text = "Game creation version: " + sge.SaveGameInfo.GameCreationVersion;
            labelGameStart.Text = "Game start: " + sge.SaveGameInfo.GameStart;
            labelGameTime.Text = "Game time: " + sge.SaveGameInfo.GameTime;
            dataGridViewMods.DataSource = sge.SaveGameInfo.Patches; 
            
            try
            {
                textBoxPlayerName.Text = sge.SaveGameInfo.PlayerName;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve player name", ex);
                textBoxPlayerName.Text = "Error";
            }
            try
            {
                textBoxPlayerMoney.Text = sge.PlayerMoney;
                textBoxPlayerMoney.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to retrieve player money", ex);
                textBoxPlayerMoney.Text = "Error";
                textBoxPlayerMoney.Enabled = false;
            }
        }

        public void ResizeElements()
        {
            splitContainer1.SplitterDistance = 80;
            splitContainer2.SplitterDistance = splitContainer2.Height - 25;
            splitContainer3.SplitterDistance = splitContainer3.Width / 2;
        }
        #endregion

        #region Events
        private void textBoxPlayerMoney_Leave(object sender, EventArgs e)
        {
            if (sge.SaveGameLoaded)
            {
                try
                {
                    Convert.ToInt64(textBoxPlayerMoney.Text);

                    try
                    {
                        sge.PlayerMoney = textBoxPlayerMoney.Text;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to set the player money.", ex);
                        MessageBox.Show("Unable to set the player money." + "\n" + StandardErrorText);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warning("Unable to change the money, the value is not a valid integer.", ex);
                    MessageBox.Show("Unable to change the money, the value is not a valid integer." + "\n" + StandardErrorText);
                }
            }
            else
            {
                Logger.Warning("textBoxPlayerMoney_Leave: Unable to perform change. Save Game is not completely loaded yet.");
            }
        }

        private void buttonRemMod_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMods.SelectedRows)
            {
                sge.SaveGameInfo.RemovePatch((PatchInfoData)row.DataBoundItem);
            }

            dataGridViewMods.DataSource = null;
            dataGridViewMods.DataSource = sge.SaveGameInfo.Patches;
        }
        #endregion
    }
}
