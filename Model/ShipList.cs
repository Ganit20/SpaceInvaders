using SpaceInvaders.PlayerShips.BasicShip;
using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpaceInvaders.Model
{
    class ShipList
    {
        public ObservableCollection<Ship> Ships = new ObservableCollection<Ship>();
        public ShipList()
        {
            Ships.Add(new BasicShip().GetBasicShip());
            CheckLock();
        }
        void CheckLock()
        {
            foreach(var ship in MainMenu.prof.ShipsUnlocked)
            {
                Ships[ship].Unlock = true;
            }
        }
    }
}
