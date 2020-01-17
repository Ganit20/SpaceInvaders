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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        public Shop()
        {
            InitializeComponent();
            WeaponList.Weapons.Add(new BasicLaser().GetBasicLaser(null, 1));
            WeaponList.Weapons.Add(new Weapons.RailLaser.RailLaser().GetRailLaser(null, 1));
            Weapons.ItemsSource = WeaponList.Weapons;
        }

        private void WeaponChoosed(object sender, SelectionChangedEventArgs e)
        {
            var weapon =(Weapon)Weapons.SelectedItem;
            WeaponStats.DataContext = weapon;

        }
        private void Clicked_Play(object sender, RoutedEventArgs e)
        {
            //var a = new Stats();
            //MainWindow.Stats.Navigate(a);
        }
    }
}
