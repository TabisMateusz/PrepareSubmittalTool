﻿using PrepareSubmittalTool.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrepareSubmittalTool.View
{
    /// <summary>
    /// Logika interakcji dla klasy SummaryView.xaml
    /// </summary>
    public partial class SummaryView : UserControl
    {
        public SummaryView()
        {
            DataContext = new SummaryViewModel();
            InitializeComponent();
        }
    }
}