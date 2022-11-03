using AVCAD.Models;
using AVCAD.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    public class CreateEditCableReelsCommand : CommandBase
    {
        private CableReel cableReel;
        private CableReelsPageViewModel cableReelsPageViewModel;
        private CableReelViewModel cableReelsViewModel;
        private bool create;

        public CreateEditCableReelsCommand(CableReelsPageViewModel cableReelsPageViewModel)
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
            create = false;
        }

        public CreateEditCableReelsCommand(CableReelsPageViewModel cableReelsPageViewModel, CableReel cableReel)
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
            this.cableReel = cableReel;
            create = true;
        }

        public override void Execute(object? parameter)
        {
            using (var db = new SQlite.ApplicationContext())
            {
                
                if (!create)
                {
                    var selectedCableReels = cableReelsPageViewModel.CableReels.Where(i => i.IsSelected);
                    if (selectedCableReels.Count() > 0)
                    {

                        cableReel = db.CableReels.Find(selectedCableReels.First().Id);
                        
                    }
                }
                var ctWindow = new GUI.CreateEditCableReel(cableReel, db.CableTypes.ToList());
                if (ctWindow.ShowDialog() == true)
                {
                    var ct = ctWindow.CableReel;
                    if (db.CableReels.ToList().Contains(ct))
                    {
                        MessageBox.Show("A cable reel with these properties already exists");
                        return;
                    }
                    if (create)
                        db.CableReels.Add(ct);
                    else
                        db.Entry(ct).State = EntityState.Modified;
                    db.SaveChanges();

                    cableReelsPageViewModel.UpdateData();
                }
            }
        }
    }
}
