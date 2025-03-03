using WPF_Tut9_MVVM.Models;
using System.ComponentModel;

namespace WPF_Tut9_MVVM.ViewModels
{
    internal class PanelViewModel : ViewModelBase
    {
        private readonly ItemsTableViewModel _itemsTableViewModel;

        public Item? SelectedItem
        {
            get => _itemsTableViewModel.SelectedItem;
            set
            {
                _itemsTableViewModel.SelectedItem = value;
                OnPropertyChanged();
            }
        }

        public PanelViewModel(ItemsTableViewModel itemsTableViewModel)
        {
            _itemsTableViewModel = itemsTableViewModel;
            _itemsTableViewModel.PropertyChanged += ItemsTableViewModel_PropertyChanged;
        }

        private void ItemsTableViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_itemsTableViewModel.SelectedItem))
            {
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
    }
}