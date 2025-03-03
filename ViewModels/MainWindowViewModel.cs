using System.Collections.ObjectModel;
using WPF_Tut9_MVVM.Models;
using WPF_Tut9_MVVM.MVVM;

namespace WPF_Tut9_MVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ItemsTableViewModel ItemsTableViewModel { get; }
        public PanelViewModel PanelViewModel { get; }
        public ButtonsViewModel ButtonsViewModel { get; }

        public MainWindowViewModel()
        {
            var items = new ObservableCollection<Item>();
            for (var i = 1; i < 10; i++)
            {
                items.Add(new Item
                {
                    Name = $"Product{i}",
                    SerialNumber = $"000{i}",
                    Quantity = i * 2
                });
            }

            ItemsTableViewModel = new ItemsTableViewModel(items);
            PanelViewModel = new PanelViewModel(ItemsTableViewModel);
            ButtonsViewModel = new ButtonsViewModel(
                ItemsTableViewModel.AddCommand,
                ItemsTableViewModel.DeleteCommand
            );
        }
    }
}