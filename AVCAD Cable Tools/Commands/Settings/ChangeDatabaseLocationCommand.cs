using AVCAD.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands.Settings
{
    /// <summary>
    /// Command to change the folder for the database.
    /// </summary>
    public class ChangeDatabaseLocationCommand : CommandBase
    {
        private SettingsViewModel settingsViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsViewModel"></param>
        public ChangeDatabaseLocationCommand(SettingsViewModel settingsViewModel)
        {
            this.settingsViewModel = settingsViewModel;
        }

        // TODO Check SQLite exceptions and situations.

        /// <summary>
        /// Method that asks to select the file with databases.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            var cables = new List<Models.Cable>();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".db";
            dlg.Filter = "SQLite Databases (.db)|*.db";

            if (dlg.ShowDialog() == true)
            {
                settingsViewModel.PathToDatabase = dlg.FileName;
            }
        }
    }
}
