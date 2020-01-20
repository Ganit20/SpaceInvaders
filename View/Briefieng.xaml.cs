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
        Weapon wChoosed;
        Ship sChoosed;
        public Briefieng(GameWindow w)
        {
            InitializeComponent();
            window = w;
            MyGuns.ItemsSource = MainMenu.prof.WUnlocked;
            MyShips.ItemsSource = MainMenu.prof.SUnlocked;
        }

        private void PlayV(object sender, RoutedEventArgs e)
        {
            var a = new Stats();
            window.MainFrame.Navigate(new FirstLevel(a,sChoosed,wChoosed));
            window.Stats.Navigate(a);
        }

        private void ShopV(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Shop(window));
        }

        private void GunChoose(object sender, SelectionChangedEventArgs e)
        {
            var a = (Weapon)MyGuns.SelectedItem;

            if (a != null) {
                wChoosed = a;
                if (sChoosed != null)
                { Play.IsEnabled = true; }
                Guns.DataContext = a; }
        }

        private void ShipChoose(object sender, SelectionChangedEventArgs e)
        {
            var a = (Ship)MyShips.SelectedItem;
            if (a != null)
            {
                sChoosed = a;
                if (wChoosed != null)
                { Play.IsEnabled = true; }
                Ships.DataContext = a;
            }
        }
    }
}
