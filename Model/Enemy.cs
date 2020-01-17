using SpaceInvaders.ViewModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    public class Enemy : Image,IShip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Texture
        {
            get => Texture;
            set => Source = value;
        }
        public int Speed { get; set; }
        public Behaviour AI { get; set; }
        public double actualHP { get; set; }
        public double MaxHP { get; set; }
        public int LootPoints { get; set; }
        public void GetDamage(double Damage,Canvas canvas)
            {
            actualHP -= Damage;
             
            if(actualHP<=0){
                DeathAsync(canvas);
            }
        }
        public async Task DeathAsync(Canvas canvas)
        {
           await new Animator().Animate(this, "/Assets/Sprites/Explosions/","Explosion",7);
            canvas.Children.Remove(this);
            AI.Stop();
            new stats().Points += LootPoints;
        }
    }
}
