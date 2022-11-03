using AVCAD.Models;
using AVCAD.ViewModels;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
{
    public class CreateCutListCommand: CommandBase
    {
        private CableListViewModel cableListViewModel;

        public CreateCutListCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            using (var db = new SQlite.ApplicationContext())
            {
                var cableReelsPageViewModel = new ViewModels.CableReelsPageViewModel();
                cableReelsPageViewModel.UpdateData();
                var clepWindow = new GUI.CutListExportProperties(cableReelsPageViewModel);
                if (clepWindow.ShowDialog() == true)
                {
                    var selectedReels = cableReelsPageViewModel.CableReels.Where(i => i.IsSelected).ToList();
                    Excel.ExcelMethods.CreateCutList(cableListViewModel, selectedReels);
                }


            }
            
        }
    }
}
