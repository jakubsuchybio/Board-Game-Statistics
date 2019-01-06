using BoardGameStats.Core.Helpers;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BoardGameStats.Core.ViewModels
{
    public sealed class MainPageViewModel : INotifyPropertyChanged
    {
        private string _inputName;
        private bool _selectionEnabled;
        private object[] _selectedItems;

        public ObservableCollection<Data> DataList { get; } = new ObservableCollection<Data>
        {
            new Data {Name = "Kuba", TimesKicked =  0 }
        };

        public string InputName
        {
            get => _inputName;
            set
            {
                _inputName = value;
                OnPropertyChanged(nameof(InputName));
            }
        }

        public bool SelectionEnabled
        {
            get => _selectionEnabled;
            set
            {
                _selectionEnabled = value;
                OnPropertyChanged(nameof(SelectionEnabled));
            }
        }

        public object[] SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
            }
        }

        public RelayCommand AddPlayerCommand { get; }
        public RelayCommand ResetGameCommand { get; }
        public RelayCommand DeleteSelectionCommand { get; }

        public MainPageViewModel()
        {
            AddPlayerCommand = new RelayCommand(AddPlayer);
            ResetGameCommand = new RelayCommand(ResetGame);
            DeleteSelectionCommand = new RelayCommand(DeleteSelection);
        }

        private void AddPlayer()
        {
            string name = InputName;
            DataList.Add(new Data { Name = name, TimesKicked = 0 });
        }

        private async void DeleteSelection()
        {
            if (SelectedItems == null || SelectedItems.Length == 0)
                return;

            bool result = await DialogHelper.ConfirmationDialogAsync("Are you sure you want to delete selected names?", "Yes", "No");
            if (!result)
                return;

            foreach (object selectedItem in SelectedItems)
                DataList.Remove((Data) selectedItem);
        }

        private async void ResetGame()
        {
            bool result = await DialogHelper.ConfirmationDialogAsync("Are you sure you want to reset game?", "Yes", "No");
            if (!result)
                return;

            foreach (Data data in DataList)
                data.TimesKicked = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}