using AVCAD.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace AVCAD.Commands.CableTypes
{
    /// <summary>
    /// Command to load/update cable types from SQLite
    /// </summary>
    public class LoadSQLiteDatabaseCableTypeCommand : CommandBase
    {
        private CableTypesPageViewModel _cableTypePageViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableTypePageViewModel">page view model</param>
        public LoadSQLiteDatabaseCableTypeCommand(CableTypesPageViewModel cableTypePageViewModel)
        {
            this._cableTypePageViewModel = cableTypePageViewModel;
        }

        /// <summary>
        /// Call for needed method to update.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            //Exception if the database is in read-only folder
            try
            {
                _cableTypePageViewModel.UpdateData();
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"{ex.InnerException.Message}\nPlease, check the permission to that folder");
                }
                else
                    MessageBox.Show(ex.Message);
            };
        }
    }
}
