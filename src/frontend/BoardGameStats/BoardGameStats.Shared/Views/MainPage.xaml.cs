using System.Linq;
using BoardGameStats.Core.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BoardGameStats
{
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel ViewModel { get; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            DataContext = ViewModel;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SelectedItems = ListView.SelectedItems.ToArray();
        }
    }
}