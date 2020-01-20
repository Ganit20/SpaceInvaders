using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpaceInvaders.Model
{
    class WeaponList
    {
        public  ObservableCollection<Weapon> Weapons = new ObservableCollection<Weapon>();
        public WeaponList()
        {
            Weapons.Add(new BasicLaser().GetBasicLaser(null,1));
            Weapons.Add(new Weapons.RailLaser.RailLaser().GetRailLaser(null,1));
        }
    }
}
