using System.Windows.Input;

namespace WPF_Tut9_MVVM.ViewModels
{
    internal class ButtonsViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ButtonsViewModel(ICommand addCommand, ICommand deleteCommand)
        {
            AddCommand = addCommand;
            DeleteCommand = deleteCommand;
        }
    }
}
