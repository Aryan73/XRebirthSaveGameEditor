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
    public partial class FormPlayerSkunk : Form
    {
        #region Members
        static FormPlayerSkunk instance = null;
        static object LockInstance = new object();
        SaveGameEditor sge = null;
        CatDatExtractor cde = null;
        string StandardErrorText = "";
        bool Initialising = true;
        #endregion

        #region Constructors
        private FormPlayerSkunk()
        {
        }

        private FormPlayerSkunk(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            InitializeComponent();
            this.sge = sge;
            this.cde = cde;
            StandardErrorText = standardErrorText;
            comboBoxSkunkScanner.TextChanged -= comboBoxSkunkScanner_TextChanged;
            comboBoxSkunkEngine.TextChanged -= comboBoxSkunkEngine_TextChanged;
            comboBoxSkunkShield1.TextChanged -= comboBoxSkunkShield1_TextChanged;
            comboBoxSkunkShield2.TextChanged -= comboBoxSkunkShield2_TextChanged;
            comboBoxSkunkSoftware1.TextChanged -= comboBoxSkunkSoftware1_TextChanged;
            comboBoxSkunkSoftware2.TextChanged -= comboBoxSkunkSoftware2_TextChanged;
        }
        #endregion

        #region Functions
        public static FormPlayerSkunk Instance(SaveGameEditor sge, CatDatExtractor cde, string standardErrorText)
        {
            lock (LockInstance)
            {
                if (instance == null)
                {
                    instance = new FormPlayerSkunk(sge, cde, standardErrorText);
                }

                return instance;
            }
        }

        public void ChangeFormState()
        {
            Initialising = true;
            try
            {
                comboBoxSkunkScanner_DropDown(null, null);
                foreach (object o in comboBoxSkunkScanner.Items)
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
            Initialising = false;
        }

        public void ResizeElements()
        {
            int splitpos = this.Width / 3;
            splitContainer1.SplitterDistance = splitpos;
            splitContainer2.SplitterDistance = splitpos;
            splitpos = splitContainer3.Height - 60;
            splitContainer3.SplitterDistance = splitpos;
            splitContainer4.SplitterDistance = splitpos;
            splitpos = 30;
            splitContainer5.SplitterDistance = splitpos;
            splitContainer6.SplitterDistance = splitpos;
            splitpos = 50;
            splitContainer7.SplitterDistance = splitpos;
            splitContainer8.SplitterDistance = splitpos;
            splitContainer9.SplitterDistance = splitpos;
            splitContainer10.SplitterDistance = splitpos;
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

        private void comboBoxSkunkAmmo_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSkunkAmmo.DataSource = null;
                // Only add inventory items which are not in the player inventory
                
                Dictionary<string, string> allTypes = cde.GetAllTypesInCategory("weapontypes_secondary").Where(a => !sge.Galaxy.GetSkunk().Ammunition.Exists(b => b.Ware == a.Key)).ToDictionary(a => a.Key, a => a.Value);
                Dictionary<string, string> allTypesm = cde.GetAllTypesInCategory("marines").Where(a => !sge.Galaxy.GetSkunk().Ammunition.Exists(b => b.Ware == a.Key)).ToDictionary(a => a.Key, a => a.Value);
                foreach (KeyValuePair<string,string> m in allTypesm)
                {
                    allTypes.Add(m.Key, m.Value);
                }
                if (allTypes.Count > 0)
                {
                    comboBoxSkunkAmmo.DataSource = new BindingSource(allTypes, null);
                    comboBoxSkunkAmmo.DisplayMember = "Value";
                    comboBoxSkunkAmmo.ValueMember = "Key";
                }
                else
                {
                    comboBoxSkunkAmmo.Enabled = false;
                }
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
                comboBoxSkunkInventory.DataSource = null;
                // Only add inventory items which are not in the player inventory
                Dictionary<string, string> allTypes = cde.GetAllTypesInCategory("inventory_wares").Where(a => !sge.Galaxy.GetPlayer().PlayerInventory.Exists(b => b.Ware == a.Key)).ToDictionary(a => a.Key, a => a.Value);
                if (allTypes.Count > 0)
                {
                    comboBoxSkunkInventory.DataSource = new BindingSource(allTypes, null);
                    comboBoxSkunkInventory.DisplayMember = "Value";
                    comboBoxSkunkInventory.ValueMember = "Key";
                }
                else
                {
                    comboBoxSkunkAmmo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to retrieve the list of inventory items to be added.", ex);
                MessageBox.Show("Unable to retrieve the list of inventory items to be added." + "\n" + StandardErrorText);
            }
        }
        #endregion

        #region ComboBox TextChanged
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
                    && !Initialising
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
                if (comboBoxSkunkEngine.SelectedItem != null
                    && comboBoxSkunkEngine.Items.Contains(comboBoxSkunkEngine.SelectedItem)
                    && !Initialising
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
                    && !Initialising
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
                    && !Initialising
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

        private void comboBoxSkunkSoftware2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkSoftware2.SelectedItem != null
                    && comboBoxSkunkSoftware2.Items.Contains(comboBoxSkunkSoftware2.SelectedItem)
                    && !Initialising
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

        private void comboBoxSkunkSoftware1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSkunkSoftware1.SelectedItem != null
                    && comboBoxSkunkSoftware1.Items.Contains(comboBoxSkunkSoftware1.SelectedItem)
                    && !Initialising
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
        #endregion
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

                if (comboBoxSkunkAmmo.SelectedItem == null
                    || !comboBoxSkunkAmmo.Items.Contains(comboBoxSkunkAmmo.SelectedItem)
                    )
                {
                    Logger.Warning("The combobox does not contain a valid selection");
                    MessageBox.Show("The combobox does not contain a valid selection");
                    return;
                }

                KeyValuePair<string, string> sel = (KeyValuePair<string, string>)comboBoxSkunkAmmo.SelectedItem;

                try
                {
                    sge.Galaxy.GetSkunk().AddAmmunition(sel.Key, textBoxSkunkAmmo.Text);
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

                if (comboBoxSkunkInventory.SelectedItem == null
                    || !comboBoxSkunkInventory.Items.Contains(comboBoxSkunkInventory.SelectedItem)
                    )
                {
                    Logger.Warning("The combobox does not contain a valid selection");
                    MessageBox.Show("The combobox does not contain a valid selection");
                    return;
                }

                KeyValuePair<string, string> sel = (KeyValuePair<string, string>)comboBoxSkunkInventory.SelectedItem;

                try
                {
                    sge.Galaxy.GetPlayer().AddToPlayerInventory(sel.Key, textBoxSkunkInventory.Text);
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
    }
}
