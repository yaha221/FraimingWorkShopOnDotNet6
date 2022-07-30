using System;
using System.Windows;


namespace FramingWorkshop.View
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
