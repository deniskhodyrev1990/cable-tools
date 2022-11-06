using AVCAD.ViewModels;
using System;
using System.Collections;
using System.Linq;
using System.Windows;

namespace AVCAD.Commands.CableTypes
{
    /// <summary>
    /// Command to delete the cable types.
    /// </summary>
    public class DeleteCableTypeCommand : CommandBase
    {
        private CableTypesPageViewModel _cableTypesPageViewModel;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableTypesPageViewModel">page view model</param>
        public DeleteCableTypeCommand(CableTypesPageViewModel cableTypesPageViewModel)
        {
            this._cableTypesPageViewModel = cableTypesPageViewModel;
        }

        /// <summary>
        /// Execute method to delete items
        /// </summary>
        /// <param name="parameter">Should be enumerable CableTypesViewModel </param>
        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable enumerable = parameter as IEnumerable;
                if (enumerable == null)
                    throw new ArgumentException("parameter has to be an CableTypesViewModel.", "parameter");
                //Get selected CableTypeModels from the parameter.
                var selectedTypes = enumerable.OfType<CableTypesViewModel>().ToList();

                //Ask if user realy wants to delete this item.
                var dialog = MessageBox.Show("Do you want to delete selected cable types from the database?", "Warning", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    // Get Ids of the selected elements
                    var selectedCableTypesId = selectedTypes.Where(i => i.IsSelected).Select(i => i.Id);
                    using (var db = new SQlite.ApplicationContext())
                    {
                        //Find the cableReels in the database
                        var cableTypes = db.CableTypes.Where(i => selectedCableTypesId.Contains(i.Id));
                        //Remove, save and update data.
                        foreach (var cableType in cableTypes)
                        {
                            db.CableTypes.Remove(cableType);
                        }
                        db.SaveChanges();
                    }
                    _cableTypesPageViewModel.UpdateData();
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); }

        }
    }
}
