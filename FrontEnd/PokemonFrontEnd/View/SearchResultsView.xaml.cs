using PokemonFrontEnd.ViewModel;
using System.Windows.Controls;

namespace PokemonFrontEnd.View
{
    /// <summary>
    /// Logique d'interaction pour SearchResultsView.xaml
    /// </summary>
    public partial class SearchResultsView : UserControl
    {
        public SearchResultsView()
        {
            InitializeComponent();
            this.DataContext = new SearchResultsViewModel();
            ResultListControl.DataContext = this.DataContext;
        }

        internal void Display(string searchedText)
        {
            SearchResultsViewModel viewModel = this.DataContext as SearchResultsViewModel;
            if (viewModel != null) viewModel.SearchedText = searchedText;
        }
    }
}
