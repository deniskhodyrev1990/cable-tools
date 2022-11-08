using AVCAD.SQlite;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AVCAD.Models;
using System.Windows.Threading;
using System;
using System.Windows;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// View model for the CableReelsPage view
    /// </summary>
    public class CableReelsPageViewModel: ViewModelBase
    {
        //Fields
        public ObservableCollection<CableReelViewModel> CableReels { get; set; }
        public ObservableCollection<CableType> CableTypes{ get; set; }
        //Commands
        public ICommand LoadSQLiteDatabaseCableReelsCommand { get; }
        public ICommand AddCableReelCommand { get; }
        public ICommand EditCableReelCommand { get; }
        public ICommand DeleteCableReelCommand { get; }

        public CableReelsPageViewModel()
        {
            LoadSQLiteDatabaseCableReelsCommand = new Commands.CableReels.LoadSQLiteDatabaseCableReelCommand(this);
            AddCableReelCommand = new Commands.CableReels.CreateEditCableReelsCommand(this);
            EditCableReelCommand = new Commands.CableReels.CreateEditCableReelsCommand(this, false);
            DeleteCableReelCommand = new Commands.CableReels.DeleteCableReelCommand(this);
            this.CableReels = new ObservableCollection<CableReelViewModel>();
            this.CableTypes = new ObservableCollection<CableType>();

            //On startup call the command to load all the data from database.
            Application.Current.Dispatcher.Invoke(
            DispatcherPriority.ApplicationIdle,
            new Action(() =>
            {
                LoadSQLiteDatabaseCableReelsCommand.Execute(this);

            }));
        }


        /// <summary>
        /// A method that translates CableReel to CableReelViewModel and adds it to the current ObservableCollection
        /// </summary>
        /// <param name="cableReel">CableReel from an SQLite database</param>
        public void AddCableReel(CableReel cableReel)
        {
            CableReels.Add(new CableReelViewModel(cableReel));
        }

        /// <summary>
        /// A method that clears the current state and gets all the CableReels from an SQLite database
        /// </summary>
        public void UpdateData()
        {
            using (var db = new SQlite.ApplicationContext())
            {
                GetCableTypes(db);
                db.Database.EnsureCreated();
                this.CableReels.Clear();
                foreach (var cableReel in db.CableReels)
                {
                    this.AddCableReel(cableReel);
                }
            }
        }

        /// <summary>
        /// Get cable types from the database
        /// </summary>
        /// <param name="db">Database Context</param>
        public void GetCableTypes(ApplicationContext db)
        {
            db.Database.EnsureCreated();
            this.CableTypes.Clear();
            foreach (var cableType in db.CableTypes)
            {
                this.CableTypes.Add(cableType);
            }
        }
    }
}
