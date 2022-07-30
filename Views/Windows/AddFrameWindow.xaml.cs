using FramingWorkshop.Controller;
using System.Windows;

namespace FramingWorkshop.View
{
    /// <summary>
    /// Логика взаимодействия для AddFrameWindow.xaml
    /// </summary>
    public partial class AddFrameWindow : Window
    {
        internal Frame Frame { get; private set; }
        internal AddFrameWindow(Frame f)
        {
            InitializeComponent();
            Frame = f;
            DataContext = new AddFrameVM();
        }
    }
}
