using System.Windows;
using System.Windows.Controls;

namespace SpaceInvaders.View
{
    public partial class MainMenu : Page
    {
        private readonly GameWindow MainWindow;
        public MainMenu(GameWindow Window)
        {
            MainWindow = Window;
            InitializeComponent();
        }


        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new FirstLevel());
            MainWindow.Stats.Navigate(new Stats());
        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
