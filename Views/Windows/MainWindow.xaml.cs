using System.Windows;
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
