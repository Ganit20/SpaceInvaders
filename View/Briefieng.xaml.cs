using SpaceInvaders.Model;
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
    /// Interaction logic for Briefieng.xaml
    /// </summary>
    public partial class Briefieng : Page
    {
        GameWindow window;
        public Briefieng(GameWindow w)
        {
            InitializeComponent();
            window = w;
            MyGuns.ItemsSource = MainMenu.prof.WeaponsUnlocked;
            MyShips.ItemsSource = MainMenu.prof.ShipsUnlocked;
        }

        private void PlayV(object sender, RoutedEventArgs e)
        {
            var a = new Stats();
            window.MainFrame.Navigate(new FirstLevel(a));
            window.Stats.Navigate(a);
        }

        private void ShopV(object sender, RoutedEventArgs e)
        {

        }

        private void GunChoose(object sender, SelectionChangedEventArgs e)
        {
            var a = (Weapon)sender;
            if (a != null)
                Guns.DataContext = a;
        }

        private void ShipChoose(object sender, SelectionChangedEventArgs e)
        {
            var a = (Weapon)sender;
            if(a!=null)
            Ships.DataContext = a;
        }
    }
}
