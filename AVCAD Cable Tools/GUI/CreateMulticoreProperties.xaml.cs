using AVCAD.Models;
using AVCAD.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace AVCAD.GUI
{
    /// <summary>
    /// Логика взаимодействия для CreateMulticoreProperties.xaml
    /// </summary>
    public partial class CreateMulticoreProperties : Window
    {

        public CableViewModel Cable { get; set; }
        public CableType CableType { get; set; }
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
            CableType = (CableType)CableTypesComboBox.SelectedValue;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
