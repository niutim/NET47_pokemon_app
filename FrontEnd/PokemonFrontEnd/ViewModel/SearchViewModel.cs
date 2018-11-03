using System.Windows;
using PokemonFrontEnd.Services;
using PokemonFrontEnd.Utils;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PokemonShared.Models;

namespace PokemonFrontEnd.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private ICommand _clickCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public string SearchTextValue { get; set; }
       
        public ICommand ClickCommand
        {
            get {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => SearchCommandAsync(), true));
            }
            internal set { }
        }

        private async void SearchCommandAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Character> task = CharacterService.GetCharacterByNameAsync(SearchTextValue);
            Character character = await task;
            if (task.IsCompleted)
            {
                if (character != null)
                {
                    MainWindow main = Application.Current.MainWindow as MainWindow;
                    if (main != null) main.DisplaySearchResults(SearchTextValue);
                    if (main!=null) main.DisplayCharacterInfo(character);
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
                else
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    MessageBox.Show("Character not found",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
