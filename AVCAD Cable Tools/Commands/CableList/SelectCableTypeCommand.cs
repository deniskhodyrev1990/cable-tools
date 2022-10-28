using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
{
    public class SelectCableTypeCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        public SelectCableTypeCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("SelectCableTypes");
        }
    }
}
