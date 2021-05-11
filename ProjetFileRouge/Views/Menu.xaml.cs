using ProjetFileRouge.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ProjetFileRouge
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = new UtilisateurViewModels();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logiciel développé par Michael Helinckx ©2021", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListCanaux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
