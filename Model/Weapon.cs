using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    internal class Weapon : Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        BitmapImage bulletTexture;
        public BitmapImage BulletTexture
        {
            get => bulletTexture;
            set {
                bulletTexture = value;
                Source = value;
        }
        }
        public int Speed { get; set; }
        public int BulletSpeed { get; set; }
        public int Price { get; set; }
        public double BulletWidth
        {
            get => ActualWidth;
            set => Width = value;
        }
        public double BulletHeight
        {
            get => ActualHeight;
            set => Height = value;
        }
        public int TeamId { get; set; }
        public FrameworkElement Shooter { get; set; }
    }
}
