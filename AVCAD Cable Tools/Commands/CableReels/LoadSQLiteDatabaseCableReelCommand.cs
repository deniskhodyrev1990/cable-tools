using AVCAD.ViewModels;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to load all cable reels from database.
    /// </summary>
    public class LoadSQLiteDatabaseCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel _cableReelPageViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableReelPageViewModel"></param>
        public LoadSQLiteDatabaseCableReelCommand(CableReelsPageViewModel cableReelPageViewModel)
        {
            this._cableReelPageViewModel = cableReelPageViewModel;
        }

        /// <summary>
        /// Call update method from the view model
        /// </summary>
        /// <param name="parameter">It is not used here.</param>
        public override void Execute(object? parameter)
        {
            _cableReelPageViewModel.UpdateData();
        }
    }
}
