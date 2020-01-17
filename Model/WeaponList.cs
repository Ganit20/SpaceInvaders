using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpaceInvaders.Model
{
    class WeaponList
    {
        public static ObservableCollection<Weapon> Weapons = new ObservableCollection<Weapon>();
        public WeaponList()
        {
            
        }
    }
}
