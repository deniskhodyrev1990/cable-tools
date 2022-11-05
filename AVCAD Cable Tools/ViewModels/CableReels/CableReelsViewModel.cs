using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.ViewModels
{
    public class CableReelViewModel: ViewModelBase
    {
        private bool isSelected;
        private readonly Models.CableReel _cableReel;
        public long Id => _cableReel.Id;
        public string Name => _cableReel.Name;
        public string? CableType => _cableReel.CableType.ToString();
        public double Length => _cableReel.Length;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(isSelected));
            }

        }

        public CableReelViewModel(Models.CableReel cableReel)
        {
            _cableReel = cableReel;
        }
    }
}
