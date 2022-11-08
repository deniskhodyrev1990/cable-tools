using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using AVCAD.Models;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// ViewModel for the cable type page.
    /// </summary>
    public class CableTypesPageViewModel : ViewModelBase
    {
        public ObservableCollection<CableTypesViewModel> CableTypes { get; set; }
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
            AddCableTypeCommand = new Commands.CableTypes.CreateEditCableTypesCommand(this);
            EditCableTypeCommand = new Commands.CableTypes.CreateEditCableTypesCommand(this, false);
            DeleteCableTypeCommand = new Commands.CableTypes.DeleteCableTypeCommand(this);
            this.CableTypes = new ObservableCollection<CableTypesViewModel>();

            //On startup call the command to load all the data from database.
            Application.Current.Dispatcher.Invoke(
            DispatcherPriority.ApplicationIdle,
            new Action(() =>
            {
                LoadSQLiteDatabaseCableTypeCommand.Execute(this);

            }));
        }


        /// <summary>
        /// A method that translates CableType to CableTypesViewModel and adds it to the current ObservableCollection
        /// </summary>
        /// <param name="cableType">CableType from an SQLite database</param>
        public void AddCableType(CableType cableType)
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
