using AVCAD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public CreateEditCableReel(CableReel cableReel, ObservableCollection<CableType> cableTypes) : this(cableReel)
        {
            CableTypesComboBox.ItemsSource = cableTypes;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
