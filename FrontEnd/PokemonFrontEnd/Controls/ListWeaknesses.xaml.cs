using PokemonShared.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PokemonFrontEnd.Controls
{
    /// <summary>
    /// Logique d'interaction pour ListWeaknesses.xaml
    /// </summary>
    public partial class ListWeaknesses : UserControl
    {
        public ListWeaknesses()
        {
            InitializeComponent();
        }

        // Dependency Property
        public static readonly DependencyProperty ListWeaknessesObjectProperty =
             DependencyProperty.Register("ListWeaknessesObject", typeof(Weakness[]),
             typeof(ListWeaknesses), new FrameworkPropertyMetadata(null, OnListWeaknessesObjectPropertyChanged));

        // .NET Property wrapper
        public Weakness[] ListWeaknessesObject
        {
            get { return (Weakness[])GetValue(ListWeaknessesObjectProperty); }
            set { SetValue(ListWeaknessesObjectProperty, value); }
        }

        private static void OnListWeaknessesObjectPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ListWeaknesses control = source as ListWeaknesses;
            control.weaknessesListStackPanel.Children.Clear();
            Weakness[] ListWeaknessesObject = (Weakness[])e.NewValue;
            if (ListWeaknessesObject != null)
            {
                ListWeaknessesObject.ToList().ForEach(className => AddWeakness(control, className));
            }
        }

        private static void AddWeakness(ListWeaknesses control, Weakness weakness)
        {

            TextBlock textBlockWeakness = new TextBlock();
            textBlockWeakness.Margin = new Thickness(10, 5, 0, 0);
            textBlockWeakness.FontWeight = FontWeights.Black;
            textBlockWeakness.Text = String.Format("{0} (x{1})", weakness.ClassName, weakness.Ratio);
            control.weaknessesListStackPanel.Children.Add(textBlockWeakness);
        }

    }
}
