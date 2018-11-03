using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PokemonShared.Models;
using PokemonFrontEnd.ViewModel;

namespace PokemonFrontEnd.View
{
    /// <summary>
    /// Logique d'interaction pour CharacterInfoView.xaml
    /// </summary>
    public partial class CharacterInfoView : UserControl
    {
        public CharacterInfoView()
        {
            InitializeComponent();
            this.DataContext = new CharacterInfoViewModel();
        }

        internal void Display(Character character)
        {
            DisplayImageIfExists(character.ImageFile);
            CharacterInfoViewModel viewModel = this.DataContext as CharacterInfoViewModel;
            if(viewModel!=null) viewModel.CurrentCharacter= character;
        }

        private void DisplayImageIfExists(string imageFile)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                if (!String.IsNullOrEmpty(imageFile))
                    image.UriSource = new Uri(@"pack://application:,,,/PokemonResources;component/Images/" + imageFile);
                else
                    image.UriSource = new Uri(@"pack://application:,,,/PokemonResources;component/Images/ImageNotFound.jpg");
                image.EndInit();
                if (image != null)
                {
                    Photo.Source = image;
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite au chargement de l'image.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
