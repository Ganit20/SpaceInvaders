using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    class BasicEnemy
    {
        public Enemy GetBasicEnemy()
        {
            Enemy e = new Enemy()
            {
                Id = 1,
                Name = "Basic Enemy",
                Texture = new BitmapImage(new Uri("/Assets/Sprites/BasicEnemy.png", UriKind.Relative)),
                Speed = 5,
                AI = new EnemyBehaviour()
        };
            return e;
        }
        
    }
}
