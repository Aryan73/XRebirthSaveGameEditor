using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Rebirth_Save_Game_Editor.Helper;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormXRebirthSaveGameEditor : Form
    {        
        #region Members
        SaveGameEditor sge = null;
        CatDatExtractor cde = null;
        string StandardErrorText = "Please provide a link to the logfile and save file in the thread http://forum.egosoft.com/viewtopic.php?p=4478039#4478039 or PM Nemesis1982 with the information.";
        string XRebirthPath = null;
        FormCatDatExport CatDatExtractorForm = null;
        FormSaveGameInfo SaveGameInfoForm = null;
        FormKnownTypes KnownTypesForm = null;
        FormPlayerSkunk PlayerSkunkForm = null;
        FormFactions FactionsForm = null;
        FormNPCs NPCsForm = null;
        FormUniverseEditor UniverseEditorForm = null;
        SmartClientHandling SmartClient = null;
        #endregion

        #region Constructor
        public FormXRebirthSaveGameEditor()
        {
            Logger.Verbose("Starting Application.");
            InitializeComponent();
            try
            {
                SmartClient = new SmartClientHandling(30000);
                this.Text += " v" + SmartClient.GetVersionInfo();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to start the auto update feature.", ex);
            }

            try
            {
                ChangeFormState();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to start the application.", ex);
                MessageBox.Show("Unable to start the application." + "\n" + StandardErrorText);
            }

            try
            {
                FindRebirthPath();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve X Rebirth path.", ex);
            }

            FormXRebirthSaveGameEditor_Resize(null, null);
            Logger.Verbose("Application v" + SmartClient.GetVersionInfo() + " Started. " + (SmartClient.IsNetworkDeployed() ? "Network deployed version." : "Non network deployed version."));
        }
        #endregion

        #region Methods
        string SearchForRebirthPath(string folder)
        {

            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.EndsWith("XRebirth.exe"))
                {
                    return file;
                }
            }
            foreach (string subDir in Directory.GetDirectories(folder))
            {
                try
                {
                    string f = SearchForRebirthPath(subDir);
                    if (!string.IsNullOrEmpty(f))
                    {
                        return f;
                    }
                }
                catch
                {
                    // swallow, log, whatever
                }
            }

            return string.Empty;
        }

        void FindRebirthPath(bool forceBorwse = false)
        {
            XRebirthPath = null;
            if (!forceBorwse)
            {
                string savedPath = Properties.Settings.Default.XRebirthPath;
                if (string.IsNullOrEmpty(savedPath))
                {
                    DialogResult dr = MessageBox.Show("No X Rebirth path set. Should I try to find it for you? This may take a few minutes.", "Search for X Rebirth path?", MessageBoxButtons.YesNo);

                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<string> rebirthPaths = new List<string>();

                        Char atoz = 'A';
                        while (atoz <= 'Z' && rebirthPaths.Count <= 0)
                        {
                            try
                            {
                                if (Directory.Exists(atoz + ":\\"))
                                {
                                    XRebirthPath = SearchForRebirthPath(atoz + ":\\");
                                }
                            }
                            catch
                            {
                            }

                            if (!string.IsNullOrEmpty(XRebirthPath))
                            {
                                Properties.Settings.Default.XRebirthPath = XRebirthPath;
                                Properties.Settings.Default.Save();
                                break;
                            }
                            atoz++;
                        }
                    }
                }
                else
                {
                    XRebirthPath = savedPath;
                }

                if (!string.IsNullOrEmpty(XRebirthPath))
                {
                    labelBrowseXR.Text = XRebirthPath;
                    LoadCatDatExtractor();
                }
            }

            if (string.IsNullOrEmpty(XRebirthPath))
            {
                MessageBox.Show("Please select the X-Rebirth executable. This is needed for functionality.");
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.FileOk += ofd_FileOk1;
                ofd.ShowDialog();
            }
        }

        private void ofd_FileOk1(object sender, CancelEventArgs e)
        {
            string fn = ((OpenFileDialog)sender).FileName;
            if (fn != null
                || fn.ToLower().EndsWith("xrebirth.exe")
                )
            {
                XRebirthPath = fn;
                labelBrowseXR.Text = XRebirthPath;
                Properties.Settings.Default.XRebirthPath = XRebirthPath;
                Properties.Settings.Default.Save();
                LoadCatDatExtractor();
            }
        }

        private void LoadCatDatExtractor()
        {
            if (CatDatExtractorForm == null)
            {
                cde = new CatDatExtractor(XRebirthPath);
                CatDatExtractorForm = FormCatDatExport.Instance(cde);
                CatDatExtractorForm.TopLevel = false;
                tabPageCatDatExtractor.Controls.Add(CatDatExtractorForm);
                CatDatExtractorForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                CatDatExtractorForm.Dock = DockStyle.Fill;
                CatDatExtractorForm.Show();
                ChangeFormState();
            }
            else
            {
                Logger.Warning("FormCatDatExtractor already loaded.");
            }
        }

        void ChangeFormState()
        {
            try
            {
                #region Save game related
                if (sge != null
                    && sge.XMLLoaded()
                    )
                {
                    // Bind Save Game Screens to tabs is not already done
                    if (SaveGameInfoForm == null)
                    {
                        SaveGameInfoForm = FormSaveGameInfo.Instance(sge, StandardErrorText);
                        SaveGameInfoForm.TopLevel = false;
                        tabPageGameInfo.Controls.Add(SaveGameInfoForm);
                        SaveGameInfoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        SaveGameInfoForm.Dock = DockStyle.Fill;
                        SaveGameInfoForm.Show();
                    }

                    if (PlayerSkunkForm == null)
                    {
                        PlayerSkunkForm = FormPlayerSkunk.Instance(sge, cde, StandardErrorText);
                        PlayerSkunkForm.TopLevel = false;
                        tabPageSkunk.Controls.Add(PlayerSkunkForm);
                        PlayerSkunkForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        PlayerSkunkForm.Dock = DockStyle.Fill;
                        PlayerSkunkForm.Show();
                    }

                    if (FactionsForm == null)
                    {
                        FactionsForm = FormFactions.Instance(sge, StandardErrorText, cde);
                        FactionsForm.TopLevel = false;
                        tabPageFactions.Controls.Add(FactionsForm);
                        FactionsForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        FactionsForm.Dock = DockStyle.Fill;
                        FactionsForm.Show();
                    }

                    if (NPCsForm == null)
                    {
                        NPCsForm = FormNPCs.Instance(sge, cde, StandardErrorText);
                        NPCsForm.TopLevel = false;
                        tabPageNPCs.Controls.Add(NPCsForm);
                        NPCsForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        NPCsForm.Dock = DockStyle.Fill;
                        NPCsForm.Show();
                    }

                    if (UniverseEditorForm == null)
                    {
                        UniverseEditorForm = FormUniverseEditor.Instance(sge, StandardErrorText, cde);
                        UniverseEditorForm.TopLevel = false;
                        tabPageUniverseEditor.Controls.Add(UniverseEditorForm);
                        UniverseEditorForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        UniverseEditorForm.Dock = DockStyle.Fill;
                        UniverseEditorForm.Show();
                    }

                    if (KnownTypesForm == null)
                    {
                        KnownTypesForm = FormKnownTypes.Instance(sge, cde, StandardErrorText);
                        KnownTypesForm.TopLevel = false;
                        tabPageKnownTypes.Controls.Add(KnownTypesForm);
                        KnownTypesForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        KnownTypesForm.Dock = DockStyle.Fill;
                        KnownTypesForm.Show();
                    }

                    // Enable buttons
                    buttonSave.Enabled = true;
                    buttonUnload.Enabled = true;

                    // Enable and display tabs
                    if (!tabControlMain.TabPages.Contains(tabPageGameInfo))
                    {
                        tabControlMain.TabPages.Insert(0, tabPageGameInfo);
                        tabControlMain.TabPages.Insert(1, tabPageKnownTypes);
                        tabControlMain.TabPages.Insert(2, tabPageSkunk);
                        tabControlMain.TabPages.Insert(3, tabPageFactions);
                        tabControlMain.TabPages.Insert(4, tabPageNPCs);
                        tabControlMain.TabPages.Insert(5, tabPageUniverseEditor);
                        tabControlMain.SelectedIndex = 0;
                    }

                    // Change children form states
                    SaveGameInfoForm.ChangeFormState();
                    KnownTypesForm.ChangeFormState();
                    PlayerSkunkForm.ChangeFormState();
                    FactionsForm.ChangeFormState();
                    NPCsForm.ChangeFormState();
                    UniverseEditorForm.ChangeFormState();
                }
                else
                {
                    buttonSave.Enabled = false;
                    buttonUnload.Enabled = false;
                    if (tabControlMain.TabPages.Contains(tabPageGameInfo))
                    {
                        tabControlMain.TabPages.Remove(tabPageGameInfo);
                        tabControlMain.TabPages.Remove(tabPageKnownTypes);
                        tabControlMain.TabPages.Remove(tabPageSkunk);
                        tabControlMain.TabPages.Remove(tabPageNPCs);
                        tabControlMain.TabPages.Remove(tabPageFactions);
                        tabControlMain.TabPages.Remove(tabPageUniverseEditor);
                    }
                }
                #endregion

                #region Cat Dat Extractor related
                if (cde != null)
                {
                    buttonBrowseXR.Enabled = false;
                }
                else
                {
                    buttonBrowseXR.Enabled = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while changing the form state.", ex);
            }
        }
        #endregion

        #region Events
        #region SavevGame Handling
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Logger.Verbose("Browse initiated.");
            try
            {
                if (cde != null)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Multiselect = false;
                    ofd.FileOk += ofd_FileOk;
                    ofd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Before selecting a save game be sure the X Rebirth path is set correctly.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to initiated browse.", ex);
            }
        }

        void ofd_FileOk(object sender, CancelEventArgs e)
        {
            Logger.Verbose("Browse done.");
            try
            {
                labelSaveLocation.Text = ((OpenFileDialog)sender).FileName;
                sge = null;
                sge = new SaveGameEditor(((OpenFileDialog)sender).FileName, cde);
                ChangeFormState();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to load the save game into the editor.", ex);
                MessageBox.Show("Unable to load the save game into the editor." + "\n" + StandardErrorText);
            }
        }

        private void buttonUnload_Click(object sender, EventArgs e)
        {
            Logger.Verbose("Unload initiated.");
            try
            {
                sge.UnloadSaveGame();
                ChangeFormState();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to Unload the save game from the editor.", ex);
                MessageBox.Show("Unable to Unload the save game from the editor." + "\n" + StandardErrorText);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Logger.Verbose("Unload initiated.");
            try
            {
                sge.Save(false, true);
                sge.Save(checkBoxFormatted.Checked);
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to Save the save game.", ex);
                MessageBox.Show("Unable to Save the save game." + "\n" + StandardErrorText);
            }
        }
        #endregion

        #region Cat Dat Extractor handling
        private void buttonBrowseXR_Click(object sender, EventArgs e)
        {
            try
            {
                FindRebirthPath(true);
            }
            catch (Exception ex)
            {
                Logger.Error("buttonBrowseXR_Click: Unable to find rebirth path.", ex, true);
            }
        }
        #endregion

        #region Form
        private void FormXRebirthSaveGameEditor_Resize(object sender, EventArgs e)
        {
            try
            {
                splitContainerTop.SplitterDistance = splitContainerTop.Width / 2;
                if (CatDatExtractorForm != null)
                {
                    CatDatExtractorForm.ResizeElements();
                }
                if (SaveGameInfoForm != null)
                {
                    SaveGameInfoForm.ResizeElements();
                }
                if (KnownTypesForm != null)
                {
                    KnownTypesForm.ResizeElements();
                }
                if (PlayerSkunkForm != null)
                {
                    PlayerSkunkForm.ResizeElements();
                }
                if (FactionsForm != null)
                {
                    FactionsForm.ResizeElements();
                }
                if (NPCsForm != null)
                {
                    NPCsForm.ResizeElements();
                }
                if (UniverseEditorForm != null)
                {
                    UniverseEditorForm.ResizeElements();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to resize.", ex);
            }
        }
        #endregion


        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedTab.Name == "tabPageLog")
                {
                    try
                    {
                        richTextBoxLog.ReadOnly = true;
                        richTextBoxLog.LoadFile(new System.IO.FileStream(Logger.loggingOutputDirectory + "\\" + Logger.loggingOutputFileName.Substring(Logger.loggingOutputFileName.LastIndexOf("\\")), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite), RichTextBoxStreamType.PlainText);
                        richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                        richTextBoxLog.ScrollToCaret();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to load logging into the log viewer.");
                        Logger.Error("Unable to load logging into the log viewer.", ex);
                    }
                }
                else
                {
                    FormXRebirthSaveGameEditor_Resize(null, null);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error occurred while tab selected indez changed.", ex);
            }
        }
        #endregion
    }
}
