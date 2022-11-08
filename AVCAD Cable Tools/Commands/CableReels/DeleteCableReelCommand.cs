using AVCAD.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to delete selected cable reel
    /// </summary>
    public class DeleteCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel _cableReelsPageViewModel;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cableReelsPageViewModel">View model for the page</param>
        public DeleteCableReelCommand(CableReelsPageViewModel cableReelsPageViewModel)
        {
            this._cableReelsPageViewModel = cableReelsPageViewModel;
        }

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameter">Collection of CableReelViewModel</param>
        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable enumerable = parameter as IEnumerable;
                if (enumerable == null)
                    throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");
                //Get selected CableViewModels from the parameter.
                var selectedReels = enumerable.OfType<CableReelViewModel>().ToList();

                //Ask if user realy wants to delete this item.
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
                    _cableReelsPageViewModel.UpdateData();

                }
            }

            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
            //Exception if the database is in read-only folder
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"{ex.InnerException.Message}\nPlease, check the permission to that folder");
                }

            };
        }
    }
}
