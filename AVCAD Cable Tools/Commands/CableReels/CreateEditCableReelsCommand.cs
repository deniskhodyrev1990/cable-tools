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
    /// <summary>
    /// Command to create or edit a cable reel;
    /// </summary>
    public class CreateEditCableReelsCommand : CommandBase
    {
        private CableReel cableReel;
        private CableReelsPageViewModel cableReelsPageViewModel;
        private bool create;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableReelsPageViewModel">CableReelsPageViewModel</param>
        /// <param name="create">Check if it is 'create' or 'edit'</param>
        public CreateEditCableReelsCommand(CableReelsPageViewModel cableReelsPageViewModel, bool create = true)
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
            this.create = create;
        }

        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter">It is not needed here.</param>
        public override void Execute(object? parameter)
        {
            using (var db = new SQlite.ApplicationContext())
            {
                //If edit then we just check the first selected element (if the collection is bigger);
                if (!create)
                {
                    var selectedCableReels = cableReelsPageViewModel.CableReels.Where(i => i.IsSelected);
                    if (selectedCableReels.Count() > 0)
                    {
                        cableReel = db.CableReels.Find(selectedCableReels.First().Id);
                    }
                }
                //If create then we need to create a new instance
                else
                    cableReel = new CableReel();
                //Open window with these properties. We need a cableReel instance and cabletypes from the database
                var ctWindow = new GUI.CreateEditCableReel(cableReel, db.CableTypes.ToList());
                if (ctWindow.ShowDialog() == true)
                {
                    //Get a new CableReel and check if it exists.
                    var ct = ctWindow.CableReel;
                    //Here we check for the duplicates. I compare length, cabletype and name with existing ones;
                    //If 'edit' then here will be more than 1 (itself included). If 'create' - just one
                    // TODO Find why it does not check with equal and hash rewritten.
                    var duplicates = db.CableReels.ToList()
                                                  .Where(i => i.Length == ct.Length && i.CableType == ct.CableType && i.Name == ct.Name)
                                                  .Count();
                    if ((duplicates > 1 && !create) || (create && duplicates > 0))
                    {
                        MessageBox.Show("A cable reel with these properties already exists");
                        return;
                    }

                    //Create or Edit as needed.
                    if (create)
                    {
                        db.CableReels.Add(ct);
                    }
                    else
                        db.Entry(ct).State = EntityState.Modified;
                    db.SaveChanges();
                    //Update data.
                    cableReelsPageViewModel.UpdateData();
                }
            }
        }
    }
}
