using SpaceInvaders.Model;
using SpaceInvaders.PlayerShips.BasicShip;
using SpaceInvaders.ViewModel;
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
    /// <summary>
    /// Interaction logic for CreateProfile.xaml
    /// </summary>
    public partial class CreateProfile : Page
    {
        GameWindow window;
        public CreateProfile(GameWindow w)
        {
            window = w;
            InitializeComponent();
        }

        private void Set(object sender, RoutedEventArgs e)
        {
            var prof = new Profile();
            prof.Name = ProfileName.Text;
            prof.Money = 0;
            prof.HighestScore = 0;
            prof.ShipsUnlocked.Add(0);
            prof.WeaponsUnlocked.Add(0);
            new Save(prof); 
            window.MainFrame.Navigate(new MainMenu(window,prof));
            
        }
    }
}
