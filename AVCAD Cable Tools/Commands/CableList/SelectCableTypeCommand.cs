using AVCAD.Models;
using AVCAD.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    /// Command to select cable type for the selected cables
    /// </summary>
    public class SelectCableTypeCommand : CommandBase
    {
        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter">It should be enumerable of CableViewModels</param>
        /// <exception cref="ArgumentException">Check the type of parameters</exception>
        public override void Execute(object? parameter)
        {
            //Check the type of parameters
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");
            //Get selected cables
            var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();

            using (var db = new SQlite.ApplicationContext())
            {
                //Ask fr properties
                var ctWindow = new GUI.SelectCableTypeForCables(db.CableTypes.ToList(), new CableType());
                if (ctWindow.ShowDialog() == true)
                {
                    //Get and set properties.
                    var ct = ctWindow.CableType;
                    foreach (var cable in selectedCables)
                    {
                        cable.CableType = ct.Type;
                    }
                }
            }
        }
    }
}
