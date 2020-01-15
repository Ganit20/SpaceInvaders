using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using SpaceInvaders.View;
using SpaceInvaders.Model;

namespace SpaceInvaders.ViewModel
{
    class Bullet
    {
        Weapon weapon; 
        FirstLevel MainWindow;
        DispatcherTimer Tranform = new DispatcherTimer();
        public Bullet(FirstLevel mainWindow,Weapon gun)
        {
            MainWindow = mainWindow;
            weapon = gun;
            var p = weapon.Shooter.TranslatePoint(new Point(0, 0), MainWindow.Field);
            Canvas.SetTop(gun, p.Y);
            Canvas.SetLeft(gun, p.X);
            Tranform.Interval = new TimeSpan(0, 0, 0, 0, 25);
            Tranform.Tick += new EventHandler(MoveBullet);
            Tranform.Start();
            mainWindow.Field.Children.Add(gun);
        }
        void MoveBullet(object sender, EventArgs e)
        {
            if (weapon != null)
            {
                var actualTop = weapon.TranslatePoint(new Point(0, 0), MainWindow.Field);
                Canvas.SetTop(weapon, actualTop.Y - (weapon.BulletSpeed * weapon.TeamId));
                Canvas canvas;
                if(weapon.TeamId < 0)
                {
                    canvas = MainWindow.Plaayer;
                }
                else 
                { 
                  canvas= MainWindow.Enemy; 
                }
                var collision = new Collision().IsCollision(weapon, canvas,MainWindow);
                if (collision!=null)
                {
                    RemoveBullet();
                    try
                    {
                        var a = (Enemy)collision;
                        a.AI.Stop();
                    }catch(Exception)
                    {

                    }
                    canvas.Children.Remove(collision);
                    Tranform.Stop();
                }
                if (actualTop.Y < 0)
                {
                    RemoveBullet();
                    Tranform.Stop();
                }if(MainWindow.ActualHeight<= actualTop.Y)
                {
                    RemoveBullet();
                    Tranform.Stop();
                }
            }
        }
        void RemoveBullet()
        {
            var parent = VisualTreeHelper.GetParent(weapon);
            if(parent!=null)
             (parent as Canvas).Children.Remove(weapon); 
        }
      
    }
}
