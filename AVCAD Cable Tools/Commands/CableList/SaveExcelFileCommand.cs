using AVCAD.ViewModels;

namespace AVCAD.Commands.CableList
{
    /// <summary>
    /// Command to save the current cablelistviewmodel to excel file
    /// </summary>
    public class SaveExcelFileCommand : CommandBase
    {
        private CableListViewModel _cableListViewModel;

        public SaveExcelFileCommand(CableListViewModel cableListViewModel)
        {
            this._cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Send this model to the method.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            Excel.ExcelMethods.SaveCableList(_cableListViewModel);
        }
    }
}
