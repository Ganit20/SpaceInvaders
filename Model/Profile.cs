using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace SpaceInvaders.Model
{
    public class Profile
    {
        public  string Name { get; set; }
        public  int Money { get; set; }
        public  int HighestScore { get; set; }
        public ObservableCollection<int> WeaponsUnlocked = new ObservableCollection<int>();
        public ObservableCollection<int> ShipsUnlocked = new ObservableCollection<int>();
        public ObservableCollection<Weapon> WUnlocked = new ObservableCollection<Weapon>();
        public ObservableCollection<Ship> SUnlocked = new ObservableCollection<Ship>();
    }
}
