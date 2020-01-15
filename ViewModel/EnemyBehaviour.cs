using SpaceInvaders.Model;
using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders.ViewModel
{
    public class EnemyBehaviour :IAiscript
    {
        FirstLevel Level;
        public FrameworkElement Enemy; 
        int movement = 1;
        DispatcherTimer Watch = new DispatcherTimer();
        public void Start(FirstLevel level)
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
                var CurrentPos = Enemy.TranslatePoint(new Point(0, 0), Level);
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
                    new Bullet(Level, new BasicLaser().GetBasicLaser(Enemy, -1));
                }
            }
        }
        public void Stop()
        {
            Watch.Stop();
        }
        }


    }

