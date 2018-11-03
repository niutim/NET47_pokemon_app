using System.Windows.Controls;

namespace PokemonFrontEnd.Controls
{
    /// <summary>
    /// Logique d'interaction pour Titles.xaml
    /// </summary>
    public partial class Title : UserControl
    {
        public Title()
        {
            InitializeComponent();
        }

        public object TitleLabelContent
        {
            get { return this.TitleLabel.Content; }
            set { this.TitleLabel.Content = value; }
        }
    }
}
