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
            var a = new Stats();
            MainWindow.MainFrame.Navigate(new FirstLevel(a));
            MainWindow.Stats.Navigate(a);
        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
