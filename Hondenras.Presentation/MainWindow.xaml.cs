using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hondenras.Application.Services;
using Hondenras.Domain.Models;

namespace Hondenras.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DogService _dogService;

        public MainWindow()
        {
            InitializeComponent();
            _dogService = new DogService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _dogService.InitializeAsync();
            breedComboBox.ItemsSource = _dogService.Breeds;
            await LoadNextDog();
        }

        private async Task LoadNextDog()
        {
            string imageUrl = await _dogService.GetNextDogImageAsync();
            dogImage.Source = new BitmapImage(new Uri(imageUrl));
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if(!_dogService.Guess((DogBreed)breedComboBox.SelectedItem))
            {
                feedbackTextBlock.Text = $"Fout! Het is een {_dogService.CurrentBreed}";
            }
            else
            {
                feedbackTextBlock.Text = "Juist!";
            }
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadNextDog();
        }
    }
}