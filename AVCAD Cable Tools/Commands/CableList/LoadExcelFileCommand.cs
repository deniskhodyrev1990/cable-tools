using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands.CableList
{
    /// <summary>
    /// Command to load a list of cables and transform in to list of CableViewModels
    /// </summary>
    public class LoadExcelFileCommand : CommandBase
    {
        private readonly CableListViewModel _cableListViewModel;

        /// <summary>
        /// Constructor with the viewmodel for the page;
        /// </summary>
        /// <param name="cableListViewModel"></param>
        public LoadExcelFileCommand(CableListViewModel cableListViewModel)
        {
            _cableListViewModel = cableListViewModel;
        }

        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter">It is not used here.</param>
        public override void Execute(object? parameter)
        {
            //Get the cables from the excel file
            try
            {
                var cables = Excel.ExcelMethods.GetCablesFromCableListExcel(out string fileName);

                //If we click Cancel or X button then we won't have a filename. May stop here.
                if (!string.IsNullOrEmpty(fileName))
                {
                    //Clear previous values
                    _cableListViewModel.Clear();
                    //Set the filename
                    _cableListViewModel.Filename = fileName;
                    //First iterations is for creating the CableViewModels from Models.Cable
                    foreach (var cable in cables)
                        _cableListViewModel.AddCable(cable);
                    //Second iteration to set all the connections between the multicore members.
                    foreach (var cable in _cableListViewModel.Cables)
                    {
                        //if cable is multicores then it is necessary to find all the date from Models.Cable with multicores
                        if (cable.IsMulticore)
                        {
                            //Find first, split multicores, find CableViewModels, add to collection. Done.
                            var c = cables.Where(i => i.CableNumber == cable.CableNumber).First();
                            // TODO Exception if can not split.
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
            catch (Exceptions.ExcelHeadersException) { return; }
        }
    }
}
