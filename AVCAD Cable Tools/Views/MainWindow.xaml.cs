using AVCAD.Settings;
using AVCAD.ViewModels;
using System.Windows;
using System.Windows.Navigation;
using Frame = System.Windows.Controls.Frame;

namespace AVCAD.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void UpdateFrameDataContext(object sender, NavigationEventArgs e, ViewModelBase viewModelBase)
        {
            var content = (sender as Frame).Content as FrameworkElement;
            if (content == null)
                return;
            content.DataContext = viewModelBase;
        }

        private void CableListFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e, new CableListViewModel());
        }


        private void CableTypesFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e, new CableTypesPageViewModel());
        }

        private void CableReelsFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e, new CableReelsPageViewModel());
        }

        private void SettingsFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e, new SettingsViewModel());
        }
    }
}
