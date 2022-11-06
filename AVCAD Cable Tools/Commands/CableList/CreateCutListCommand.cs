using AVCAD.ViewModels;
using System.Linq;
using AVCAD.CableReels;

namespace AVCAD.Commands.CableList
{
    /// <summary>
    /// Command to create cut list from the cableviewmodels
    /// </summary>
    public class CreateCutListCommand: CommandBase
    {
        private CableListViewModel _cableListViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableListViewModel">Current _cableListViewModel</param>
        public CreateCutListCommand(CableListViewModel cableListViewModel)
        {
            this._cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Method to start a command.
        /// </summary>
        /// <param name="parameter">It is not used here.</param>
        public override void Execute(object? parameter)
        {
            //Open the database connection
            //Here a new viewmodel created to pass it to the window to select the cable reels.
            var cutListPropertiesViewModel = new CutListPropertiesViewModel();
            var clepWindow = new GUI.CutListExportProperties(cutListPropertiesViewModel);
            if (clepWindow.ShowDialog() == true)
            {
                //Get reels and export an excel file.
                var selectedReels = cutListPropertiesViewModel.CableReels.Where(i => i.IsSelected).ToList();
                Excel.ExcelMethods.CreateCutList(_cableListViewModel, selectedReels);
            }
        }
    }
}
