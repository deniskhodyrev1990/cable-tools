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
    }
}
