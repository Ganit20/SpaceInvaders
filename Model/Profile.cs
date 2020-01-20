using System;
using System.Collections.Generic;
using System.Text;
namespace SpaceInvaders.Model
{
    public class Profile
    {
        public  string Name { get; set; }
        public  int Money { get; set; }
        public  int HighestScore { get; set; }
        public List<int> WeaponsUnlocked = new List<int>();
        public List<int> ShipsUnlocked = new List<int>();
        public List<Weapon> WUnlocked = new List<Weapon>();
        public List<Ship> SUnlocked = new List<Ship>();
    }
}
