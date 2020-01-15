using SpaceInvaders.Model;
using SpaceInvaders.View;
using SpaceInvaders.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpaceInvaders.Weapons.RailLaser
{
    class RailShoot
    {
        FrameworkElement Shooter;
        FirstLevel Level;
        public void Add(FrameworkElement shooter,FirstLevel level,Weapon laser)
        {
            Task.Factory.StartNew(() =>
           {
               Shooter = shooter;
               Level = level;
               Level.Dispatcher.Invoke(async () =>
               {
                   
                   DispatcherTimer colision = new DispatcherTimer();
                   colision.Tick += CheckColision;
                   Level.Field.Children.Add(laser);
                   colision.Interval = new TimeSpan(0, 0, 0, 0, 30);
                   colision.Start();
                   await Task.Delay(1500);
                   colision.Stop();
                   
               });

           });
            
        }

        public void Remove(Weapon laser, FirstLevel level)
        {
            level.Field.Children.Remove(laser);

        }

        void CheckColision(object sender, EventArgs e)
        {
            new Collision().IsCollision(Shooter, Level.Field, Level);
        }
    }
}
