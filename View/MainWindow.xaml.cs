﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using View.ViewModel;
using PrettyHairLibrary;
namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public OrderListViewModel OLVM;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            

        }

    }
}
