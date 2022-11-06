using AVCAD.CableReels;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to select/deselect the filtered collection of reels in CustListExportProperties.
    /// </summary>
    public class SelectDeselectAllCableReelsCommand : CommandBase
    {
        private CutListPropertiesViewModel _cutListPropertiesViewModel;

        /// <summary>
        /// Constructor for this command
        /// </summary>
        /// <param name="cutListPropertiesViewModel">Current view model of the page</param>
        public SelectDeselectAllCableReelsCommand(CutListPropertiesViewModel cutListPropertiesViewModel)
        {
            this._cutListPropertiesViewModel = cutListPropertiesViewModel;
        }

        /// <summary>
        /// Basic execute method.
        /// </summary>
        /// <param name="parameter">Parameter here is binded to the checkbox in the header of the datagrid.</param>
        public override void Execute(object? parameter)
        {
            bool isChecked = (bool)parameter;
            //Set the checked property here to the selected one in filtered collection
            foreach (var cableReel in _cutListPropertiesViewModel.FilteredCollection)
            {
                cableReel.IsSelected = isChecked;
            }
        }
    }
}
