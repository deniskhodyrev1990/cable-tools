using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.ViewModels
{
    public class CableTypesViewModel: ViewModelBase
    {
        private bool isSelected;
        private readonly Models.CableType _cableType;
        public long Id => _cableType.Id;
        public string Type => _cableType.Type;
        public string? AWG => _cableType.AWG;
        public double? MaxLength => _cableType.MaxLength;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }

        public CableTypesViewModel(Models.CableType cableType)
        {
            _cableType = cableType;
        }

    }
}
