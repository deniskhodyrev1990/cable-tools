using AVCAD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AVCAD.ViewModels
{
    public class CableViewModel : ViewModelBase
    {
        private readonly Models.Cable _cable;
        private bool isSelected;
        private ObservableCollection<CableViewModel> multicoreMembers;
        private double cableLength;

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
        public double CableLength
        {
            get
            {
                return cableLength;
            }
            set
            {
                cableLength = value;
                if (IsMulticore)
                {
                    foreach (var c in MulticoreMembers)
                    {
                        if (c.CableLength != cableLength)
                            ChangeMulticoreLength(c,cableLength);
                    }
                }
                OnPropertyChanged("CableLength");
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


        public ObservableCollection<CableViewModel> MulticoreMembers
        {
            get
            {
                return multicoreMembers;
            }

            set
            {
                if (multicoreMembers != value && value != null)
                {
                    multicoreMembers = value;
                    OnPropertyChanged("MulticoreMembers");
                }

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

        public void RemoveMulticoreMember(ViewModels.CableViewModel cvm)
        {
            MulticoreMembers.Remove(cvm);
            OnPropertyChanged("MulticoreMembers");
        }

        public void ChangeMulticoreLength(ViewModels.CableViewModel cvm, double length)
        {
            cvm.CableLength = length;
            OnPropertyChanged("CableLength");
        }

        public override string ToString()
        {
            return this.CableNumber;
        }
    }
}
