// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using testturistapp.Model;
using testturistapp.Viewmodel;

namespace testturistapp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel vm;
        public MainPage()
        {
            this.InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
            //SelectionBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (ItemDetailPage1));
            
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainViewModel.SelectedKategori = vm.Kategoriviser[SelectionBox.SelectedIndex];
            SelectedImage.Source = new BitmapImage(new Uri(MainViewModel.SelectedKategori.Billede));
        }
    }
}
