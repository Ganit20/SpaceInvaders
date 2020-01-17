using SpaceInvaders.Model;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Weapons.RailLaser
{
    internal class RailLaser
    {
        public Weapon GetRailLaser(FrameworkElement shooter, int teamid)
        {
            RailLaserOne.Shooter = shooter;
            RailLaserOne.TeamId = teamid;
            return RailLaserOne;
        }

        public readonly Weapon RailLaserOne = new Weapon()
        {
            ItemName = "Rail Gun",
            FireRatio=0.5,
            Damage= 1,
            BulletWidth = 30,
            Price = 1500,
            BulletTexture = new BitmapImage(new Uri("/Assets/Sprites/RailBullet.png", UriKind.Relative)),
        };
    }
}



