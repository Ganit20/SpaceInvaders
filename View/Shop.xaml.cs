using SpaceInvaders.Model;
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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        GameWindow Window;
        public Shop(GameWindow w)
        {
            Window = w;
            InitializeComponent();
            Weapons.ItemsSource = new WeaponList().Weapons;
            Ships.ItemsSource = new ShipList().Ships;
        }

        private void WeaponChoosed(object sender, SelectionChangedEventArgs e)
        {
            var weapon =(Weapon)Weapons.SelectedItem;
            WeaponStats.DataContext = weapon;
            if (weapon.Unlock == false) WeaponBuy.IsEnabled = true; 
            else WeaponBuy.IsEnabled = false; 

        }
        private void Clicked_Play(object sender, RoutedEventArgs e)
        {
            //var a = new Stats();
            //MainWindow.Stats.Navigate(a);
        }

        private void CategoryChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = ShopCategories.SelectedIndex;
            switch(a)
            {
                case 0:
                    ShipsField.Visibility = Visibility.Collapsed;
                    WeaponField.Visibility = Visibility.Visible;
                    Weapons.Visibility = Visibility.Visible;
                    Ships.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    WeaponField.Visibility = Visibility.Collapsed;
                    ShipsField.Visibility = Visibility.Visible; 
                    Weapons.Visibility = Visibility.Collapsed;
                    Ships.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void BuyWeapon(object sender, RoutedEventArgs e)
        {
            var a = (Weapon)Weapons.SelectedItem;
            if (MainMenu.prof.Money >= a.Price)
            {
                MainMenu.prof.WeaponsUnlocked.Add(Weapons.SelectedIndex);
                MainMenu.prof.Money = MainMenu.prof.Money - a.Price;
            } 
        }

        private void BuyShip(object sender, RoutedEventArgs e)
        {
            var a = (Ship)Ships.SelectedItem;
            if (MainMenu.prof.Money >= a.Price)
            {
                MainMenu.prof.ShipsUnlocked.Add(Ships.SelectedIndex);
                MainMenu.prof.Money = MainMenu.prof.Money - a.Price;
                MainMenu.prof.SUnlocked.Add(new ShipList().Ships[Ships.SelectedIndex]);
                new Save(MainMenu.prof);
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window.MainFrame.NavigationService.GoBack();
        }

        private void ShipChoosed(object sender, SelectionChangedEventArgs e)
        {
            var ship = (Ship)Ships.SelectedItem;
            ShipStats.DataContext = ship;
            if (ship.Unlock == false) ShipBuy.IsEnabled = true;
            else ShipBuy.IsEnabled = false;
        }
    }
}
