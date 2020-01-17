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
        public  List<int> WeaponsUnlocked { get; set; }
        public  List<int> ShipsUnlocked { get; set; }
    }
}
