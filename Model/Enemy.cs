using SpaceInvaders.ViewModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    public class Enemy : Image
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
    }
}
