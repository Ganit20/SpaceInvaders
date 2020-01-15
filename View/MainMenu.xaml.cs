using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpaceInvaders.View
{
    public partial class MainMenu : Page
    {
        GameWindow MainWindow;
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
