using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    public class Ship : Image,IShip, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Texture
        {
            get => Texture;
            set => Source = value;
        }
        public int Speed { get; set; }
        public int Price { get; set; }
         double actualHP { get; set; }
        bool death { get; set; }
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
