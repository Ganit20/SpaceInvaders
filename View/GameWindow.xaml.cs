using SpaceInvaders.View;
using System.Windows;

namespace SpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainMenu(this));
        }

    }
}
