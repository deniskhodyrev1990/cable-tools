using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands
{
    public class SaveExcelFileCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        public SaveExcelFileCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("Save Excel");
        }
    }
}
