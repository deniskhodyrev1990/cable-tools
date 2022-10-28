using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
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
            cableListViewModel.Cables.Where(x => x.IsMulticore).ToList();
            int x = 5;
        }
    }
}
