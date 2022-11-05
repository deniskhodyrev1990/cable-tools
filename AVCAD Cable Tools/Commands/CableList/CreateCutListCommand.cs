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
    /// <summary>
    /// Command to create cut list from the cableviewmodels
    /// </summary>
    public class CreateCutListCommand: CommandBase
    {
        private CableListViewModel cableListViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableListViewModel">Current cableListViewModel</param>
        public CreateCutListCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Method to start a command.
        /// </summary>
        /// <param name="parameter">It is not used here.</param>
        public override void Execute(object? parameter)
        {
            //Open the database connection
            using (var db = new SQlite.ApplicationContext())
            {
                //Here a new viewmodel created to pass it to the window to select the cable reels.
                var cutListPropertiesViewModel = new ViewModels.CableReels.CutListPropertiesViewModel();
                var clepWindow = new GUI.CutListExportProperties(cutListPropertiesViewModel);
                if (clepWindow.ShowDialog() == true)
                {
                    //Get reels and export an excel file.
                    var selectedReels = cutListPropertiesViewModel.CableReels.Where(i => i.IsSelected).ToList();
                    Excel.ExcelMethods.CreateCutList(cableListViewModel, selectedReels);
                }


            }
            
        }
    }
}
