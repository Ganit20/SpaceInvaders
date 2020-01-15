using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    public class Ship : Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Texture
        {
            get
            {
                return Texture;
            }
            set
            {
                this.Source = value;
            }
        }
        public int Speed { get; set; }
        public int Price { get; set; }
    }
}
