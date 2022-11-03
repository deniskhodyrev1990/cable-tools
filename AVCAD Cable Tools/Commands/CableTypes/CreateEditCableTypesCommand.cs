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

namespace AVCAD.Commands.CableTypes
{
    public class CreateEditCableTypesCommand : CommandBase
    {
        private CableType cableType;
        private CableTypesPageViewModel cableTypesPageViewModel;
        private CableTypesViewModel cableTypesViewModel;
        private bool create;

        public CreateEditCableTypesCommand(CableTypesPageViewModel cableTypesPageViewModel)
        {
            this.cableTypesPageViewModel = cableTypesPageViewModel;
            create = false;
        }

        public CreateEditCableTypesCommand(CableTypesPageViewModel cableTypesPageViewModel, CableType cableType)
        {
            this.cableTypesPageViewModel = cableTypesPageViewModel;
            this.cableType = cableType;
            create = true;
        }

        public override void Execute(object? parameter)
        {
            if (!create)
            {
                var selectedCableTypes = cableTypesPageViewModel.CableTypes.Where(i => i.IsSelected);
                if (selectedCableTypes.Count() > 0)
                {
                    using (var db = new SQlite.ApplicationContext())
                    {
                        cableType = db.CableTypes.Find(selectedCableTypes.First().Id);
                    }
                }
            }
            var ctWindow = new GUI.CreateEditCableType(cableType);
            if (ctWindow.ShowDialog() == true)
            {
                var ct = ctWindow.CableType;
                using (var db = new SQlite.ApplicationContext())
                {
                    if (db.CableTypes.ToList().Contains(ct))
                    {
                        MessageBox.Show("A cable type with these properties already exists.");
                        return;
                    }    
                    if (create)
                        db.CableTypes.Add(ct);
                    else
                        db.Entry(ct).State = EntityState.Modified;
                    db.SaveChanges();
                }
                cableTypesPageViewModel.UpdateData();
            }
        }
    }
}
