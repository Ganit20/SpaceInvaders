using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SpaceInvaders.Model
{
    public class Ship : Image,IShip, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public int Id { get; set; }
        public string ItemName { get; set; }
        BitmapImage texture;
        public string Texture
        {
            get => texture.UriSource.ToString();
            set
            {
                texture = new BitmapImage(new Uri(value, UriKind.Relative));
                Source = new BitmapImage(new Uri(value, UriKind.Relative));
            }
        }
        public int Speed { get; set; }
        public int Price { get; set; }
         double actualHP { get; set; }
        bool death { get; set; }
        public bool Unlock { get; set; }
        public Weapon weapon { get; set; }
        public double ActualHP { get
            {
                return actualHP;
            }
            set
            {
                actualHP = value;
                OnPropertyChanged("ActualHP");
            }
        }
        public double MaxHP { get; set; }
        public FirstLevel Level { get; set; }
        public void GetDamage(double Damage, Canvas canvas)
        {
            ActualHP -= Damage;
            if(ActualHP<=0)
            {
                 Death(canvas);
                death = true;
                canvas.Children.Remove(this);
            }
        }
        public async Task Death(Canvas canvas)
        {
            if(death!=true)
          await  new Animator().Animate(this, "/Assets/Sprites/Explosions/", "Explosion", 7);
           
            Level.NavigationService.Navigate(new GameOver());

        }
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
