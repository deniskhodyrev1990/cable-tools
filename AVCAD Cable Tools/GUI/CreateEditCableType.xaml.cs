using AVCAD.Models;
using System.Windows;

namespace AVCAD.GUI
{
    /// <summary>
    /// Логика взаимодействия для CreateEditCableType.xaml
    /// </summary>
    public partial class CreateEditCableType : Window
    {
        public CableType CableType { get; set; }
        public CreateEditCableType(CableType cableType)
        {
            InitializeComponent();
            CableType = cableType;
            DataContext = CableType;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
