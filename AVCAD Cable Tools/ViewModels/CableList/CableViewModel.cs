using AVCAD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AVCAD.ViewModels
{
    public class CableViewModel : ViewModelBase
    {
        private readonly Models.Cable _cable;
        private bool isSelected;
        private ObservableCollection<CableViewModel> multicoreMembers;
        private double cableLength;
        private double extraLength;
        private string cableType;

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

        public Visibility SysnameOutVisible
        {
            get
            {
                return Properties.Settings.Default.SysnameOutVisibility ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public string CableType
        {
            get
            {
                return cableType;
            }
            set
            {
                cableType = value;
                if (IsMulticore)
                {
                    foreach (var c in MulticoreMembers)
                    {
                        if (c.CableType != cableType)
                            ChangeMulticoreType(c, cableType);
                    }
                }
                OnPropertyChanged("CableType");
            }
        }

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

        public double ExtraLength
        {
            get
            {
                return extraLength;
            }
            set
            {
                extraLength = value;
                if (IsMulticore)
                {
                    foreach (var c in MulticoreMembers)
                    {
                        if (c.ExtraLength != extraLength)
                            ChangeExtraLength(c, extraLength);
                    }
                }
                OnPropertyChanged("ExtraLength");
            }
        }



        public CableViewModel(Models.Cable cable)
        {
            _cable = cable;
            CableLength = cable.CableLength;
            CableType = cable.CableType.Type;
            ExtraLength = cable.ExtraLength;
            MulticoreMembers = new ObservableCollection<CableViewModel>();

            if (!String.IsNullOrEmpty(cable.MulticoreMembers))
            {
                IsMulticore = true;
            }
        }

        public CableViewModel()
        {
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

        private void ChangeMulticoreType(CableViewModel cvm, string cableType)
        {
            cvm.CableType = cableType;
            OnPropertyChanged("CableType");
        }

        private void ChangeExtraLength(CableViewModel cvm, double extraLength)
        {
            cvm.ExtraLength = extraLength;
            OnPropertyChanged("ExtraLength");
        }

        public override string ToString()
        {
            return this.CableNumber;
        }
    }
}
