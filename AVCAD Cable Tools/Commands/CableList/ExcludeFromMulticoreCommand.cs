using AVCAD.ViewModels;
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
    /// <summary>
    /// Command to exlude the selected cable(s) from the multicor
    /// </summary>
    public class ExcludeFromMulticoreCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableListViewModel"></param>
        public ExcludeFromMulticoreCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="ArgumentException">Here it should be enumerable of CableViewModel</exception>
        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable enumerable = parameter as IEnumerable;
                if (enumerable == null)
                    throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");

                //Get selected CableViewModels from the parameter.
                var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();

                foreach (var selectedCable in selectedCables)
                {
                    //Check all the multicores
                    foreach (var cable in cableListViewModel.Cables.Where(i => i.IsMulticore))
                    {
                        if (cable.MulticoreMembers.Contains(selectedCable))
                        {
                            //Remove cable from the multicore where it is.
                            cable.RemoveMulticoreMember(selectedCable);
                            if (cable.MulticoreMembers.Count == 0)
                                cable.IsMulticore = false;
                        }
                    }
                    // TODO Check this code
                    //Change properties of the selected cable
                    //selectedCable.MulticoreMembers = new System.Collections.ObjectModel.ObservableCollection<CableViewModel>();
                    //selectedCable.IsMulticore = false;
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }
        }
    }
}