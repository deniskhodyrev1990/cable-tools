using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AVCAD.ViewModels.Settings
{
    public class SettingsViewModel: ViewModelBase
    {
        public bool SysnameOutVisible
        {
            get
            {
                return Properties.Settings.Default.SysnameOutVisibility;
            }
            set
            {
                Properties.Settings.Default.SysnameOutVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("SysnameOutVisible");
            }
        }
        public bool ConnectorOutVisible
        {
            get
            {
                return Properties.Settings.Default.ConnectorOutVisibility;
            }
            set
            {
                Properties.Settings.Default.ConnectorOutVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("ConnectorOutVisible");
            }
        }

        public bool PortOutVisible
        {
            get
            {
                return Properties.Settings.Default.PortOutVisibility;
            }
            set
            {
                Properties.Settings.Default.PortOutVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("PortOutVisible");
            }
        }

        public bool ModelOutVisible
        {
            get
            {
                return Properties.Settings.Default.ModelOutVisibility;
            }
            set
            {
                Properties.Settings.Default.ModelOutVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("ModelOutVisible");
            }
        }

        public bool LocationOutVisible
        {
            get
            {
                return Properties.Settings.Default.LocationOutVisibility;
            }
            set
            {
                Properties.Settings.Default.LocationOutVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("LocationOutVisible");
            }
        }

        public bool SysnameInVisible
        {
            get
            {
                return Properties.Settings.Default.SysnameInVisibility;
            }
            set
            {
                Properties.Settings.Default.SysnameInVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("SysnameInVisible");
            }
        }
        public bool ConnectorInVisible
        {
            get
            {
                return Properties.Settings.Default.ConnectorInVisibility;
            }
            set
            {
                Properties.Settings.Default.ConnectorInVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("ConnectorInVisible");
            }
        }

        public bool PortInVisible
        {
            get
            {
                return Properties.Settings.Default.PortInVisibility;
            }
            set
            {
                Properties.Settings.Default.PortInVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("PortInVisible");
            }
        }

        public bool ModelInVisible
        {
            get
            {
                return Properties.Settings.Default.ModelInVisibility;
            }
            set
            {
                Properties.Settings.Default.ModelInVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("ModelInVisible");
            }
        }

        public bool LocationInVisible
        {
            get
            {
                return Properties.Settings.Default.LocationInVisibility;
            }
            set
            {
                Properties.Settings.Default.LocationInVisibility = value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("LocationInVisible");
            }
        }

        public string PathToDatabase
        {
            get
            {
                return Properties.Settings.Default.PathToDatabase;
            }
            set
            {
                Properties.Settings.Default.PathToDatabase = value;
                Properties.Settings.Default.Save();
                OnPropertyChanged(nameof(PathToDatabase));
            }
        }

        public ICommand ChangeDatabaseLocationCommand { get; }

        public SettingsViewModel()
        {
            ChangeDatabaseLocationCommand = new Commands.Settings.ChangeDatabaseLocationCommand(this);
        }

    }
}
