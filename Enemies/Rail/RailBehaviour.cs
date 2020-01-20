using SpaceInvaders.Model;
using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using SpaceInvaders.Weapons.RailLaser;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SpaceInvaders.Enemies.Rail
{
    internal class RailBehaviour : Behaviour, IAiscript
    {
        private FirstLevel Level;
        public FrameworkElement Enemy;
        private int movement = 1;
        private DispatcherTimer Watch = new DispatcherTimer();
        private DispatcherTimer Shoot = new DispatcherTimer();
        public override void Start(FirstLevel level)
        {
            Level = level;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 15);
            Watch.Tick += new EventHandler(Behaviour);
            Watch.Start();
            Shoot.Interval = new TimeSpan(0, 0, 4);
            Shoot.Tick += new EventHandler(ShootBehaviour);
            Shoot.Start();
        }
        public override void SetObject(FrameworkElement value)
        {
            Enemy = value;
        }
        private void ShootBehaviour(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () =>
            { 
            Watch.Stop();
            await Task.Delay(400);
                var enemy = (Enemy)Enemy;
                
                await Level.Dispatcher.Invoke(async () =>
                {
                    var laser = new Weapons.RailLaser.RailLaser().GetRailLaser(Enemy, -1);
                    enemy.Texture = new BitmapImage(new Uri("/Enemies/Rail/sprites/RailShoot.png", UriKind.Relative));
                    Point ShooterPoint = Enemy.TranslatePoint(new Point(0, 0), Level.Field);
                    laser.BulletWidth = 40;
                    Canvas.SetTop(laser, ShooterPoint.Y);
                    Canvas.SetLeft(laser, ShooterPoint.X + Enemy.ActualWidth/2 - 20);
                    laser.BulletHeight = Level.ActualHeight;
                    new RailShoot().Add(Enemy, Level, laser);
                    await Task.Delay(1500);
                    new RailShoot().Remove(laser,Level);
                    enemy.Texture = new BitmapImage(new Uri("/Enemies/Rail/sprites/RailFly.png", UriKind.Relative));
                    Watch.Start();


                });
            });
            

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
            }
        }
        public override void Stop()
        {
            Shoot.Stop();
            Watch.Stop();
        }
    }


}