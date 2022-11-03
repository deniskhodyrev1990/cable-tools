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
    public class SelectCableTypeCommand : CommandBase
    {
        private CableListViewModel cableListViewModel;

        public SelectCableTypeCommand(CableListViewModel cableListViewModel)
        {
            this.cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            IEnumerable enumerable = parameter as IEnumerable;
            if (enumerable == null)
                throw new ArgumentException("parameter has to be an IEnumerable.", "parameter");
            var selectedCables = enumerable.OfType<ViewModels.CableViewModel>().ToList();

            using (var db = new SQlite.ApplicationContext())
            {
                var ctWindow = new GUI.SelectCableTypeForCables(db.CableTypes.ToList(), new CableType());
                if (ctWindow.ShowDialog() == true)
                {
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
