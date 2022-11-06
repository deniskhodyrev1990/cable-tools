using AVCAD.Settings;
using System.Collections.Generic;
using AVCAD.Models;

namespace AVCAD.Commands.Settings
{
    /// <summary>
    /// Command to change the folder for the database.
    /// </summary>
    public class ChangeDatabaseLocationCommand : CommandBase
    {
        private SettingsViewModel _settingsViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsViewModel"></param>
        public ChangeDatabaseLocationCommand(SettingsViewModel settingsViewModel)
        {
            this._settingsViewModel = settingsViewModel;
        }

        // TODO Check SQLite exceptions and situations.

        /// <summary>
        /// Method that asks to select the file with databases.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".db",
                Filter = "SQLite Databases (.db)|*.db"
            };

            if (dlg.ShowDialog() == true)
            {
                _settingsViewModel.PathToDatabase = dlg.FileName;
            }
        }
    }
}
