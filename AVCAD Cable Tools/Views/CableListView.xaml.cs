using System.Windows;
using System.Windows.Controls;

namespace AVCAD.Views
{
    /// <summary>
    /// Логика взаимодействия для CableListPage.xaml
    /// </summary>
    public partial class CableListView : Page
    {
        public CableListView()
        {
            InitializeComponent();
        }
    }

    public class BindingProxy : Freezable
    {
        public static readonly DependencyProperty DataProperty =
           DependencyProperty.Register("Data", typeof(object),
              typeof(BindingProxy));

        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion
    }
}
