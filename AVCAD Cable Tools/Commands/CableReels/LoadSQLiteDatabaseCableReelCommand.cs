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
    /// <summary>
    /// Command to load all cable reels from database.
    /// </summary>
    public class LoadSQLiteDatabaseCableReelCommand : CommandBase
    {
        private CableReelsPageViewModel cableReelPageViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableReelPageViewModel"></param>
        public LoadSQLiteDatabaseCableReelCommand(CableReelsPageViewModel cableReelPageViewModel)
        {
            this.cableReelPageViewModel = cableReelPageViewModel;
        }

        /// <summary>
        /// Call update method from the view model
        /// </summary>
        /// <param name="parameter">It is not used here.</param>
        public override void Execute(object? parameter)
        {
            cableReelPageViewModel.UpdateData();
        }
    }
}
