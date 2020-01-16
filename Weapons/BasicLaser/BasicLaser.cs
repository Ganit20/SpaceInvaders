using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    internal class BasicLaser
    {
        public Weapon GetBasicLaser(FrameworkElement shooter, int teamid)
        {
            BasicLaserOne.Shooter = shooter;
            BasicLaserOne.TeamId = teamid;
            BasicLaserOne.FireRatio = 2;
            return BasicLaserOne;
        }

        private readonly Weapon BasicLaserOne = new Weapon()
        {
            BulletHeight = 15,
            BulletWidth = 15,
            BulletTexture = new BitmapImage(new Uri("/Assets/Sprites/BasicLaser.png", UriKind.Relative)),
            BulletSpeed = 7,
        };
    }
}
