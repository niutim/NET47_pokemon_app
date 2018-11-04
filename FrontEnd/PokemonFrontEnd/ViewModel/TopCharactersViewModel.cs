using PokemonShared.Models;
using PokemonFrontEnd.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonFrontEnd.ViewModel
{
	public class TopCharactersViewModel : INotifyPropertyChanged
	{
		private int _countValue;
        private Character[] _listCharacters;

		public int CountValue
		{
			get { return _countValue; }
			set { _countValue = value; TopCountChangedAsync(); OnPropertyChanged("CountValue"); }
		}

        public Character[] ListCharacters
        {
            get { return _listCharacters; }
            set { _listCharacters = value; OnPropertyChanged("ListCharacters"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Refresh()
        {
            TopCountChangedAsync();
        }

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}

        private async void TopCountChangedAsync()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Task<Character[]> task = CharacterService.GetTopXXCharacterAsync(CountValue);
            Character[] characters = await task;
            if (task.IsCompleted)
            {
                if (characters != null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    ListCharacters = characters;
                }
            }
        }
    }
}
