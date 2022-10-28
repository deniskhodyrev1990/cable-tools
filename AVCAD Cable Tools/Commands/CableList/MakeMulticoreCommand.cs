using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
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
            var selectedCables = cableListViewModel.Cables.Where(x => x.IsSelected).ToList();
            if (selectedCables.Count > 1)
            {
                foreach (var cable in selectedCables)
                {
                    if (cable.IsMulticore)
                    {
                        cable.IsMulticore = false;
                    }
                    else
                    {
                        cable.IsMulticore = true;
                        cable.MulticoreMembers = new ObservableCollection<ViewModels.CableViewModel>(selectedCables);
                    }
                }
            }

        }
    }
}
