using AVCAD.Models;
using AVCAD.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableTypes
{
    /// <summary>
    /// Command to create or edit cable type
    /// </summary>
    public class CreateEditCableTypesCommand : CommandBase
    {
        public CableType CableType { get; set; }

        private CableTypesPageViewModel cableTypesPageViewModel;
        private bool create;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableTypesPageViewModel"></param>
        /// <param name="create"></param>
        public CreateEditCableTypesCommand(CableTypesPageViewModel cableTypesPageViewModel, bool create = true)
        {
            this.cableTypesPageViewModel = cableTypesPageViewModel;
            this.create = create;
        }

        /// <summary>
        /// Execute method that deals with it
        /// </summary>
        /// <param name="parameter">Should be CableTypesViewModel</param>
        public override void Execute(object? parameter)
        {
            try
            {
                using (var db = new SQlite.ApplicationContext())
                {
                    //Get selected CableViewModels from the parameter.
                    CableTypesViewModel selectedCableType = parameter as CableTypesViewModel;
                    if (selectedCableType == null && !create)
                        throw new ArgumentException("parameter has to be an CableReelViewModel.", "parameter");

                    if (!create)
                    {
                        //If edit then we just get the element from the database.;
                        CableType = db.CableTypes.Find(selectedCableType.Id);
                    }
                    //If create then we need to create a new instance
                    else
                        CableType = new CableType();
                    //Open window with these properties. We need a CableType instance and cabletypes from the database
                    var ctWindow = new GUI.CreateEditCableType(CableType);
                    if (ctWindow.ShowDialog() == true)
                    {
                        //Get a new CableType and check if it exists.
                        var ct = ctWindow.CableType;

                        var duplicates = db.CableTypes.ToList()
                                                      .Where(i => i.MaxLength == ct.MaxLength && i.Type == ct.Type)
                                                      .Count();
                        // Here we check for the duplicates. I compare MaxLength, Type  with existing ones;
                        //If 'edit' then here will be more than 1 (itself included). If 'create' - just one
                        if ((duplicates > 1 && !create) || (create && duplicates > 0))
                        {
                            MessageBox.Show("A cable type with these properties already exists");
                            return;
                        }
                        //Create or Edit as needed.
                        if (create)
                            db.CableTypes.Add(ct);
                        else
                            db.Entry(ct).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    //Update data.
                    cableTypesPageViewModel.UpdateData();
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }
    }
}
