using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands
{
    public class ExcludeFromMulticoreCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        public ExcludeFromMulticoreCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            var selectedCables = cableListViewModel.Cables.Where(x => x.IsSelected);

            foreach (var sel in selectedCables)
            {
                foreach (var cable in cableListViewModel.Cables)
                {
                    if (cable.MulticoreMembers != null)
                    {
                       
                        if (cable.MulticoreMembers.Contains(sel))
                        {
                            cable.RemoveMulticoreMember(sel);
                            if (cable.MulticoreMembers.Count == 0)
                                cable.IsMulticore = false;
                        }
                    }
                }
                sel.MulticoreMembers = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();
                sel.IsMulticore = false;
            }
        }
    }
}
