using SpaceInvaders.Model;
using SpaceInvaders.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SpaceInvaders.View
{

    public partial class FirstLevel : Page
    {
        private readonly int EnemyUnits = 15;
        private readonly DispatcherTimer Watch = new DispatcherTimer();
        public FirstLevel()
        {
            InitializeComponent();
            Focusable = true;
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Shoot);
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Movement);
            CenterPlayer();
            Watch.Tick += SpawnEnemy;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 200);
            Watch.Start();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() =>
                {

                    Random rand = new Random();
                    Enemy enemy = new RailLaser().GetRailLaser();
                    enemy.AI.SetObject(enemy);
                    enemy.AI.Start(this);
                    Enemy.Children.Add(enemy);
                    Canvas.SetLeft(enemy, rand.Next((int)Math.Round(enemy.ActualWidth), (int)Math.Round(ActualWidth)));
                    if (Enemy.Children.Count >= EnemyUnits)
                    {
                        Watch.Stop();
                    }
                });

            });
        }

        private void CenterPlayer()
        {
            double left = (Field.ActualWidth - PlayerObject.ActualWidth) / 2;
            Canvas.SetLeft(PlayerObject, left);
        }

        private void Shoot(object Sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Weapon weapon = new BasicLaser().GetBasicLaser(PlayerObject, 1);
                new Bullet(this, weapon);
            }
        }

        private void Movement(object Sender, KeyEventArgs e)
        {
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
