using System;
using System.Collections.ObjectModel;
using AVCAD.Models;

namespace AVCAD.ViewModels
{

    /// <summary>
    /// ViewModel for Cable. 
    /// </summary>
    public class CableViewModel : ViewModelBase
    {
        private readonly Cable _cable;
        private bool isSelected;
        private ObservableCollection<CableViewModel> multicoreMembers;
        private double cableLength;
        private double extraLength;
        private string cableType;

        //Fields connected to Cable
        public string CableNumber => _cable.CableNumber;
        public string SysnameOut => _cable.SysnameOut;
        public string ConnectorOut => _cable.ConnectorOut;
        public string PortOut => _cable.DescriptionOut;
        public string LocationOut => _cable.LocationOut;
        public string ModelOut => _cable.ModelOut;
        public string SysnameIn => _cable.SysnameIn;
        public string ConnectorIn => _cable.ConnectorIn;
        public string PortIn => _cable.DescriptionIn;
        public string LocationIn => _cable.LocationIn;
        public string ModelIn => _cable.ModelIn;

        //Cable Type with some changing when the cable is multicore.
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

        //Cable Length with some changing when the cable is multicore.
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

        //Bool if the cable is inside the multicore
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

        //Multicore members.
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

        //Is selected flag. Obsolete.
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }
        //Extra Length with some changing when the cable is multicore.
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



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cable">Cable</param>
        public CableViewModel(Cable cable)
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

        /// <summary>
        /// Method to remove cableviewmodel from the collection
        /// </summary>
        /// <param name="cvm"></param>
        public void RemoveMulticoreMember(CableViewModel cvm)
        {
            MulticoreMembers.Remove(cvm);
            OnPropertyChanged("MulticoreMembers");
        }

        /// <summary>
        /// Method to change multicore length
        /// </summary>
        /// <param name="cvm"></param>
        /// <param name="length"></param>
        public void ChangeMulticoreLength(CableViewModel cvm, double length)
        {
            cvm.CableLength = length;
            OnPropertyChanged("CableLength");
        }

        /// <summary>
        /// Method to change multicore type
        /// </summary>
        /// <param name="cvm"></param>
        /// <param name="cableType"></param>
        private void ChangeMulticoreType(CableViewModel cvm, string cableType)
        {
            cvm.CableType = cableType;
            OnPropertyChanged("CableType");
        }

        /// <summary>
        /// method to change extra length
        /// </summary>
        /// <param name="cvm"></param>
        /// <param name="extraLength"></param>
        private void ChangeExtraLength(CableViewModel cvm, double extraLength)
        {
            cvm.ExtraLength = extraLength;
            OnPropertyChanged("ExtraLength");
        }

        /// <summary>
        /// Just override method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.CableNumber;
        }
    }
}
