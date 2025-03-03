using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_Tut9_MVVM.Models;
using WPF_Tut9_MVVM.MVVM;

namespace WPF_Tut9_MVVM.ViewModels
{
    internal class ItemsTableViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; }

        private Item? _selectedItem;
        public Item? SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetField(ref _selectedItem, value);
                OnPropertyChanged(nameof(SelectedItem)); 
                CommandManager.InvalidateRequerySuggested(); 
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ItemsTableViewModel(ObservableCollection<Item> items)
        {
            Items = items;
            AddCommand = new RelayCommand(_ => AddItem());
            DeleteCommand = new RelayCommand(_ => DeleteItem(), _ => SelectedItem != null);
        }

        private void AddItem()
        {
            var newItem = new Item { Name = "new item", SerialNumber = "XXXX", Quantity = 1 };
            Items.Add(newItem);
        }

        private void DeleteItem()
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
                SelectedItem = null;
            }
        }
    }
}