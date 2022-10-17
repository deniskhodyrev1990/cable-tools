using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace AVCAD.VMs
{
    //VM for the Main Window
    internal class ApplicationVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Models.Cable> avcadCables = new ObservableCollection<Models.Cable>();
        public ObservableCollection<Models.Cable> AvcadCables
        {
            get { return avcadCables; }
            set
            {
                avcadCables = value;
                OnPropertyChanged("AvcadCables");
            }
        }
        public ApplicationVM()
        {
            GetData();
        }

        public ObservableCollection<Models.Cable> GetData()
        {
            AvcadCables.Clear();

            AvcadCables.Add(new Models.Cable() { CableId = "T1" });
            AvcadCables.Add(new Models.Cable() { CableId = "T2" });
            AvcadCables.Add(new Models.Cable() { CableId = "T3" });

            return AvcadCables;
        }

    }
}
