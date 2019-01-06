using System.ComponentModel;
using GalaSoft.MvvmLight.Command;

namespace BoardGameStats.Core.ViewModels
{
    public sealed class Data : INotifyPropertyChanged
    {
        private string _name;
        private int _timesKicked;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int TimesKicked
        {
            get => _timesKicked;
            set
            {
                if (value < 0)
                    return;

                _timesKicked = value;
                OnPropertyChanged(nameof(TimesKicked));
            }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand RemoveCommand { get; }

        public Data()
        {
            AddCommand = new RelayCommand(() => TimesKicked++);
            RemoveCommand = new RelayCommand(() => TimesKicked--);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}