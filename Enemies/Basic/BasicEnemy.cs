using SpaceInvaders.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Model
{
    internal class BasicEnemy
    {
        public Enemy GetBasicEnemy()
        {
            Enemy e = new Enemy()
            {
                Id = 1,
                Name = "Basic Enemy",
                Texture = new BitmapImage(new Uri("/Enemies/Basic/sprites/BasicEnemy.png", UriKind.Relative)),
                Speed = 5,
                MaxHP = 10,
                actualHP = 10,
                LootPoints = 1,
                AI = new EnemyBehaviour()
            };
            return e;
        }

    }
}
