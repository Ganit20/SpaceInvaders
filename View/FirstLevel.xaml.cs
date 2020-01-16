using SpaceInvaders.Model;
using SpaceInvaders.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SpaceInvaders.View
{

    public partial class FirstLevel : Page
    {
        private readonly int EnemyUnits = 15;
        private readonly DispatcherTimer Watch = new DispatcherTimer();
        public Ship PlayerObject;
        Stats stats;
        DateTime Shot; 
        public FirstLevel(Stats s)
        {
            stats = s;
            InitializeComponent();
            Focusable = true;
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Shoot);
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Movement);
            SpawnPlayer();
            Watch.Tick += SpawnEnemy;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 200);
            Watch.Start();
            Shot = DateTime.Now;
            
        }
        void SpawnPlayer()
        {
            Ship ship = new Ship() { Texture = new BitmapImage(new Uri("/Assets/Sprites/Basic_Ship.png", UriKind.Relative)),
            Height = 70,
            Width = 70,  
            Name = "Player",
            Speed = 20,
            MaxHP=20,
            ActualHP=20};
            ship.weapon = new BasicLaser().GetBasicLaser(ship,1);
            PlayerObject = ship;
            this.Plaayer.Children.Add(ship);
            Canvas.SetBottom(ship, 10);
            Canvas.SetLeft(ship, this.ActualWidth / 2);
            stats.HPBar.DataContext = ship;
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

       
          
        private async void Shoot(object Sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space && (DateTime.Now - Shot).TotalMilliseconds>=1000/PlayerObject.weapon.FireRatio)
            {
                Weapon weapon = new BasicLaser().GetBasicLaser(PlayerObject, 1);
                new Bullet(this, weapon);
                Shot = DateTime.Now;
               
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
