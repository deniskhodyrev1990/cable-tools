using AVCAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.ViewModels
{
    public class CableViewModel: ViewModelBase
    {
        private readonly Models.Cable _cable;
        private bool isSelected;

        public string? CableNumber => _cable.CableNumber;
        public string? SysnameOut => _cable.SysnameOut;
        public string? ConnectorOut => _cable.ConnectorOut;
        public string? PortOut => _cable.DescriptionOut;
        public string? LocationOut => _cable.LocationOut;
        public string? ModelOut => _cable.ModelOut;
        public string? SysnameIn => _cable.SysnameIn;
        public string? ConnectorIn => _cable.ConnectorIn;
        public string? PortIn => _cable.DescriptionIn;
        public string? LocationIn => _cable.LocationIn;
        public string? ModelIn => _cable.ModelIn;
        public string? CableType => _cable.CableType?.Type;
        public double CableLength {
            get
            {
                return _cable.CableLength;
            }
            set
            {
                _cable.CableLength = value;
            }
        }

        public bool IsMulticore
        {
            get
            {
                return _cable.IsMulticore;
            }
            set
            {
                _cable.IsMulticore = value;
                OnPropertyChanged("IsMulticore");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }



        public CableViewModel(Models.Cable cable)
        {
            _cable = cable;
        }
    }
}
