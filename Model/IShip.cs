using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Model
{
    interface IShip
    {
       public void GetDamage(double Damage) { }
       public void Death() { }

    }
}
