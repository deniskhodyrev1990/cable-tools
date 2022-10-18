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

        public CableListViewModel()
        {
            LoadExcelFileCommand = new Commands.LoadExcelFileCommand(this);

            _cables = new ObservableCollection<CableViewModel>();


        }
    }
}
