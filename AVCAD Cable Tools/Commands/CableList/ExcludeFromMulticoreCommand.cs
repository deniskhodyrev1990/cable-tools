﻿using AVCAD.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableList
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
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");
            var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();

            foreach (var selectedCable in selectedCables)
            {
                foreach (var cable in cableListViewModel.Cables)
                {
                    if (cable.MulticoreMembers != null)
                    {
                       
                        if (cable.MulticoreMembers.Contains(selectedCable))
                        {
                            cable.RemoveMulticoreMember(selectedCable);
                            if (cable.MulticoreMembers.Count == 0)
                                cable.IsMulticore = false;
                        }
                    }
                }
                selectedCable.MulticoreMembers = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();
                selectedCable.IsMulticore = false;
            }
        }
    }
}
