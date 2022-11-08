using AVCAD.Models;
using AVCAD.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    /// <summary>
    /// Command to _create or edit a cable reel;
    /// </summary>
    public class CreateEditCableReelsCommand : CommandBase
    {
        public CableReel CableReel { get; set; }
        private CableReelsPageViewModel _cableReelsPageViewModel;
        private bool _create;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableReelsPageViewModel">CableReelsPageViewModel</param>
        /// <param name="create">Check if it is '_create' or 'edit'</param>
        public CreateEditCableReelsCommand(CableReelsPageViewModel cableReelsPageViewModel, bool create = true)
        {
            this._cableReelsPageViewModel = cableReelsPageViewModel;
            this._create = create;
        }

        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter">Enumerable of CableReelViewModel</param>
        public override void Execute(object? parameter)
        {
            try
            {
                //Get selected CableViewModels from the parameter.
                CableReelViewModel selectedCableReel = parameter as CableReelViewModel;
                if (selectedCableReel == null && !_create)
                    throw new ArgumentException("parameter has to be an CableReelViewModel.", "parameter");

                using (var db = new SQlite.ApplicationContext())
                {
                    //If edit then we just get the element from the database.;
                    if (!_create)
                    {
                        CableReel = db.CableReels.Find(selectedCableReel.Id);
                    }
                    //If _create then we need to _create a new instance
                    else
                        CableReel = new CableReel();
                    //Open window with these properties. We need a cableReel instance and cabletypes from the database
                    var ctWindow = new GUI.CreateEditCableReel(CableReel, db.CableTypes.ToList());
                    if (ctWindow.ShowDialog() == true)
                    {
                        //Get a new CableReel and check if it exists.
                        var ct = ctWindow.CableReel;
                        //Here we check for the duplicates. I compare length, cabletype and name with existing ones;
                        //If 'edit' then here will be more than 1 (itself included). If '_create' - just one
                        // TODO Find why it does not check with equal and hash rewritten.
                        var duplicates = db.CableReels.ToList()
                                                          .Count(i => i.Length == ct.Length && i.CableType == ct.CableType && i.Name == ct.Name);
                        if ((duplicates > 1 && !_create) || (_create && duplicates > 0))
                        {
                            MessageBox.Show("A cable reel with these properties already exists");
                            return;
                        }

                        //Create or Edit as needed.
                        if (_create)
                        {
                            db.CableReels.Add(ct);
                        }
                        else
                            db.Entry(ct).State = EntityState.Modified;
                        db.SaveChanges();
                        //Update data.
                        _cableReelsPageViewModel.UpdateData();
                    }
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
