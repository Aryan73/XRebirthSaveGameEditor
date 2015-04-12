#region Usings

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using System.Windows.Forms;

#endregion

namespace X_Rebirth_Save_Game_Editor.Logging
{
    #region Support classes

    internal class LogRotateConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("LogRotateConfigEntries")]
        internal LogRotateConfigurationElementCollection LogRotateConfigEntries
        {
            get { return (LogRotateConfigurationElementCollection)this["LogRotateConfigEntries"]; }
        }
    }

    internal class LogRotateConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LogRotateConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LogRotateConfigurationElement)element).FilesToKeep;
        }
    }

    internal class LogRotateConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("FilesToKeep", IsKey = true, IsRequired = true)]
        internal string FilesToKeep
        {
            get
            {
                return (string)this["FilesToKeep"];
            }
        }
    }

    #endregion

    public static class Logger
    {
        #region Methods

        /// <summary>
        /// For verbose logs.
        /// </summary>
        /// <param name="message"></param>
        public static void Verbose(string message)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message, "Verbose", 0, 0, TraceEventType.Verbose);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// For information logs.
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message, "Info", 0, 0, TraceEventType.Information);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// For error information.
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message, "Error", 0, 0, TraceEventType.Error);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// For error exceptions.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, bool messageBox)
        {
            Error(message);

            MessageBox.Show(message);
        }

        /// <summary>
        /// For error exceptions.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message + "\r\nException: " + exception + "\r\nStackTrace: " + exception.StackTrace, "Error", 0, 0, TraceEventType.Error);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// For error exceptions.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception, bool messageBox)
        {
            Error(message, exception);

            MessageBox.Show(message);
        }

        /// <summary>
        /// For warning information.
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(string message)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message, "Warning", 0, 0, TraceEventType.Error);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// For warning exceptions.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warning(string message, Exception exception)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message + "\r\nException: " + exception + "\r\nStackTrace: " + exception.StackTrace, "Warning", 0, 0, TraceEventType.Error);

            PurgeOldLogFiles();
        }

        /// <summary>
        /// Deletes expired log files.
        /// </summary>
        private static void PurgeOldLogFiles()
        {
            // Limit purging to max. once per hour
            if (DateTime.Now < lastLogFilePurgeTime.AddHours(1))
                return;

            // List all log files in the logging output directory
            DirectoryInfo loggingOutputDirectoryInfo = new DirectoryInfo(loggingOutputDirectory);
            FileInfo[] fileInfoArray = loggingOutputDirectoryInfo.GetFiles("*.log");
            List<string> logFileNames = new List<string>();
            foreach (FileInfo fi in fileInfoArray)
            {
                logFileNames.Add(fi.Name);
            }

            // Sort the log files by name (equivalent to creation date because of the date in the file names)
            logFileNames.Sort();

            // Delete the oldest file, until the number of remaining files equals the configuration setting filesToKeep
            while (logFileNames.Count > filesToKeep)
            {
                try
                {
                    File.Delete(loggingOutputDirectory + "\\" + logFileNames[0]);
                }
                catch
                {
                    // Non-fatal exception, continue
                }
                finally
                {
                    // Always remove the file from the list, even if delete failed. Prevents infinite retries on the same file.
                    logFileNames.RemoveAt(0);
                }
            }

            // Purging completed: set the timestamp of purging
            lastLogFilePurgeTime = DateTime.Now;
        }

        /// <summary>
        /// Gets the logging output from the app.config (loggingConfiguration section)
        /// </summary>
        private static void GetLoggingSettings()
        {
            IConfigurationSource configSource = Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ConfigurationSourceFactory.Create();

            LoggingSettings logSettings = LoggingSettings.GetLoggingSettings(configSource);

            TraceListenerDataCollection dataCollection = logSettings.TraceListeners;

            if (dataCollection.Count == 0)
                return;

            TraceListenerData traceListenerData = dataCollection.Get(0);

            if (traceListenerData is RollingFlatFileTraceListenerData)
            {
                RollingFlatFileTraceListenerData tld = (RollingFlatFileTraceListenerData)traceListenerData;
                loggingOutputFileName = tld.FileName;
            }
        }

        /// <summary>
        /// Gets the max number of logfiles to keep from the app.config (logRotateConfiguration section)
        /// </summary>
        private static void GetLogRotateSettings()
        {
            try
            {
                LogRotateConfigurationSection configSection = (LogRotateConfigurationSection)System.Configuration.ConfigurationManager.GetSection("logRotateConfiguration");

                if (configSection != null)
                {
                    foreach (LogRotateConfigurationElement element in configSection.LogRotateConfigEntries)
                    {
                        int temp;
                        if (int.TryParse(element.FilesToKeep, out temp))
                        {
                            loggingFilesToKeep = temp;
                            break;
                        }
                    }
                }
            }
            catch (System.Configuration.ConfigurationErrorsException)
            {
                // No valid config section present for log rotate. Do not limit the number of logfiles.
                loggingFilesToKeep = Int32.MaxValue;
            }
        }

        #endregion

        #region Fields

        public static string loggingOutputFileName = null;
        private static int? loggingFilesToKeep = null;

        private static DateTime lastLogFilePurgeTime = DateTime.MinValue;

        #endregion

        #region Properties

        public static string loggingOutputDirectory
        {
            get
            {
                // Retrieve the logging settings on first call
                if (loggingOutputFileName == null)
                    GetLoggingSettings();

                // Guard against null dereference
                if (loggingOutputFileName == null)
                    return null;

                // Get the directory name for logging output
                FileInfo fileInfo = new FileInfo(loggingOutputFileName);
                return fileInfo.DirectoryName;
            }
        }

        private static int filesToKeep
        {
            get
            {
                // Retrieve the log rotate settings on first call
                if (loggingFilesToKeep == null)
                    GetLogRotateSettings();

                // Guard against null dereference
                if (loggingFilesToKeep == null)
                    return int.MaxValue;    // unable to read setting "filesToKeep": do not start purging of old log files

                // Return the number of files to keep
                return (int)loggingFilesToKeep;
            }
        }

        #endregion

    }
}
