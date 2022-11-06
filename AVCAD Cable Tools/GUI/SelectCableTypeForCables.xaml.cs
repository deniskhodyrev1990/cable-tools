using AVCAD.Models;
using System.Collections.Generic;
using System.Windows;

namespace AVCAD.GUI
{
    /// <summary>
    /// Логика взаимодействия для SelectCableTypeForCables.xaml
    /// </summary>
    public partial class SelectCableTypeForCables : Window
    {
        public CableType CableType { get; set; }

        public SelectCableTypeForCables()
        {
            InitializeComponent();
        }

        public SelectCableTypeForCables(List<CableType> cableTypes, CableType cableType): this()
        {
            CableTypesComboBox.ItemsSource = cableTypes;
            CableType = cableType;
            DataContext = CableType;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            //CableType = (CableType)CableTypesComboBox.SelectedItem;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
