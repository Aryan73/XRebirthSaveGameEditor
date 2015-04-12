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
using X_Rebirth_Save_Game_Editor.DataStructure;
using X_Rebirth_Save_Game_Editor.Enumarators;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor
{

    /* TODOs:
     * - Make sure to replace all first child with the find child function where first child is assumed
     * - Create more generic search functions and replace reused code
     */
    public partial class Form1 : Form
    {
        #region Members
        SaveGameEditor sge = null;
        CatDatExtractor cde = null;
        string StandardErrorText = "Please provide a link to the logfile and save file in the thread http://forum.egosoft.com/viewtopic.php?p=4478039#4478039 or PM Nemesis1982 with the information.";
        string XRebirthPath = null;
        #endregion

        #region Constructor
        public Form1()
        {
            Logger.Verbose("Starting Application.");
            InitializeComponent();
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
            Logger.Verbose("Application Started.");
            FormXRebirthSaveGameEditor Fnew = new FormXRebirthSaveGameEditor();
            Fnew.Show();
        }
        #endregion

        #region Methods
        void FindRebirthPath(bool forceBorwse = false)
        {
            buttonCatDatExtractor.Enabled = false;
            XRebirthPath = null;

            if (!forceBorwse)
            {
                List<string> rebirthPaths = new List<string>();
                if (Directory.Exists("C:\\Program Files\\Steam\\steamapps\\common\\X Rebirth\\"))
                {
                    rebirthPaths.AddRange(Directory.GetFiles("C:\\Program Files\\Steam\\steamapps\\common\\X Rebirth\\", "XRebirth.exe"));
                }

                if (rebirthPaths.Count <= 0 && Directory.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\X Rebirth\\"))
                {
                    rebirthPaths.AddRange(Directory.GetFiles("C:\\Program Files (x86)\\Steam\\steamapps\\common\\X Rebirth\\", "XRebirth.exe"));
                }

                Char atoz = 'A';
                while (atoz <= 'Z' && rebirthPaths.Count <= 0)
                {
                    if (Directory.Exists(atoz + ":\\"))
                    {
                        rebirthPaths.AddRange(Directory.GetFiles(atoz + ":\\", "XRebirth.exe"));
                    }
                    atoz++;
                }

                List<string> notRebirthPaths = new List<string>();
                if (rebirthPaths.Count() > 0)
                {
                    XRebirthPath = rebirthPaths[0];
                    labelBrowseXR.Text = XRebirthPath;

                    cde = new CatDatExtractor(XRebirthPath);

                    buttonCatDatExtractor.Enabled = true;
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

                cde = new CatDatExtractor(XRebirthPath);

                buttonCatDatExtractor.Enabled = true;
            }
        }

        void ChangeFormState()
        {
            try
            {
                if (sge != null
                    && sge.XMLLoaded()
                    )
                {
                    #region Tab Save Info
                    labelSaveGameName.Text = "Save game name: " + sge.SaveGameInfo.SaveGameName;
                    labelSaveGameDate.Text = "Save game date: " + sge.SaveGameInfo.SaveGameDate;
                    labelGameCurrentVersion.Text = "Game current version: " + sge.SaveGameInfo.GameCurrentVersion + " - " + sge.SaveGameInfo.GameCurrentBuild;
                    labelGameCreationVersion.Text = "Game creation version: " + sge.SaveGameInfo.GameCreationVersion;
                    labelGameStart.Text = "Game start: " + sge.SaveGameInfo.GameStart;
                    labelGameTime.Text = "Game time: " + sge.SaveGameInfo.GameTime;
                    dataGridViewMods.DataSource = sge.SaveGameInfo.Patches;
                    #endregion
                    #region Tab Player and Skunk
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
                    try
                    {
                        comboBoxSkunkScanner_DropDown(null, null);
                        foreach(object o in comboBoxSkunkScanner.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().InstalledScanner.Macro)
                            {
                                comboBoxSkunkScanner.SelectedItem = o;
                                break;
                            }
                        }

                        comboBoxSkunkScanner.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk scanner", ex);
                        comboBoxSkunkScanner.Text = "Error";
                        comboBoxSkunkScanner.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkEngine_DropDown(null, null);

                        foreach (object o in comboBoxSkunkEngine.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().GetInstalledEngine())
                            {
                                comboBoxSkunkEngine.SelectedItem = o;
                                break;
                            }
                        }

                        comboBoxSkunkEngine.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk egine", ex);
                        comboBoxSkunkEngine.Text = "Error";
                        comboBoxSkunkEngine.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkCockpit.Text = sge.Galaxy.GetSkunk().ShipCockpit.Macro;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk cockpit", ex);
                        comboBoxSkunkCockpit.Text = "Error";
                    }
                    try
                    {
                        comboBoxSkunkShield_DropDown(comboBoxSkunkShield1, null);

                        foreach (object o in comboBoxSkunkShield1.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().InstalledShield1)
                            {
                                comboBoxSkunkShield1.SelectedItem = o;
                                break;
                            }
                        }

                        comboBoxSkunkShield1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk shield 1", ex);
                        comboBoxSkunkShield1.Text = "Error";
                        comboBoxSkunkShield1.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkShield_DropDown(comboBoxSkunkShield2, null);

                        foreach (object o in comboBoxSkunkShield2.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().InstalledShield2)
                            {
                                comboBoxSkunkShield2.SelectedItem = o;
                                break;
                            }
                        }

                        comboBoxSkunkShield2.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk shield 2", ex);
                        comboBoxSkunkShield2.Text = "Error";
                        comboBoxSkunkShield2.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkSoftware1_DropDown(comboBoxSkunkSoftware1, null);

                        foreach (object o in comboBoxSkunkSoftware1.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().InstalledSoftware1)
                            {
                                comboBoxSkunkSoftware1.SelectedItem = o;
                                break;
                            }
                            else if (((KeyValuePair<string, string>)o).Key == "None")
                            {
                                comboBoxSkunkSoftware1.SelectedItem = o;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk software 1", ex);
                        comboBoxSkunkSoftware1.Text = "Error";
                        comboBoxSkunkSoftware1.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkSoftware2_DropDown(comboBoxSkunkSoftware2, null);

                        foreach (object o in comboBoxSkunkSoftware2.Items)
                        {
                            if (((KeyValuePair<string, string>)o).Key == sge.Galaxy.GetSkunk().InstalledSoftware2)
                            {
                                comboBoxSkunkSoftware2.SelectedItem = o;
                                break;
                            }
                            else if (((KeyValuePair<string, string>)o).Key == "None")
                            {
                                comboBoxSkunkSoftware2.SelectedItem = o;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk software 2", ex);
                        comboBoxSkunkSoftware2.Text = "Error";
                        comboBoxSkunkSoftware2.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkWeaponConnection.Items.AddRange(cde.GetPlayerWeaponConnectionList().ToArray());
                        comboBoxSkunkWeaponConnection.SelectedIndex = 0;
                        comboBoxSkunkWeaponConnection.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk weapon connection", ex);
                        comboBoxSkunkWeaponConnection.Text = "Error";
                        comboBoxSkunkWeaponConnection.Enabled = false;
                    }
                    try
                    {
                        comboBoxSkunkSelectedWeapon.Text = sge.Galaxy.GetSkunk().GetInstalledWeapon(comboBoxSkunkWeaponConnection.Text);
                        comboBoxSkunkSelectedWeapon.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve skunk weapon", ex);
                        comboBoxSkunkSelectedWeapon.Text = "Error";
                        comboBoxSkunkSelectedWeapon.Enabled = false;
                    }
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
                    try
                    {
                        dataGridViewInventory.DataSource = sge.Galaxy.GetPlayer().PlayerInventory;
                        groupBoxInventory.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve inventory", ex);
                        groupBoxInventory.Enabled = false;
                    }
                    try
                    {
                        dataGridViewSkunkAmmunition.DataSource = sge.Galaxy.GetSkunk().Ammunition;
                        groupBoxSkunkAmmunition.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Failed to retrieve ammunition", ex);
                        groupBoxSkunkAmmunition.Enabled = false;
                    }
                    #endregion
                    tabControlMain.Visible = true;
                }
                else
                {
                    tabControlMain.Visible = false;
                }
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
        #region Player
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
        #endregion
        #region Skunk Equipment
        #region Combobox Drop Down
        private void comboBoxSkunkScanner_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkScanner.TextChanged -= comboBoxSkunkScanner_TextChanged;
                comboBoxSkunkScanner.TextChanged -= comboBoxSkunkScanner_TextChanged;
                if (cde != null
                    && comboBoxSkunkScanner.DataSource == null
                    )
                {
                    comboBoxSkunkScanner.DataSource = new BindingSource(cde.GetAllTypesInCategory("scannertypes").Where(a => a.Key.StartsWith("unit_player_ship_scanner_")), null);
                    comboBoxSkunkScanner.DisplayMember = "Value";
                    comboBoxSkunkScanner.ValueMember = "Key";
                }
                comboBoxSkunkScanner.TextChanged += comboBoxSkunkScanner_TextChanged;
            }
            catch (Exception ex)
            {
                comboBoxSkunkScanner.TextChanged -= comboBoxSkunkScanner_TextChanged;
                comboBoxSkunkScanner.TextChanged += comboBoxSkunkScanner_TextChanged;
                Logger.Error("Unable to retrieve the list for the scanner drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the scanner drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkEngine_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkEngine.TextChanged -= comboBoxSkunkEngine_TextChanged;
                comboBoxSkunkEngine.TextChanged -= comboBoxSkunkEngine_TextChanged;
                if (cde != null
                    && comboBoxSkunkEngine.DataSource == null
                    )
                {
                    comboBoxSkunkEngine.DataSource = new BindingSource(cde.GetAllTypesInCategory("enginetypes"), null);
                    comboBoxSkunkEngine.DisplayMember = "Value";
                    comboBoxSkunkEngine.ValueMember = "Key";
                }
                comboBoxSkunkEngine.TextChanged += comboBoxSkunkEngine_TextChanged;
            }
            catch (Exception ex)
            {
                comboBoxSkunkEngine.TextChanged -= comboBoxSkunkEngine_TextChanged;
                comboBoxSkunkEngine.TextChanged += comboBoxSkunkEngine_TextChanged;
                Logger.Error("Unable to retrieve the list for the engine drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the engine drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkShield_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkShield1.TextChanged -= comboBoxSkunkShield1_TextChanged;
                comboBoxSkunkShield1.TextChanged -= comboBoxSkunkShield1_TextChanged;
                comboBoxSkunkShield2.TextChanged -= comboBoxSkunkShield2_TextChanged;
                comboBoxSkunkShield2.TextChanged -= comboBoxSkunkShield2_TextChanged;
                if (cde != null
                    && ((ComboBox)sender).DataSource == null
                    )
                {
                    ((ComboBox)sender).DataSource = new BindingSource(cde.GetAllTypesInCategory("shieldgentypes"), null);
                    ((ComboBox)sender).DisplayMember = "Value";
                    ((ComboBox)sender).ValueMember = "Key";
                }
                comboBoxSkunkShield1.TextChanged += comboBoxSkunkShield1_TextChanged;
                comboBoxSkunkShield2.TextChanged += comboBoxSkunkShield2_TextChanged;
            }
            catch (Exception ex)
            {
                comboBoxSkunkShield1.TextChanged -= comboBoxSkunkShield1_TextChanged;
                comboBoxSkunkShield2.TextChanged -= comboBoxSkunkShield2_TextChanged;
                comboBoxSkunkShield1.TextChanged += comboBoxSkunkShield1_TextChanged;
                comboBoxSkunkShield2.TextChanged += comboBoxSkunkShield2_TextChanged;
                Logger.Error("Unable to retrieve the list for the shield 1 or 2 drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the shield 1 or 2 drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSoftware1_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cde != null
                    || comboBoxSkunkSoftware1.DataSource == null)
                {
                    comboBoxSkunkSoftware1.TextChanged -= comboBoxSkunkSoftware1_TextChanged;
                    comboBoxSkunkSoftware1.TextChanged -= comboBoxSkunkSoftware1_TextChanged;

                    Dictionary<string, string> allTypes = cde.GetAllTypesInCategory("scannertypes").Where(a => a.Key.StartsWith("software_trading_")).ToDictionary(a => a.Key, a => a.Value);
                    allTypes.Add("None", "None");
                    comboBoxSkunkSoftware1.DataSource = new BindingSource(allTypes, null);
                    comboBoxSkunkSoftware1.DisplayMember = "Value";
                    comboBoxSkunkSoftware1.ValueMember = "Key";

                    comboBoxSkunkSoftware1.TextChanged += comboBoxSkunkSoftware1_TextChanged;
                }
            }
            catch (Exception ex)
            {
                comboBoxSkunkSoftware1.TextChanged += comboBoxSkunkSoftware1_TextChanged;
                comboBoxSkunkSoftware1.TextChanged -= comboBoxSkunkSoftware1_TextChanged;
                Logger.Error("Unable to retrieve the list for the software 1 drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the software 1 drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSoftware2_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cde != null
                    || comboBoxSkunkSoftware2.DataSource == null)
                {
                    comboBoxSkunkSoftware2.TextChanged -= comboBoxSkunkSoftware2_TextChanged;
                    comboBoxSkunkSoftware2.TextChanged -= comboBoxSkunkSoftware2_TextChanged;

                    Dictionary<string, string> allTypes = cde.GetAllTypesInCategory("scannertypes").Where(a => a.Key.StartsWith("software_target_")).ToDictionary(a => a.Key, a => a.Value);
                    allTypes.Add("None", "None");
                    comboBoxSkunkSoftware2.DataSource = new BindingSource(allTypes, null);
                    comboBoxSkunkSoftware2.DisplayMember = "Value";
                    comboBoxSkunkSoftware2.ValueMember = "Key";

                    comboBoxSkunkSoftware2.TextChanged += comboBoxSkunkSoftware2_TextChanged;
                }
            }
            catch (Exception ex)
            {
                comboBoxSkunkSoftware2.TextChanged -= comboBoxSkunkSoftware2_TextChanged;
                comboBoxSkunkSoftware2.TextChanged += comboBoxSkunkSoftware2_TextChanged;
                Logger.Error("Unable to retrieve the list for the software 2 drop down box.", ex);
                MessageBox.Show("Unable to retrieve the list for the software 2 drop down box." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSelectedWeapon_DropDown(object sender, EventArgs e)
        {
        }
        #endregion

        #region ComboBox TextChanged
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

        private void comboBoxSkunkWeaponConnection_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkWeaponConnection.Items.Contains(comboBoxSkunkWeaponConnection.Text))
                {
                    comboBoxSkunkSelectedWeapon.TextChanged -= comboBoxSkunkSelectedWeapon_TextChanged;
                    comboBoxSkunkSelectedWeapon.TextChanged -= comboBoxSkunkSelectedWeapon_TextChanged;

                    string search = "weapon_player_";
                    string search2 = "weapon_player_";

                    switch(comboBoxSkunkWeaponConnection.Text)
                    {
                        case "conn_primaryweapon_beam":
                            search += "mining_";
                            search2 += "beam";
                            break;
                        case "conn_primaryweapon_impuls":
                            search += "impulse_";
                            search2 = null;
                            break;
                        case "conn_primaryweapon_mg":
                            search += "machinegun_";
                            search2 = null;
                            break;
                        case "conn_primaryweapon_plasma":
                            search += "plasma_";
                            search2 = null;
                            break;
                        case "conn_primaryweapon_shotgun":
                            search += "shotgun_";
                            search2 = null;
                            break;
                        default:
                            search = "None";
                            search2 = null;
                            break;
                    }

                    Dictionary<string, string> weapons = cde.GetAllTypesInCategory("weapontypes_primary").Where(a => a.Key.StartsWith(search) || (search2 != null && a.Key.StartsWith(search2))).ToDictionary(a => a.Key, a => a.Value);
                    weapons.Add("None", "None");
                    comboBoxSkunkSelectedWeapon.DataSource = new BindingSource(weapons, null);
                    comboBoxSkunkSelectedWeapon.DisplayMember = "Value";
                    comboBoxSkunkSelectedWeapon.ValueMember = "Key";

                    foreach (KeyValuePair<string, string> item in comboBoxSkunkSelectedWeapon.Items)
                    {
                        if (item.Key == sge.Galaxy.GetSkunk().GetInstalledWeapon(comboBoxSkunkWeaponConnection.Text))
                        {
                            comboBoxSkunkSelectedWeapon.SelectedItem = item;
                            comboBoxSkunkSelectedWeapon.Enabled = true;
                            break;
                        }
                        else if (item.Key == "None")
                        {
                            comboBoxSkunkSelectedWeapon.SelectedItem = item;
                            comboBoxSkunkSelectedWeapon.Enabled = false;
                        }
                    }

                    comboBoxSkunkSelectedWeapon.TextChanged += comboBoxSkunkSelectedWeapon_TextChanged;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks weapon connection.", ex);
                MessageBox.Show("Unable to set the skunks weapon connection." + "\n" + StandardErrorText);
                comboBoxSkunkSelectedWeapon.TextChanged += comboBoxSkunkSelectedWeapon_TextChanged;
            }
        }

        private void comboBoxSkunkScanner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkScanner.SelectedItem != null
                    && comboBoxSkunkScanner.Items.Contains(comboBoxSkunkScanner.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().InstalledScanner.Macro = ((KeyValuePair<string, string>)comboBoxSkunkScanner.SelectedItem).Key;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks scanner.", ex);
                MessageBox.Show("Unable to set the skunks scanner." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkEngine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if  (   comboBoxSkunkEngine.SelectedItem != null
                    &&  comboBoxSkunkEngine.Items.Contains(comboBoxSkunkEngine.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().SetInstalledEngine(((KeyValuePair<string, string>)comboBoxSkunkEngine.SelectedItem).Key);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks engine.", ex);
                MessageBox.Show("Unable to set the skunks engine." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkShield1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkShield1.SelectedItem != null
                    && comboBoxSkunkShield1.Items.Contains(comboBoxSkunkShield1.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().InstalledShield1 = ((KeyValuePair<string, string>)comboBoxSkunkShield1.SelectedItem).Key;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks shield 1.", ex);
                MessageBox.Show("Unable to set the skunks shield 1." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkShield2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkShield2.SelectedItem != null
                    && comboBoxSkunkShield2.Items.Contains(comboBoxSkunkShield2.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().InstalledShield2 = ((KeyValuePair<string, string>)comboBoxSkunkShield2.SelectedItem).Key;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks shield 2.", ex);
                MessageBox.Show("Unable to set the skunks shield 2." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSoftware1_TextUpdate(object sender, EventArgs e)
        {
        }

        private void comboBoxSkunkSoftware2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkSoftware2.SelectedItem != null
                    && comboBoxSkunkSoftware2.Items.Contains(comboBoxSkunkSoftware2.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().InstalledSoftware2 = ((KeyValuePair<string, string>)comboBoxSkunkSoftware2.SelectedItem).Key;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks software 2.", ex);
                //MessageBox.Show("Unable to set the skunks software 2." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSelectedWeapon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkSelectedWeapon.SelectedItem != null
                    && comboBoxSkunkSelectedWeapon.Items.Contains(comboBoxSkunkSelectedWeapon.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().SetInstalledWeapon(comboBoxSkunkWeaponConnection.Text, ((KeyValuePair<string, string>)comboBoxSkunkSelectedWeapon.SelectedItem).Key);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks selected weapon.", ex);
                MessageBox.Show("Unable to set the skunks selected weapon." + "\n" + StandardErrorText);
            }
        }
        #endregion
        #endregion
        private void comboBoxSkunkAmmo_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkAmmo.Items.Clear();
                // Only add inventory items which are not in the player inventory
                comboBoxSkunkAmmo.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypes("weapontypes_secondary").Where(a => !sge.Galaxy.GetSkunk().Ammunition.Exists(b => b.Ware == a)).ToArray());
                comboBoxSkunkAmmo.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypes("marines").Where(a => !sge.Galaxy.GetSkunk().Ammunition.Exists(b => b.Ware == a)).ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve the list of ammunition items to be added.", ex);
                MessageBox.Show("Unable to retrieve the list of ammunition items to be added." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkInventory_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkInventory.Items.Clear();
                // Only add inventory items which are not in the player inventory
                comboBoxSkunkInventory.Items.AddRange(sge.Galaxy.GetPlayer().GetKnownTypes("inventory_wares").Where(a => !sge.Galaxy.GetPlayer().PlayerInventory.Exists(b => b.Ware == a)).ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve the list of inventory items to be added.", ex);
                MessageBox.Show("Unable to retrieve the list of inventory items to be added." + "\n" + StandardErrorText);
            }
        }
        #endregion

        private void buttonSkunkAddAmmo_Click(object sender, EventArgs e)
        {
            if (sge.SaveGameLoaded)
            {
                try
                {
                    Convert.ToInt64(textBoxSkunkAmmo.Text);
                }
                catch (Exception ex)
                {
                    Logger.Warning("The textbox does not contain a number", ex);
                    MessageBox.Show("The textbox does not contain a number");
                    return;
                }

                if (!comboBoxSkunkAmmo.Items.Contains(comboBoxSkunkAmmo.Text))
                {
                    Logger.Warning("The combobox does not contain a valid selection");
                    MessageBox.Show("The combobox does not contain a valid selection");
                    return;
                }

                try
                {
                    sge.Galaxy.GetSkunk().AddAmmunition(comboBoxSkunkAmmo.Text, textBoxSkunkAmmo.Text);
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to add the ammo item.", ex);
                    MessageBox.Show("Unable to add the ammo item." + "\n" + StandardErrorText);
                    return;
                }

                try
                {
                    dataGridViewSkunkAmmunition.DataSource = null;
                    dataGridViewSkunkAmmunition.DataSource = sge.Galaxy.GetSkunk().Ammunition;
                    comboBoxSkunkAmmo_DropDown(null, null);
                    if (comboBoxSkunkAmmo.Items.Count > 0)
                    {
                        comboBoxSkunkAmmo.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to reload the ammo list.", ex);
                    MessageBox.Show("Unable to reload the ammo list." + "\n" + StandardErrorText);
                    return;
                }
            }
            else
            {
                Logger.Warning("buttonSkunkAddAmmo_Click: Unable to perform change. Save Game is not completely loaded yet.");
            }

        }

        private void buttonSkunkInventoryAdd_Click(object sender, EventArgs e)
        {
            if (sge.SaveGameLoaded)
            {
                try
                {
                    Convert.ToInt64(textBoxSkunkInventory.Text);
                }
                catch (Exception ex)
                {
                    Logger.Warning("The textbox does not contain a number", ex);
                    MessageBox.Show("The textbox does not contain a number");
                    return;
                }

                if (!comboBoxSkunkInventory.Items.Contains(comboBoxSkunkInventory.Text))
                {
                    Logger.Warning("The combobox does not contain a valid selection");
                    MessageBox.Show("The combobox does not contain a valid selection");
                    return;
                }

                try
                {
                    sge.Galaxy.GetPlayer().AddToPlayerInventory(comboBoxSkunkInventory.Text, textBoxSkunkInventory.Text);
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to add the inventory item.", ex);
                    MessageBox.Show("Unable to add the inventory item." + "\n" + StandardErrorText);
                    return;
                }

                try
                {
                    dataGridViewInventory.DataSource = null;
                    dataGridViewInventory.DataSource = sge.Galaxy.GetPlayer().PlayerInventory;
                    comboBoxSkunkInventory_DropDown(null, null);
                    if (comboBoxSkunkInventory.Items.Count > 0)
                    {
                        comboBoxSkunkInventory.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to reload the inventory list.", ex);
                    MessageBox.Show("Unable to reload the inventory list." + "\n" + StandardErrorText);
                    return;
                }
            }
            else
            {
                Logger.Warning("buttonSkunkInventoryAdd_Click: Unable to perform change. Save Game is not completely loaded yet.");
            }

        }

        private void buttonSkunkRemoveAmmo_Click(object sender, EventArgs e)
        {
            if (sge.SaveGameLoaded)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridViewSkunkAmmunition.SelectedRows)
                    {
                        if (row != null
                            && row.Cells["ware"] != null
                            )
                        {
                            sge.Galaxy.GetSkunk().RemoveAmmunition(row.Cells["ware"].Value.ToString());
                        }
                        else
                        {
                            Logger.Error("row or row.Cells[\"ware\"] is null.");
                        }
                    }
                    dataGridViewSkunkAmmunition.DataSource = null;
                    dataGridViewSkunkAmmunition.DataSource = sge.Galaxy.GetSkunk().Ammunition;
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to reload the ammo list.", ex);
                    MessageBox.Show("Unable to reload the ammo list." + "\n" + StandardErrorText);
                    return;
                }
            }
            else
            {
                Logger.Warning("buttonSkunkInventoryRemove_Click: Unable to perform change. Save Game is not completely loaded yet.");
            }
        }

        private void buttonSkunkInventoryRemove_Click(object sender, EventArgs e)
        {
            if (sge.SaveGameLoaded)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridViewInventory.SelectedRows)
                    {
                        if (row != null
                            && row.Cells["ware"] != null
                            )
                        {
                            sge.Galaxy.GetPlayer().RemoveFromPlayerInventory(row.Cells["ware"].Value.ToString());
                        }
                        else
                        {
                            Logger.Error("row or row.Cells[\"ware\"] is null.");
                        }
                    }
                    dataGridViewInventory.DataSource = null;
                    dataGridViewInventory.DataSource = sge.Galaxy.GetPlayer().PlayerInventory;
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to reload the inventory list.", ex);
                    MessageBox.Show("Unable to reload the inventory list." + "\n" + StandardErrorText);
                    return;
                }
            }
            else
            {
                Logger.Warning("buttonSkunkInventoryRemove_Click: Unable to perform change. Save Game is not completely loaded yet.");
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
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
        }

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

        private void buttonCatDatExtractor_Click(object sender, EventArgs e)
        {
            try
            {
                if (cde == null)
                {
                    cde = new CatDatExtractor(XRebirthPath);
                }

                FormCatDatExport.Instance(cde).Show();
            }
            catch (Exception ex)
            {
                Logger.Error("buttonCatDatExtractor_Click: Unable to start cat dat form.", ex, true);
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

        private void labelBrowseXR_TextChanged(object sender, EventArgs e)
        {
            if (labelBrowseXR.Text.ToLower().EndsWith("xrebirth.exe"))
            {
                Logger.Info("xrebirth dir selected: " + labelBrowseXR.Text);
            }
            else
            {
                Logger.Warning("Incorrect Xrebirth dir selected: " + labelBrowseXR.Text);
                MessageBox.Show("Incorrect Xrebirth dir selected: " + labelBrowseXR.Text + ". Not all functionality will be available.");
            }
        }

        private void comboBoxSkunkSoftware1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkSoftware1.SelectedItem != null
                    && comboBoxSkunkSoftware1.Items.Contains(comboBoxSkunkSoftware1.SelectedItem)
                    )
                {
                    sge.Galaxy.GetSkunk().InstalledSoftware1 = ((KeyValuePair<string, string>)comboBoxSkunkSoftware1.SelectedItem).Key;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to set the skunks software 1.", ex);
                MessageBox.Show("Unable to set the skunks software 1." + "\n" + StandardErrorText);
            }
        }

        private void comboBoxSkunkSelectedWeapon_SelectionChangeCommitted(object sender, EventArgs e)
        {

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

        private void comboBoxFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxFaction.SelectedItem != null
                    && comboBoxFaction.Items.Contains(comboBoxFaction.SelectedItem)
                    )
                {
                    dataGridViewRelations.DataSource = null;
                    dataGridViewLicenses.DataSource = null;

                    FactionData faction = sge.Factions[(string)comboBoxFaction.SelectedItem];

                    if (faction != null)
                    {
                        dataGridViewRelations.DataSource = faction.Relations;
                        dataGridViewLicenses.DataSource = faction.Licences;
                    }
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
    }
}
