using SpaceInvaders.Enemies.Rail;
using SpaceInvaders.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    internal class RailLaser
    {
        public Enemy GetRailLaser()
        {
            Enemy e = new Enemy()
            {
                Id = 2,
                Name = "Rail Laser",
                MaxHP = 25,
                actualHP = 25,
                Texture = new BitmapImage(new Uri("/Enemies/Rail/sprites/RailFly.png", UriKind.Relative)),
                Speed = 2,
                LootPoints = 4,
                AI = new RailBehaviour()
            };
            return e;
        }

    }
}
