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

        public string? CableNumber => _cable.CableNumber;
        public string? SysnameOut => _cable.SysnameOut;
        public string? ConnectorOut => _cable.ConnectorOut;
        public string? PortOut => _cable.PortOut;
        public string? LocationOut => _cable.LocationOut;
        public string? ModelOut => _cable.ModelOut;
        public string? SysnameIn => _cable.SysnameIn;
        public string? ConnectorIn => _cable.ConnectorIn;
        public string? PortIn => _cable.PortIn;
        public string? LocationIn => _cable.LocationIn;
        public string? ModelIn => _cable.ModelIn;
        public string? CableType => _cable.CableType?.Type;
        public double CableLength => _cable.CableLength;

        public bool IsMulticore => _cable.IsMulticore;
    

        public CableViewModel(Models.Cable cable)
        {
            _cable = cable;
        }
    }
}
