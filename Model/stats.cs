using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SpaceInvaders.Model
{
    class stats : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static double points;
        public  double Points { get
            {
                return points;
            } 
            set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }
         void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
