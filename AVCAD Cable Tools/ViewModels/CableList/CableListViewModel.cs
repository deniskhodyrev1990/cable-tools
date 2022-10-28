using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AVCAD.ViewModels
{
    public class CableListViewModel: ViewModelBase
    {
        private readonly ObservableCollection<CableViewModel> _cables;

        public IEnumerable<CableViewModel> Cables => _cables;

        private string? _fileName;
        public string? Filename
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
            MakeMulticoreCommand = new Commands.CableList.MakeMulticoreCommand(this);
            CreateCutListCommand = new Commands.CableList.CreateCutListCommand(this);
            SelectCableTypeCommand = new Commands.CableList.SelectCableTypeCommand(this);
            ExcludeFromMulticoreCommand = new Commands.CableList.ExcludeFromMulticoreCommand(this);

            _cables = new ObservableCollection<CableViewModel>();
        }

        public void AddCable(Models.Cable cable)
        {
            _cables.Add(new CableViewModel(cable));
        }

        public void SetMulticoreFlag(Models.Cable cable)
        {
            //_cables.Rep(new CableViewModel(cable));
        }
    }
}
