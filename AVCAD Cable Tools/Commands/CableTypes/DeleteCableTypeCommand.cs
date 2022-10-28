using AVCAD.Models;
using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableTypes
{
    public class DeleteCableTypeCommand : CommandBase
    {
        private CableTypesPageViewModel cableTypesPageViewModel;
        private CableType cableType;

        public DeleteCableTypeCommand(CableTypesPageViewModel cableTypesPageViewModel)
        {
            this.cableTypesPageViewModel = cableTypesPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            var dialog = MessageBox.Show("Do you want to delete selected cable types from the database?", "Warning", MessageBoxButton.YesNo);
            if (dialog == MessageBoxResult.Yes)
            {
                var selectedCableTypesId = cableTypesPageViewModel.CableTypes.Where(i => i.IsSelected).Select(i => i.Id);
                using (var db = new SQlite.ApplicationContext())
                {
                    var cableTypes = db.CableTypes.Where(i => selectedCableTypesId.Contains(i.Id));
                    foreach (var cableType in cableTypes)
                    {
                        db.CableTypes.Remove(cableType);
                    }
                    db.SaveChanges();
                }
                cableTypesPageViewModel.UpdateData();
                
            }
        }
    }
}
