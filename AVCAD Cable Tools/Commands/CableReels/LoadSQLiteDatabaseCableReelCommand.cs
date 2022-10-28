using AVCAD.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVCAD.Commands.CableReels
{
    public class LoadSQLiteDatabaseCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel cableReelPageViewModel;

        public LoadSQLiteDatabaseCableReelCommand(CableReelsPageViewModel cableReelPageViewModel)
        {
            this.cableReelPageViewModel = cableReelPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            cableReelPageViewModel.UpdateData();
        }
    }
}
