using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands
{
    public class MakeMulticoreCommand: CommandBase
    {
        private CableListViewModel cableListViewModel;

        public MakeMulticoreCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
            
        }

        public override void Execute(object? parameter)
        {
            var selected = cableListViewModel.Cables.Where(x => x.IsSelected);
            foreach (var cable in selected)
            {
                if (cable.IsMulticore)
                    cable.IsMulticore = false;
                else
                    cable.IsMulticore = true;
            }
        }
    }
}
