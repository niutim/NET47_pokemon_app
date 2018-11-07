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
        private Specifications _specifications;

        public Character CurrentCharacter {
			get { return _character; }
			set { _character = value; GetAverageSpecificationsAsync(); OnPropertyChanged("CurrentCharacter"); }
		}

        public Specifications AverageSpecifications
        {
            get { return _specifications; }
            set { _specifications = value; OnPropertyChanged("AverageSpecifications"); }
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
                    CurrentCharacter = character;
                    MainWindow main = Application.Current.MainWindow as PokemonFrontEnd.MainWindow;
                    if (main != null) main.TopCharactersView.Refresh();
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
        }

        private async void GetAverageSpecificationsAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Specifications> task = CharacterService.GetAverageSpecificationsAsync(_character.Classes);
            Specifications specifications = await task;
            if (task.IsCompleted)
                AverageSpecifications = (specifications == null) ? new Specifications() : specifications;
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
