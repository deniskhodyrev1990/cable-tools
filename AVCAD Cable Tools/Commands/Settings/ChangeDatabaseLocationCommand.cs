using AVCAD.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands.Settings
{
    public class ChangeDatabaseLocationCommand : CommandBase
    {
        private SettingsViewModel settingsViewModel;

        public ChangeDatabaseLocationCommand(SettingsViewModel settingsViewModel)
        {
            this.settingsViewModel = settingsViewModel;
        }

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
