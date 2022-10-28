using AVCAD.SQlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AVCAD.ViewModels
{
    public class CableReelsPageViewModel: ViewModelBase
    {
        ApplicationContext db = new ApplicationContext();
        public ObservableCollection<ViewModels.CableReelViewModel> CableReels { get; set; }

        public ObservableCollection<Models.CableType> CableTypes{ get; set; }

        public ICommand LoadSQLiteDatabaseCableReelsCommand { get; }
        public ICommand AddCableReelCommand { get; }

        public ICommand EditCableReelCommand { get; }
        public ICommand DeleteCableReelCommand { get; }

        public CableReelsPageViewModel()
        {
            LoadSQLiteDatabaseCableReelsCommand = new Commands.CableReels.LoadSQLiteDatabaseCableReelCommand(this);
            AddCableReelCommand = new Commands.CableReels.CreateEditCableReelsCommand(this, new Models.CableReel());
            EditCableReelCommand = new Commands.CableReels.CreateEditCableReelsCommand(this);
            DeleteCableReelCommand = new Commands.CableReels.DeleteCableReelCommand(this);
            this.CableReels = new ObservableCollection<ViewModels.CableReelViewModel>();
            this.CableTypes = new ObservableCollection<Models.CableType>();
        }


        /// <summary>
        /// A method that translates Models.CableReel to ViewModels.CableReelViewModel and adds it to the current ObservableCollection
        /// </summary>
        /// <param name="cableReel">Models.CableReel from an SQLite database</param>
        public void AddCableReel(Models.CableReel cableReel)
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
