using SpaceInvaders.Model;
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
            new Load(this);
        }
        public void GameOver()
        {
            MainFrame.Navigate(new Stats());
        }

    }
}
