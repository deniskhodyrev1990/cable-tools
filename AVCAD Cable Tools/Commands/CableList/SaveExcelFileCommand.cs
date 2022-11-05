using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
{
    /// <summary>
    /// Command to save the current cablelistviewmodel to excel file
    /// </summary>
    public class SaveExcelFileCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        public SaveExcelFileCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Send this model to the method.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            Excel.ExcelMethods.SaveCableList(cableListViewModel);
        }
    }
}
