﻿using AVCAD.Models;
using AVCAD.ViewModels;
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
    /// Логика взаимодействия для CutListExportProperties.xaml
    /// </summary>
    public partial class CutListExportProperties : Window
    {
        private List<CableReel> cableReels;
        private CableReelsPageViewModel cableReelsPageViewModel;

        public List<CableReel> CableReels { get; internal set; }

        public CutListExportProperties()
        {
            InitializeComponent();
        }

        public CutListExportProperties(List<CableReel> cableReels): this()
        {
            this.CableReels = cableReels;
            CableReelsListView.DataContext = CableReels;
            //CableReelsListView.ItemsSource = CableReels;
        }

        public CutListExportProperties(CableReelsPageViewModel cableReelsPageViewModel):this()
        {
            this.cableReelsPageViewModel = cableReelsPageViewModel;
            DataContext = cableReelsPageViewModel;
        }

        private void SubmitBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelBNT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}