using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AVCAD.ViewModels;

namespace AVCAD.CableReels
{
    /// <summary>
    /// View Model for the CutListProperties view that is inherited from the CableReelsPageViewModel
    /// </summary>
    public class CutListPropertiesViewModel : CableReelsPageViewModel
    {
        //Command to select/deselect all the checkboxes
        public ICommand SelectDeselectAllCableReelsCommand { get; set; }

        //Propfull for NameFilter that is one of the filters of a datagrid.
        private string _nameFilter;
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                if (_nameFilter == value)
                    return;
                _nameFilter = value;
                
                Filter();
                OnPropertyChanged("NameFilter");
            }
        }
        //Propfull for Typefilter that is one of the filters of a datagrid.
        private string _typeFilter;
        public string TypeFilter
        {
            get => _typeFilter;
            set
            {
                if (_typeFilter == value)
                    return;
                _typeFilter = value;

                Filter();
                OnPropertyChanged("TypeFilter");
            }
        }

        //Propfull for FilteredCollection that is the source of a datagrid.

        private ObservableCollection<CableReelViewModel> _filtered = new ObservableCollection<CableReelViewModel>();
        public ObservableCollection<CableReelViewModel> FilteredCollection
        {
            get
            {
                return _filtered;
            }
            set
            {
                if (_filtered == value)
                    return;

                _filtered = value;
                OnPropertyChanged("FilteredCollection");
            }
        }
        //I inherited this model from CableReelsPageViewModel so I just use several new props here.
        public CutListPropertiesViewModel(): base()
        {
            UpdateData();
            FilteredCollection = new ObservableCollection<CableReelViewModel>(this.CableReels);
            SelectDeselectAllCableReelsCommand = new Commands.CableReels.SelectDeselectAllCableReelsCommand(this);
            
        }

        
        /// <summary>
        /// Method that filters the initial collection. It has 4 possible options.
        /// Datagrid is connected to the FilteredCollection that depends on 2 textboxes values.
        /// </summary>
        private void Filter()
        {
            FilteredCollection.Clear();
            foreach (var item in this.CableReels)
            {
                if (!string.IsNullOrEmpty(NameFilter) && !string.IsNullOrEmpty(TypeFilter))
                {
                    FilteredCollection = new ObservableCollection<CableReelViewModel>(CableReels.Where(i => i.CableType.Contains(TypeFilter, StringComparison.OrdinalIgnoreCase) &&
                    i.Name.Contains(NameFilter, StringComparison.OrdinalIgnoreCase)));
                }
                if (string.IsNullOrEmpty(NameFilter) && !string.IsNullOrEmpty(TypeFilter))
                {
                    FilteredCollection = new ObservableCollection<CableReelViewModel>(CableReels.Where(i => i.CableType.Contains(TypeFilter, StringComparison.OrdinalIgnoreCase)));
                }
                if (!string.IsNullOrEmpty(NameFilter) && string.IsNullOrEmpty(TypeFilter))
                {
                    FilteredCollection = new ObservableCollection<CableReelViewModel>(CableReels.Where(i => i.Name.Contains(NameFilter, StringComparison.OrdinalIgnoreCase)));
                }
                if (string.IsNullOrEmpty(NameFilter) && string.IsNullOrEmpty(TypeFilter))
                {
                    FilteredCollection = new ObservableCollection<CableReelViewModel>(this.CableReels);
                }
            }
        }

    }
}
