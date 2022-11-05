using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AVCAD.ViewModels
{
    public class CableListViewModel: ViewModelBase
    {
        public ObservableCollection<CableViewModel> Cables { get; set; }
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
                OnPropertyChanged(nameof(SysnameOutVisible));
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

        private string _fileName;
        public string Filename
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(Filename));
            }
        }


        public ICommand LoadExcelFileCommand { get; }
        public ICommand SaveExcelFileCommand { get; }
        public ICommand MakeMulticoreCommand { get; }
        public ICommand CreateCutListCommand { get; }
        public ICommand SelectCableTypeCommand { get; }
        public ICommand ExcludeFromMulticoreCommand { get; }

        public CableListViewModel()
        {
            LoadExcelFileCommand = new Commands.CableList.LoadExcelFileCommand(this);
            SaveExcelFileCommand = new Commands.CableList.SaveExcelFileCommand(this);
            MakeMulticoreCommand = new Commands.CableList.MakeMulticoreCommand();
            CreateCutListCommand = new Commands.CableList.CreateCutListCommand(this);
            SelectCableTypeCommand = new Commands.CableList.SelectCableTypeCommand();
            ExcludeFromMulticoreCommand = new Commands.CableList.ExcludeFromMulticoreCommand(this);

            Cables = new ObservableCollection<CableViewModel>();
        }

        public void AddCable(Models.Cable cable)
        {
            Cables.Add(new CableViewModel(cable));
        }

        public void Clear()
        {
            Cables.Clear();
        }

    }
}
