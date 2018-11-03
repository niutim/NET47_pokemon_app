using PokemonShared.Models;
using PokemonFrontEnd.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonFrontEnd.ViewModel
{
    public class SearchResultsViewModel : INotifyPropertyChanged
    {
        private string _searchedText;
        private Character[] _resultCharacters;

        public string SearchedText
        {
            get { return _searchedText; }
            set { _searchedText = value; GetSearchResultsAsync(); OnPropertyChanged("SearchedText"); }
        }

        public Character[] ResultCharacters
        {
            get { return _resultCharacters; }
            set { _resultCharacters = value; OnPropertyChanged("ResultCharacters"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private async void GetSearchResultsAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Character[]> task = CharacterService.GetCharactersContainingStringAsync(SearchedText);
            Character[] characters = await task;
            if (task.IsCompleted)
            {
                if (characters != null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    ResultCharacters = characters;
                }
            }
        }
    }
}
