using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    class BasicLaser
    {
        public Weapon GetBasicLaser(FrameworkElement shooter,int teamid)
        {
            BasicLaserOne.Shooter = shooter;
            BasicLaserOne.TeamId = teamid;
            return BasicLaserOne;
        }
      Weapon BasicLaserOne = new Weapon()
        {
            BulletHeight = 15,
            BulletWidth = 15,
            BulletTexture = new BitmapImage(new Uri("/Assets/Sprites/BasicLaser.png", UriKind.Relative)),
            BulletSpeed = 7,
        };
    }
}
