using AVCAD.ViewModels;
using AVCAD.ViewModels.CableReels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to select/deselect the filtered collection of reels in CustListExportProperties.
    /// </summary>
    public class SelectDeselectAllCableReelsCommand : CommandBase
    {
        private CutListPropertiesViewModel cutListPropertiesViewModel;

        /// <summary>
        /// Constructor for this command
        /// </summary>
        /// <param name="cutListPropertiesViewModel">Current view model of the page</param>
        public SelectDeselectAllCableReelsCommand(CutListPropertiesViewModel cutListPropertiesViewModel)
        {
            this.cutListPropertiesViewModel = cutListPropertiesViewModel;
        }

        /// <summary>
        /// Basic execute method.
        /// </summary>
        /// <param name="parameter">Parameter here is binded to the checkbox in the header of the datagrid.</param>
        public override void Execute(object? parameter)
        {
            bool isChecked = (bool)parameter;
            //Set the checked property here to the selected one in filtered collection
            foreach (var cableReel in cutListPropertiesViewModel.FilteredCollection)
            {
                cableReel.IsSelected = isChecked;
            }
        }
    }
}
