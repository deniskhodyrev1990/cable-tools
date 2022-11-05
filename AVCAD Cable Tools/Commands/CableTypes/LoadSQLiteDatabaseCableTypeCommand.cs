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
    /// <summary>
    /// Command to load/update cable types from SQLite
    /// </summary>
    public class LoadSQLiteDatabaseCableTypeCommand : CommandBase
    {
        private CableTypesPageViewModel cableTypePageViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cableTypePageViewModel">page view model</param>
        public LoadSQLiteDatabaseCableTypeCommand(CableTypesPageViewModel cableTypePageViewModel)
        {
            this.cableTypePageViewModel = cableTypePageViewModel;
        }

        /// <summary>
        /// Call for needed method to update.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            cableTypePageViewModel.UpdateData();
        }
    }
}
