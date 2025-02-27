using System.Collections.ObjectModel;
using WPF_Tut9_MVVM.Models;
using WPF_Tut9_MVVM.MVVM;

namespace WPF_Tut9_MVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; } = [];

        private Item? _selectedItem;

        public MainWindowViewModel()
        {
            for (var i = 1; i < 10; i++)
            {
                Items.Add(new Item
                    {
                        Name = $"Product{i}",
                        SerialNumber = $"000{i}",
                        Quantity =  i * 2
                    });
            }
        }

        public Item? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);

        private void AddItem()
        {
            Items.Add(new Item
                {
                  Name  = "new item",
                  SerialNumber = "XXXX",
                  Quantity = 1
                });
        }

        private void DeleteItem()
        {
            if (SelectedItem != null) Items.Remove(SelectedItem);
        }
    }
}
