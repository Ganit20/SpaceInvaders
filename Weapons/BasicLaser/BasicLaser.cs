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
            return BasicLaserOne;
        }

        private readonly Weapon BasicLaserOne = new Weapon()
        {
            FireRatio = 2,
            Damage = 2,
            ItemName = "Basic Laser",
            Price = 0,
            Unlock = true,
            BulletHeight = 15,
            BulletWidth = 15,
            BulletTexture = "/Assets/Sprites/BasicLaser.png", 
            BulletSpeed = 7,
        };
    }
}
