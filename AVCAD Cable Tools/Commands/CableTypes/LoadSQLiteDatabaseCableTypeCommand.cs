using AVCAD.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableTypes
{
    public class LoadSQLiteDatabaseCableTypeCommand : CommandBase
    {
        private CableTypesPageViewModel cableTypePageViewModel;

        public LoadSQLiteDatabaseCableTypeCommand(CableTypesPageViewModel cableTypePageViewModel)
        {
            this.cableTypePageViewModel = cableTypePageViewModel;
        }

        public override void Execute(object? parameter)
        {
            cableTypePageViewModel.UpdateData();
        }
    }
}
