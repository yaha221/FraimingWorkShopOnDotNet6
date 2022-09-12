using System.Windows;
using System.Windows.Controls;
using FraimingWorkShop.ViewModels;

namespace FraimingWorkShop.Views.Windows 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FraimingWorkShopVM();
            
        }

    }
}
