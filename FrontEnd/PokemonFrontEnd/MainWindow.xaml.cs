using PokemonShared.Models;
using PokemonFrontEnd.View;
using System.Windows;

namespace PokemonFrontEnd
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected readonly WelcomePageView welcomePageView;
        protected CharacterInfoView characterInfoView;

        public MainWindow()
        {
            InitializeComponent();

            //ResourceManager RM = new ResourceManager("PokemonResources.ResourceFile.fr-FR", Assembly.LoadFrom("PokemonResources.dll"));
            //string msg = RM.GetString("M_NonExitCharacter");

            welcomePageView = new WelcomePageView();
            MainContentArea.Children.Add(welcomePageView);

            IconExit.MouseLeftButtonDown += IconExit_MouseLeftButtonDown;
        }

        private void IconExit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IconExit.MouseLeftButtonDown -= IconExit_MouseLeftButtonDown;
            Application.Current.Shutdown();
        }

        internal void DisplaySearchResults(string searchedText) => SearchResultsView.Display(searchedText);

        internal void DisplayCharacterInfo(Character character)
        {
            if(MainContentArea.Children.Contains(welcomePageView)) MainContentArea.Children.Remove(welcomePageView);
            if(characterInfoView==null)
            {
                characterInfoView = new CharacterInfoView();
                MainContentArea.Children.Add(characterInfoView);
            }
            characterInfoView.Display(character);
        }
    }
}
