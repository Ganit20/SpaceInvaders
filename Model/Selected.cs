using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpaceInvaders.Model
{
    class Selected
    {
        static Ship selectedShip;
        public static Ship SelectedShip { get
            {
                return selectedShip;
            }
            set 
            {
                selectedShip = value;
            } }
        static Weapon selectedWeapon;
        public static Weapon SelectedWeapon
        {
            get
            {
                return selectedWeapon;
            }
            set
            {
                selectedWeapon = value;
            }
        }
    }

}
