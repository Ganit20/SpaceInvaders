using SpaceInvaders.Model;
using SpaceInvaders.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders.ViewModel
{
    public class EnemyBehaviour : Behaviour ,IAiscript
    {
        private FirstLevel Level;
        public FrameworkElement Enemy;
        private int movement = 1;
        private readonly DispatcherTimer Watch = new DispatcherTimer();
        public override void Start(FirstLevel level)
        {
            Level = level;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 15);
            Watch.Tick += new EventHandler(Behaviour);
            Watch.Start();
        }
        public void Behaviour(object sender, EventArgs e)
        {
            if (Enemy != null)
            {
                Random random = new Random();
                Point CurrentPos = Enemy.TranslatePoint(new Point(0, 0), Level);
                Canvas.SetLeft(Enemy, CurrentPos.X + (5 * movement));
                if (CurrentPos.X >= Level.WindowWidth - Enemy.ActualWidth)
                {
                    movement = -1;
                }
                else if (CurrentPos.X <= 4)
                {
                    movement = 1;
                }

                if (random.Next(0, 1000) > 990)
                {
                    new Bullet().Shoot(Enemy,Level, new BasicLaser().GetBasicLaser(Enemy, -1));
                }
            }
        }
        public override void Stop()
        {
            Watch.Stop();
        }
    }


}

