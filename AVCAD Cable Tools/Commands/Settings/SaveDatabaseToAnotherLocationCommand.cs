using AVCAD.Settings;
using Microsoft.Win32;
using System.IO;

namespace AVCAD.Commands.Settings
{
    /// <summary>
    /// This command is to save database to another location
    /// </summary>
    public class SaveDatabaseToAnotherLocationCommand : CommandBase
    {
        private SettingsViewModel _settingsViewModel;

        public SaveDatabaseToAnotherLocationCommand(SettingsViewModel settingsViewModel)
        {
            this._settingsViewModel = settingsViewModel;
        }

        /// <summary>
        /// Call the dialog, if result is true, copy file to the selected location.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                // set a default file name
                FileName = Path.GetFileName(_settingsViewModel.PathToDatabase),
                // set filters - this can be done in properties as well
                Filter = "Database files (*.db)|*.db|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(_settingsViewModel.PathToDatabase, saveFileDialog.FileName);
                _settingsViewModel.PathToDatabase = saveFileDialog.FileName;
            }
        }
    }
}
