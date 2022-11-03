using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands.CableList
{
    public class LoadExcelFileCommand : CommandBase
    {
        private readonly CableListViewModel _cableListViewModel;

        public LoadExcelFileCommand(CableListViewModel cableListViewModel)
        {
            _cableListViewModel = cableListViewModel;
        }

        public override void Execute(object? parameter)
        {
            
            var cables = Excel.ExcelMethods.GetCablesFromCableListExcel(out string fileName);

            _cableListViewModel.Clear();
            _cableListViewModel.Filename = fileName;


            foreach (var cable in cables)
                _cableListViewModel.AddCable(cable);

            foreach (var cable in _cableListViewModel.Cables)
            {
                if (cable.IsMulticore)
                {
                    var c = cables.Where(i => i.CableNumber == cable.CableNumber).First();
                    var cableNumbers = c.MulticoreMembers.Split(',').ToList();
                    foreach (var cableNumber in cableNumbers)
                    {
                        var multicoreMember = _cableListViewModel.Cables.Where(i => i.CableNumber == cableNumber).First();
                        cable.MulticoreMembers.Add(multicoreMember);
                    }
                }
            }      
        }
    }
}
