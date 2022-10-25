﻿using AVCAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.Commands
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
            _cableListViewModel.Filename = fileName;

            foreach (var cable in cables)
                _cableListViewModel.AddCable(cable);


        }
    }
}