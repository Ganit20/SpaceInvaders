using SpaceInvaders.Model;
using SpaceInvaders.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceInvaders.View
{

    public partial class FirstLevel : Page
    {
        int EnemyUnits = 15 ;
        DispatcherTimer Watch = new DispatcherTimer();
        public FirstLevel()
        {
            InitializeComponent();
            this.Focusable = true;
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Shoot);
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Movement);
            CenterPlayer();
            Watch.Tick += SpawnEnemy;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 200);
            Watch.Start();
        }


        void SpawnEnemy(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {

                        Random rand = new Random();
                            var enemy = new BasicEnemy().GetBasicEnemy();
                            enemy.AI.Enemy = enemy;
                            enemy.AI.Start(this);
                            this.Enemy.Children.Add(enemy);
                            Canvas.SetLeft(enemy, rand.Next((int)Math.Round(enemy.ActualWidth), (int)Math.Round(this.ActualWidth)));
                    if(Enemy.Children.Count>=EnemyUnits)
                    {
                        Watch.Stop();
                    }
                });

            });
        }
        void CenterPlayer()
        {
            double left = (Field.ActualWidth - PlayerObject.ActualWidth) / 2;
            Canvas.SetLeft(PlayerObject, left);
        }
        void Shoot(object Sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Weapon weapon = new BasicLaser().GetBasicLaser(PlayerObject, 1);
                new Bullet(this, weapon);
            } }
        void Movement(object Sender, KeyEventArgs e) { 
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                new PlayerMove(this).MoveLeft();
            }
            else if (e.Key == Key.Right || e.Key == Key.D)
            {
                new PlayerMove(this).MoveRight();
            }

        }
    }
}
