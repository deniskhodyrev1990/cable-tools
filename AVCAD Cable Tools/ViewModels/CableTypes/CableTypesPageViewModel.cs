using AVCAD.Models;
using AVCAD.SQlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// ViewModel for the cable type page.
    /// </summary>
    public class CableTypesPageViewModel : ViewModelBase
    {
        public ObservableCollection<ViewModels.CableTypesViewModel> CableTypes { get; set; }
        //Command to load data from the database
        public ICommand LoadSQLiteDatabaseCableTypeCommand { get; }
        //Command to add a cable type
        public ICommand AddCableTypeCommand { get; }
        //Command to edit a cable type
        public ICommand EditCableTypeCommand { get; }
        //Command to delete a cable type
        public ICommand DeleteCableTypeCommand { get; }

        public CableTypesPageViewModel()
        {
            LoadSQLiteDatabaseCableTypeCommand = new Commands.CableTypes.LoadSQLiteDatabaseCableTypeCommand(this);
            AddCableTypeCommand = new Commands.CableTypes.CreateEditCableTypesCommand(this, new Models.CableType());
            EditCableTypeCommand = new Commands.CableTypes.CreateEditCableTypesCommand(this);
            DeleteCableTypeCommand = new Commands.CableTypes.DeleteCableTypeCommand(this);
            this.CableTypes = new ObservableCollection<ViewModels.CableTypesViewModel>();

        }


        /// <summary>
        /// A method that translates Models.CableType to ViewModels.CableTypesViewModel and adds it to the current ObservableCollection
        /// </summary>
        /// <param name="cableType">Models.CableType from an SQLite database</param>
        public void AddCableType(Models.CableType cableType)
        {
            CableTypes.Add(new CableTypesViewModel(cableType));
        }

        /// <summary>
        /// A method that clears the current state and gets all the CableTypes from an SQLite database
        /// </summary>
        public void UpdateData()
        {
            using (var db = new SQlite.ApplicationContext())
            {
                //Check that the database is created.
                db.Database.EnsureCreated();
                this.CableTypes.Clear();
                foreach (var cableType in db.CableTypes)
                {
                    this.AddCableType(cableType);
                }
            }
        }
    }
}
