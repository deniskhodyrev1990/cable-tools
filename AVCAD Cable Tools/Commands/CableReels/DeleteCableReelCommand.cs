using AVCAD.Models;
using AVCAD.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to delete selected cable reel
    /// </summary>
    public class DeleteCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel cableReelsPageViewModel;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cableReelsPageViewModel">View model for the page</param>
        public DeleteCableReelCommand(CableReelsPageViewModel cableReelsPageViewModel)
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
        }

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameter">Collection of CableReelViewModel</param>
        public override void Execute(object? parameter)
        {
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");
            //Get selected CableViewModels from the parameter.
            var selectedReels = enumerable.OfType<ViewModels.CableReelViewModel>().ToList();

            //Ask if user reaaly want to delete this item.
            var dialog = MessageBox.Show("Do you want to delete selected cable reels from the database?", "Warning", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                // Get Ids of the selected elements
                var selectedCableReelsId = selectedReels.Select(i => i.Id);

                using (var db = new SQlite.ApplicationContext())
                {
                    //Find the cableReels in the database
                    var cableReels = db.CableReels.Where(i => selectedCableReelsId.Contains(i.Id));
                    //Remove, save and update data.
                    foreach (var cableReel in cableReels)
                    {
                        db.CableReels.Remove(cableReel);
                    }
                    db.SaveChanges();
                }
                cableReelsPageViewModel.UpdateData();
                
            }
        }
    }
}
