using System;
using FraimingWorkShop.ViewModels;
using System.Windows;


namespace FraimingWorkShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для FrameWindow.xaml
    /// </summary>
    public partial class FrameWindow : Window
    {
        public FrameWindow()
        {
            InitializeComponent();
            DataContext = new FrameVM();
        }
    }
}
