using AVCAD.ViewModels;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands
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
            MessageBox.Show("Create cut list");
        }
    }
}
