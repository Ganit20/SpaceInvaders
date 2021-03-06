﻿using SpaceInvaders.Model;
using System.Windows;
using System.Windows.Controls;

namespace SpaceInvaders.View
{
    public partial class MainMenu : Page
    {
        private readonly GameWindow MainWindow;
        public static Profile prof;
        public MainMenu(GameWindow Window,Profile _prof)
        {
            
            prof = _prof;
            foreach (var item in _prof.ShipsUnlocked)
            {
                var ship = new ShipList().Ships[item];
                ship.Unlock = true;
                prof.SUnlocked.Add(ship);
            }
            foreach (var item in _prof.WeaponsUnlocked)
            {
                var weapon = new WeaponList().Weapons[item];
                weapon.Unlock = true;
                prof.WUnlocked.Add(weapon);
            }
            MainWindow = Window;
            InitializeComponent();
 
        }


        private void Play_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.MainFrame.Navigate(/*new FirstLevel(a)*/new Briefieng(MainWindow));
            MainWindow.Stats.Navigate(/*new FirstLevel(a)*/new PlayerStats());
            
        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
