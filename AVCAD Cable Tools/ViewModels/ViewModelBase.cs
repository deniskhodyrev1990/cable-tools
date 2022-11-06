using System.ComponentModel;

namespace AVCAD.ViewModels
{
    /// <summary>
    /// Implementation of the INotifyPropertyChanged interface.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Realisation of the standards OnPropertyChanged Method.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
