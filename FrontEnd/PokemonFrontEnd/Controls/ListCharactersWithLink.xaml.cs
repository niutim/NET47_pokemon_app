using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using PokemonFrontEnd.Services;
using System.Threading.Tasks;
using PokemonShared.Models;

namespace PokemonFrontEnd.Controls
{
    /// <summary>
    /// Logique d'interaction pour ListCharactersWithLink.xaml
    /// </summary>
    public partial class ListCharactersWithLink : UserControl
    {
        public ListCharactersWithLink()
        {
            InitializeComponent();
        }

        public bool ShowPosition { get; set; }

        // Dependency Property
        public static readonly DependencyProperty ListCharactersProperty =
             DependencyProperty.Register("ListCharacters", typeof(Character[]),
             typeof(ListCharactersWithLink), new FrameworkPropertyMetadata(null, OnListCharactersPropertyChanged));

        // .NET Property wrapper
        public Character[] ListCharacters
        {
            get { return (Character[])GetValue(ListCharactersProperty); }
            set { SetValue(ListCharactersProperty, value); }
        }

        private static void OnListCharactersPropertyChanged(DependencyObject source,
        DependencyPropertyChangedEventArgs e)
        {
            ListCharactersWithLink control = source as ListCharactersWithLink;
            control.rankingListStackPanel.Children.Clear();
            Character[] listCharacters = (Character[])e.NewValue;
            if (listCharacters != null)
            {
                listCharacters.ToList().ForEach(character => AddLinkedElement(control, character));
            }
        }

        private static void AddLinkedElement(ListCharactersWithLink control, Character character)
        {

            TextBlock textBlockCharacterName = new TextBlock();
            textBlockCharacterName.Margin = new Thickness(10, 5, 0, 0);
            textBlockCharacterName.FontSize = 16;
            textBlockCharacterName.Text = character.Name;
            textBlockCharacterName.Foreground = Brushes.Navy;
            textBlockCharacterName.Cursor = Cursors.Hand;

            if (control.ShowPosition)
            {

                StackPanel stackPanelElement = new StackPanel();
                stackPanelElement.Orientation = Orientation.Horizontal;
                stackPanelElement.Cursor = Cursors.Hand;
                stackPanelElement.Tag = character.Id;

                stackPanelElement.MouseLeftButtonDown += FrameworkElement_MouseLeftButtonDown;

                TextBlock textBlockRankingNumber = new TextBlock();
                textBlockRankingNumber.Margin = new Thickness(20, 5, 0, 0);
                textBlockRankingNumber.FontSize = 16;
                textBlockRankingNumber.Text = (control.rankingListStackPanel.Children.Count + 1).ToString();
                textBlockRankingNumber.Foreground = Brushes.Navy;
                textBlockRankingNumber.Cursor = Cursors.Hand;

                stackPanelElement.Children.Add(textBlockRankingNumber);
                stackPanelElement.Children.Add(textBlockCharacterName);

                control.rankingListStackPanel.Children.Add(stackPanelElement);

            }
            else
            {
                textBlockCharacterName.Tag = character.Id;
                textBlockCharacterName.MouseLeftButtonDown += FrameworkElement_MouseLeftButtonDown;
                control.rankingListStackPanel.Children.Add(textBlockCharacterName);
            }
        }

        private static void FrameworkElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null) return;
            int? id = frameworkElement.Tag as int?;
            if(id.HasValue) DisplayElementAsync(id.Value);

        }

        private static async void DisplayElementAsync(int id)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Character> task = CharacterService.GetCharacterByIdAsync(id);
            Character character = await task;
            if (task.IsCompleted)
            {
                if (character != null)
                {
                    MainWindow main = Application.Current.MainWindow as MainWindow;
                    if (main != null)
                    {
                        main.DisplayCharacterInfo(character);
                    }
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
        }
    }
}
