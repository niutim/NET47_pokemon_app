using PokemonFrontEnd.ViewModel;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;

namespace PokemonFrontEnd.View
{
    /// <summary>
    /// Logique d'interaction pour SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
            this.DataContext = new SearchViewModel();
            this.Loaded += SearchView_Loaded;
        }

        private void SearchView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Loaded -= SearchView_Loaded;
            this.SearchTextBox.KeyDown += SearchTextBox_KeyDown;
        }

        private void SearchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton.Focus();

                ButtonAutomationPeer automation = new ButtonAutomationPeer(this.SearchButton);
                IInvokeProvider invokeProv = automation.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }
    }
}
