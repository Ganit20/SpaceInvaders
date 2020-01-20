using SpaceInvaders.Weapons.RailLaser;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    public  class Weapon : Image
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        BitmapImage bulletTexture;
        public string BulletTexture
        {
            get => bulletTexture.UriSource.OriginalString;
            set {
                bulletTexture = new BitmapImage(new Uri(value, UriKind.Relative));
                Source = new BitmapImage(new Uri(value, UriKind.Relative));
        }
        }
        public int Speed { get; set; }
        public Visibility ShopVisible { get; set; }
        public int BulletSpeed { get; set; }
        public double FireRatio { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public bool Unlock { get; set; }
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
        public IShootBehaviour Shoot { get; set; }
        

    }
}
