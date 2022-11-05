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
    
    /// <summary>
    /// Make multicore from the selected cables;
    /// </summary>
    public class MakeMulticoreCommand: CommandBase
    {

        /// <summary>
        /// Method to set this cable as a part of multicore.
        /// </summary>
        /// <param name="parameter">CableViewModel</param>
        /// <exception cref="ArgumentException">Check the parameter</exception>
        public override void Execute(object? parameter)
        {
            //Check the parameters
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");

            //Get cables from the parameter
            var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();
            //if it has at least a cable
            if (selectedCables.Count > 0)
            {
                //Open the database context
                using (var db = new SQlite.ApplicationContext())
                {
                    //set properties.
                    var cmp = new GUI.CreateMulticoreProperties(selectedCables[0], db.CableTypes.ToList());
                    if (cmp.ShowDialog() == true)
                    {
                        //Foreach of cable set these properties.
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
