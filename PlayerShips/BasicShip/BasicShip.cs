using SpaceInvaders.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.PlayerShips.BasicShip
{
    class BasicShip
    {
        public Ship GetBasicShip()
        {
            Ship ship = new Ship()
            {
                ItemName= "Basic Ship",
                Texture = "/Assets/Sprites/Basic_Ship.png",
                Height = 70,
                Width = 70,
                Name = "Player",
                Speed = 20,
                MaxHP = 20,
                ActualHP = 20,
            };
            return ship;
        }
        }
}
