using System;
using System.Windows.Forms;
// For updating purposes
using System.Deployment.Application;
using System.ComponentModel;
using System.IO;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.Helper
{
    public class SmartClientHandling
    {
        #region members
        System.Timers.Timer _updateTimer = new System.Timers.Timer();
        bool _requiredUpdateDetected;
        #endregion

        #region constructor
        public SmartClientHandling(int updateTime)
        {
            Initialise(updateTime, false, "");
        }

        public SmartClientHandling(int updateTime, bool appAutoStartUp, string appShortCutName)
        {
            Initialise(updateTime, appAutoStartUp, appShortCutName);
        }
        #endregion

        public string GetVersionInfo()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception ex)
            {
                Logger.Warning("Unable to retrieve version from deployment info.", ex);
            }

            try
            {
                return Application.ProductVersion;
            }
            catch (Exception ex)
            {
                Logger.Warning("Unable to retrieve version from application info.", ex);
            }
            return "";
        }

        public bool IsNetworkDeployed()
        {
            return ApplicationDeployment.IsNetworkDeployed;
        }

        #region Private functions
        private void Initialise(int updateTime, bool appAutoStartUp, string appShortCutName)
        {
            // Check to see whether you are running through a ClickOnce launch.
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    _updateTimer.Interval = updateTime;
                    _updateTimer.Elapsed += _updateTimer_Elapsed;
                    _updateTimer.Enabled = true;
                    try
                    {
                        if (appAutoStartUp)
                        {
                            AppShortcutToStartup(appShortCutName);
                        }
                    }
                    catch(Exception e)
                    {
                        Logger.Error("SmartClient update mechanism failed to start. Exception: " + e.Message);
                    }

                    // Hook up an event handler for update check completed events.
                    ApplicationDeployment.CurrentDeployment.CheckForUpdateCompleted
                        += OnCheckForUpdatesCompleted;
                    ApplicationDeployment.CurrentDeployment.UpdateCompleted
                        += OnUpdateCompleted;
                }
            }
            catch (Exception e)
            {
                Logger.Error("SmartClient update mechanism failed to start. Exception: " + e.Message);
            }
        }

        void _updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _updateTimer.Stop();
            CheckForUpdates();
            _updateTimer.Start();
        }


        private void AppShortcutToStartup(string linkName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
            {
                string app = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + linkName + ".appref-ms";
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
        }
        #endregion

        #region Events
        #region Updates
        private void CheckForUpdates()
        {
            try
            {
                // Check to ensure the application is running through ClickOnce.
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    // Check for updates asynchronization.
                    ApplicationDeployment.CurrentDeployment.CheckForUpdateAsync();
                }
            }
            catch (Exception e)
            {
                Logger.Error("Error occurred while strating async check for updates. Exception: " + e.Message);
            }
           
        }

        private void OnCheckForUpdatesCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            try
            {
                if (e.UpdateAvailable)
                {
                    if (e.IsUpdateRequired)
                    {
                        _requiredUpdateDetected = true;
                    }
                    ApplicationDeployment.CurrentDeployment.UpdateAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error occurred while starting async update. Excepotion" + ex.Message);
            }
        }

        private void OnUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                _updateTimer.Stop();
                if (_requiredUpdateDetected)
                {
                    MessageBox.Show("Required update downloaded, application will restart");
                    
                    Logger.Verbose("Required update Application.Restart().");
                    Application.Restart();
                    
                    Logger.Verbose("Required update Application.Exit().");
                    Application.Exit();
                    
                    Logger.Verbose("Required update Environment.Exit(0).");
                    Environment.Exit(0); 
                }
                else
                {
                    string current = "";
                    string update = "";
                    try
                    {
                        current = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    catch
                    {
                    }

                    try
                    {
                        update = ApplicationDeployment.CurrentDeployment.UpdatedVersion.ToString();
                    }
                    catch
                    {
                    }

                    DialogResult result = MessageBox.Show(
                       "Application update downloaded. Would you like to restart?\nCurrent version: " + current + "\nUpdated version: " + update,
                       "Update", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Logger.Verbose("Non Required update Application.Restart().");
                        Application.Restart();
                        
                        Logger.Verbose("Non Required update Application.Exit().");
                        Application.Exit();
                        
                        Logger.Verbose("Non Required update Environment.Exit(0).");
                        Environment.Exit(0); 

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error occurred handling update completed." + ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
