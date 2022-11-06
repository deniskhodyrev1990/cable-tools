using AVCAD.Models;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// Cable reel view model
    /// </summary>
    public class CableReelViewModel: ViewModelBase
    {
        private bool isSelected;
        private readonly CableReel _cableReel;
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

        /// <summary>
        /// Default constructor from the CableReel
        /// </summary>
        /// <param name="cableReel">CableReel</param>
        public CableReelViewModel(CableReel cableReel)
        {
            _cableReel = cableReel;
        }
    }
}
