using System.Windows;
using WPF_Tut9_MVVM.ViewModels;

namespace WPF_Tut9_MVVM.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            DataContext = vm;
        }
    }
}