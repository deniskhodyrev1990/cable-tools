using AVCAD.Models;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// Cable Type view model.
    /// </summary>
    public class CableTypesViewModel: ViewModelBase
    {
        private bool isSelected;
        private readonly CableType _cableType;
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

        /// <summary>
        /// ViewModel from Model
        /// </summary>
        /// <param name="cableType">CableType</param>
        public CableTypesViewModel(CableType cableType)
        {
            _cableType = cableType;
        }

    }
}
