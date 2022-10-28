using AVCAD.Models;
using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    public class DeleteCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel cableReelsPageViewModel;
        private CableReel cableReel;

        public DeleteCableReelCommand(CableReelsPageViewModel cableReelsPageViewModel)
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            var dialog = MessageBox.Show("Do you want to delete selected cable reels from the database?", "Warning", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                var selectedCableReelsId = cableReelsPageViewModel.CableReels.Where(i => i.IsSelected).Select(i => i.Id);
                using (var db = new SQlite.ApplicationContext())
                {
                    var cableReels = db.CableReels.Where(i => selectedCableReelsId.Contains(i.Id));
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
