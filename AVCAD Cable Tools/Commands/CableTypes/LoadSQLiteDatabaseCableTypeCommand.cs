using AVCAD.ViewModels;

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
            _cableTypePageViewModel.UpdateData();
        }
    }
}
