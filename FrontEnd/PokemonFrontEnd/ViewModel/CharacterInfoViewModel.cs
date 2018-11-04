using PokemonShared.Models;
using PokemonFrontEnd.Services;
using PokemonFrontEnd.Utils;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PokemonFrontEnd.ViewModel
{
    public class CharacterInfoViewModel : INotifyPropertyChanged
    {
        private ICommand _voteClickCommand;
        private Character _character;

        public Character CurrentCharacter {
			get { return _character; }
			set { _character = value; OnPropertyChanged("CurrentCharacter"); }
		}
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand VoteClickCommand
        {
            get
            {
                return _voteClickCommand ?? (_voteClickCommand = new CommandHandler(() => VoteCommandAsync(), true));
            }
            internal set { }
        }

        private async void VoteCommandAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Character> task = CharacterService.VoteForCharacterAsync(_character.Id);
            Character character = await task;
            if (task.IsCompleted)
            {
                if (character != null)
                {
                    MainWindow main = Application.Current.MainWindow as PokemonFrontEnd.MainWindow;
                    if (main != null)
                    {
                        main.TopCharactersView.Refresh();
                        main.DisplayCharacterInfo(character);
                    }
                    Mouse.OverrideCursor = Cursors.Arrow;
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
