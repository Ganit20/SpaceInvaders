using SpaceInvaders.Model;
using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using SpaceInvaders.Weapons.RailLaser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SpaceInvaders.Weapons.Double_Laser
{
    class DoubleShoot: IShootBehaviour
    {
        private  Weapon weapon;
        private  Weapon weapon1;
        private  FirstLevel MainWindow;
        private readonly DispatcherTimer Tranform = new DispatcherTimer();
        public void Shoot(FrameworkElement shooter,FirstLevel mainWindow, Weapon gune)
        {
            MainWindow = mainWindow;
            Weapon gun = new DoubleLaser().GetDoubleLaser(shooter, gune.TeamId);
            weapon = gun;
            Weapon gun1 = new DoubleLaser().GetDoubleLaser(shooter,gune.TeamId);
            weapon1 = gun1;
            Point p = weapon.Shooter.TranslatePoint(new Point(0, 0), MainWindow.Field);
            Point p1 = weapon.Shooter.TranslatePoint(new Point(0, 0), MainWindow.Field);
            Canvas.SetTop(gun, p.Y);
            Canvas.SetLeft(gun, p.X);
            Canvas.SetTop(gun1, p.Y);
            Canvas.SetLeft(gun1, p.X+weapon1.Shooter.ActualWidth);
            Tranform.Interval = new TimeSpan(0, 0, 0, 0, 25);
            Tranform.Tick += new EventHandler(MoveBullet);
            Tranform.Start();
              mainWindow.Field.Children.Add(gun);
            mainWindow.Field.Children.Add(gun1);

        }

        private void MoveBullet(object sender, EventArgs e)
        {
            if (weapon != null)
            {
                       Point actualTop = weapon.TranslatePoint(new Point(0, 0), MainWindow.Field);
                Canvas.SetTop(weapon, actualTop.Y - (weapon.BulletSpeed * weapon.TeamId));
                Canvas.SetTop(weapon1, actualTop.Y - (weapon1.BulletSpeed * weapon1.TeamId));
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
                FrameworkElement collision1 = new Collision().IsCollision(weapon1, canvas, MainWindow);
                if (collision != null)

                {
                    RemoveBullet(weapon);
                    try
                    {
                        Enemy a = (Enemy)collision;

                        a.GetDamage(weapon.Damage, canvas);
                    }
                    catch (Exception)
                    {

                    }

                    Tranform.Stop();
                }else if(collision1!=null)
                {
                    RemoveBullet(weapon1);
                    try
                    {
                        Enemy a = (Enemy)collision;

                        a.GetDamage(weapon1.Damage, canvas);
                    }
                    catch (Exception)
                    {

                    }
                }
                if (actualTop.Y < 0)
                {
                    RemoveBullet(weapon);
                    RemoveBullet(weapon1);
                    Tranform.Stop();
                }
                if (MainWindow.ActualHeight <= actualTop.Y)
                {
                    RemoveBullet(weapon);
                    RemoveBullet(weapon1);
                    Tranform.Stop();
                }
            }
        }

        private void RemoveBullet(Weapon bullet)
        {
            System.Windows.DependencyObject parent = VisualTreeHelper.GetParent(bullet);
            if (parent != null)
            {
                (parent as Canvas).Children.Remove(bullet);
            }
        }
    }
}
