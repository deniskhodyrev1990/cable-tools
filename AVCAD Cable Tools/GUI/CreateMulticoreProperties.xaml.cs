using AVCAD.Models;
using AVCAD.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для CreateMulticoreProperties.xaml
    /// </summary>
    public partial class CreateMulticoreProperties : Window
    {

        public ViewModels.CableViewModel Cable { get; set; }
        public Models.CableType CableType { get; set; }
        public CreateMulticoreProperties()
        {
            InitializeComponent();
        }


        public CreateMulticoreProperties(CableViewModel cableViewModel, List<CableType> cableTypes) : this()
        {
            Cable = cableViewModel;
            DataContext = Cable;
            CableTypesComboBox.ItemsSource = cableTypes;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            CableType = (Models.CableType)CableTypesComboBox.SelectedValue;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
