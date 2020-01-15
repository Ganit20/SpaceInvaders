using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    class Weapon : Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage BulletTexture { 
            get
            {
                return BulletTexture;
            }
            set
            {
                this.Source = value;
            }
        }
        public int Speed { get; set; }
        public int BulletSpeed { get; set; }
        public int Price { get; set; }
        public double BulletWidth { 
            get
            {
                return this.ActualWidth;
            }
            set
            {
                this.Width = value;
            }
        }
        public double BulletHeight
        {
            get
            {
                return this.ActualHeight;
            }
            set
            {
                this.Height = value;
            }
        }
        public int TeamId { get; set; }
        public FrameworkElement Shooter { get; set; }
    }
}
