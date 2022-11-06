using AVCAD.Models;
using System.Collections.Generic;
using System.Windows;

namespace AVCAD.GUI
{
    /// <summary>
    /// Логика взаимодействия для CreateEditCableReel.xaml
    /// </summary>
    public partial class CreateEditCableReel : Window
    {
        public CableReel CableReel { get; set; }

        public CreateEditCableReel(CableReel cableReel)
        {
            InitializeComponent();
            CableReel = cableReel;
            DataContext = CableReel;

            
        }

        public CreateEditCableReel(CableReel cableReel, List<CableType> cableTypes) : this(cableReel)
        {
            CableTypesComboBox.ItemsSource = cableTypes;
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
