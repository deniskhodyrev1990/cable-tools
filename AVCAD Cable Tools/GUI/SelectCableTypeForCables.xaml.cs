using AVCAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AVCAD.GUI
{
    /// <summary>
    /// Логика взаимодействия для SelectCableTypeForCables.xaml
    /// </summary>
    public partial class SelectCableTypeForCables : Window
    {
        public Models.CableType CableType { get; set; }

        public SelectCableTypeForCables()
        {
            InitializeComponent();
        }

        public SelectCableTypeForCables(List<CableType> cableTypes, Models.CableType cableType): this()
        {
            CableTypesComboBox.ItemsSource = cableTypes;
            CableType = cableType;
            DataContext = CableType;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            //CableType = (Models.CableType)CableTypesComboBox.SelectedItem;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
