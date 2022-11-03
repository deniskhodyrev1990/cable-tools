using AVCAD.ViewModels;
using System;
using System.Collections;
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
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");

            var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();

            if (selectedCables.Count > 0)
            {
                using (var db = new SQlite.ApplicationContext())
                {
                    var cmp = new GUI.CreateMulticoreProperties(selectedCables[0], db.CableTypes.ToList());
                    if (cmp.ShowDialog() == true)
                    {
                        foreach (var cable in selectedCables)
                        {
                            cable.MulticoreMembers = new ObservableCollection<ViewModels.CableViewModel>(selectedCables);
                            cable.IsMulticore = true;
                            cable.CableLength = cmp.Cable.CableLength;
                            cable.ExtraLength = cmp.Cable.ExtraLength;
                            cable.CableType = cmp.CableType?.ToString() ?? "";
                        }
                    }
                }
            }

        }
    }
}
