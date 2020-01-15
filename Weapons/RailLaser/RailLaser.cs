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
            RailLaserOne.Height = shooter.ActualHeight;
            RailLaserOne.TeamId = teamid;
            return RailLaserOne;
        }

        private readonly Weapon RailLaserOne = new Weapon()
        {
            BulletWidth = 30,
            BulletTexture = new BitmapImage(new Uri("/Assets/Sprites/RailBullet.png", UriKind.Relative)),
        };
    }
}



