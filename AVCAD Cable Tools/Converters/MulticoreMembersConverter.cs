using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using AVCAD.ViewModels;

namespace AVCAD.Converters
{
    /// <summary>
    /// This converter is for representing the multicore as a string in Datagrid.
    /// </summary>
    [ValueConversion(typeof(ObservableCollection<CableListViewModel>), typeof(string))]
    public class MulticoreMembersConverter : IValueConverter
    {

        /// <summary>
        /// Default convert method
        /// </summary>
        /// <param name="value">Multicore Members</param>
        /// <param name="targetType">Sting</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var multicoreMembers = (ObservableCollection<CableViewModel>)value;
            multicoreMembers = new ObservableCollection<CableViewModel>((multicoreMembers ?? new ObservableCollection<CableViewModel>()).OrderBy(i => i.CableNumber) );

            return String.Join(", ", multicoreMembers);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
