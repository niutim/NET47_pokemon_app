using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PokemonFrontEnd.Controls
{
    /// <summary>
    /// Logique d'interaction pour ListClasses.xaml
    /// </summary>
    public partial class ListClasses : UserControl
    {
        public ListClasses()
        {
            InitializeComponent();
        }

        // Dependency Property
        public static readonly DependencyProperty ListClassesNameProperty =
             DependencyProperty.Register("ListClassesName", typeof(string[]),
             typeof(ListClasses), new FrameworkPropertyMetadata(null, OnListClassesNamePropertyChanged));

        // .NET Property wrapper
        public string[] ListClassesName
        {
            get { return (string[])GetValue(ListClassesNameProperty); }
            set { SetValue(ListClassesNameProperty, value); }
        }

        private static void OnListClassesNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ListClasses control = source as ListClasses;
            control.classesListStackPanel.Children.Clear();
            string[] listClasses = (string[])e.NewValue;
            if (listClasses != null)
            {
                listClasses.ToList().ForEach(className => AddClass(control, className));
            }
        }

        private static void AddClass(ListClasses control, string classname)
        {

            TextBlock textBlockClassName = new TextBlock();
            textBlockClassName.Margin = new Thickness(10, 5, 0, 0);
            textBlockClassName.FontWeight = FontWeights.Black;
            textBlockClassName.Text = classname;
            control.classesListStackPanel.Children.Add(textBlockClassName);
        }

    }
}
