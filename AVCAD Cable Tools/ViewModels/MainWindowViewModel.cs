using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new CableListViewModel();
        }
    }
}
