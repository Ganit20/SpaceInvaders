using SpaceInvaders.Model;
using SpaceInvaders.View;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SpaceInvaders.ViewModel
{
     class Bullet
    {
        private readonly Weapon weapon;
        private readonly FirstLevel MainWindow;
        private readonly DispatcherTimer Tranform = new DispatcherTimer();
        public Bullet(FirstLevel mainWindow, Weapon gun)
        {
            MainWindow = mainWindow;
            weapon = gun;
            Point p = weapon.Shooter.TranslatePoint(new Point(0, 0), MainWindow.Field);
            Canvas.SetTop(gun, p.Y);
            Canvas.SetLeft(gun, p.X);
            Tranform.Interval = new TimeSpan(0, 0, 0, 0, 25);
            Tranform.Tick += new EventHandler(MoveBullet);
            Tranform.Start();
            mainWindow.Field.Children.Add(gun);
           
        }

        private void MoveBullet(object sender, EventArgs e)
        {
            if (weapon != null)
            {
                 Point actualTop = weapon.TranslatePoint(new Point(0, 0), MainWindow.Field);
                Canvas.SetTop(weapon, actualTop.Y - (weapon.BulletSpeed * weapon.TeamId));
                Canvas canvas;
                if (weapon.TeamId < 0)
                {
                    canvas = MainWindow.Plaayer;
                }
                else
                {
                    canvas = MainWindow.Enemy;
                }
                FrameworkElement collision = new Collision().IsCollision(weapon, canvas, MainWindow);
                if (collision != null)
                    
                {
                    RemoveBullet();
                    try
                    {
                         Enemy a = (Enemy)collision;
                        
                        a.GetDamage(weapon.Damage,canvas);
                    }
                    catch (Exception)
                    {

                    }
                    
                    Tranform.Stop();
                }
                if (actualTop.Y < 0)
                {
                    RemoveBullet();
                    Tranform.Stop();
                }
                if (MainWindow.ActualHeight <= actualTop.Y)
                {
                    RemoveBullet();
                    Tranform.Stop();
                }
            }
        }

        private void RemoveBullet()
        {
            DependencyObject parent = VisualTreeHelper.GetParent(weapon);
            if (parent != null)
            {
                (parent as Canvas).Children.Remove(weapon);
            }
        }

    }
}
