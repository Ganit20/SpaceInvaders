using SpaceInvaders.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SpaceInvaders.Weapons.Double_Laser
{
    class DoubleLaser
    {
        public Weapon GetDoubleLaser(FrameworkElement shooter, int teamid)
        {
            DoubleLaserOne.Shooter = shooter;
            DoubleLaserOne.TeamId = teamid;
            return DoubleLaserOne;
        }

        private readonly Weapon DoubleLaserOne = new Weapon()
        {
            Id=1,
            FireRatio = 2,
            Damage = 2,
            ItemName = "Double Laser",
            Price = 200,
            Unlock = false,
            BulletHeight = 15,
            BulletWidth = 15,
            BulletTexture = "/Assets/Sprites/BasicLaser.png",
            BulletSpeed = 7,
            Shoot=new DoubleShoot(),
        };
    }
}
