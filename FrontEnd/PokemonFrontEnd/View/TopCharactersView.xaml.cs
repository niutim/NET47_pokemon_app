using PokemonFrontEnd.ViewModel;
using System.Windows.Controls;

namespace PokemonFrontEnd.View
{
	/// <summary>
	/// Logique d'interaction pour TopCharactersView.xaml
	/// </summary>
	public partial class TopCharactersView : UserControl
	{
		public TopCharactersView()
		{
			InitializeComponent();
            populateComboBox();
            this.DataContext = new TopCharactersViewModel();
            ListControl.DataContext = this.DataContext;
            this.Loaded += TopCharactersView_Loaded;
		}

        public void populateComboBox()
		{
			topCountComboBox.DisplayMemberPath = "Text";
            topCountComboBox.SelectedValuePath = "Value";
            var items = new[] {
				new { Text = "First 5", Value = "5" },
				new { Text = "First 10", Value = "10" },
				new { Text = "First 20", Value = "20" },
				new { Text = "First 50", Value = "50" }};

			topCountComboBox.ItemsSource = items;
		}

        public void Refresh()
        {
            TopCharactersViewModel viewModel = this.DataContext as TopCharactersViewModel;
            if(viewModel!=null) viewModel.Refresh();
        }

        private void TopCharactersView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Loaded -= TopCharactersView_Loaded;
            this.topCountComboBox.SelectedValue = 5;
        }
    }
}
