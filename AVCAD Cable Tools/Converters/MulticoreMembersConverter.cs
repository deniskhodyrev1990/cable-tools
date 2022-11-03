using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AVCAD.Converters
{
    [ValueConversion(typeof(ObservableCollection<ViewModels.CableListViewModel>), typeof(string))]
    public class MulticoreMembersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var multicoreMembers = (ObservableCollection<ViewModels.CableViewModel>)value;
            multicoreMembers = new ObservableCollection<ViewModels.CableViewModel>((multicoreMembers ?? new ObservableCollection<ViewModels.CableViewModel>()).OrderBy(i => i.CableNumber) );

            return String.Join(", ", multicoreMembers);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
