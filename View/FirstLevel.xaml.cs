using SpaceInvaders.Model;
using SpaceInvaders.ViewModel;
using SpaceInvaders.Weapons.Double_Laser;
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
        private readonly int EnemyUnits = 3;
        private readonly DispatcherTimer Watch = new DispatcherTimer();
        public Ship PlayerObject;
        Stats stats;
        Weapon weapon;
        DateTime Shot; 
        public FirstLevel(Stats s,Ship player,Weapon gun)
        {
            stats = s;
            InitializeComponent();
            SpawnPlayer(player, gun);
            Focusable = true;
            Application.Current.MainWindow.KeyDown += new KeyEventHandler(Controls);
            Watch.Tick += SpawnEnemy;
            Watch.Interval = new TimeSpan(0, 0, 0, 0, 200);
            Watch.Start();
            Shot = DateTime.Now;
            new stats().Points = 0;
            
        }
        void SpawnPlayer(Ship player,Weapon gun)
        {

            player.Level = this;
            gun.Shooter = player;
            player.weapon = gun;
            PlayerObject = player;
            this.Plaayer.Children.Add(player);
            Canvas.SetBottom(player, 10);
            Canvas.SetLeft(player, this.ActualWidth / 2);
            stats.HPBar.DataContext = player;
            weapon = gun;
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

       
          public static void GameOver()
        {

        }


        private void Controls(object Sender, KeyEventArgs e)
        {
            var bullet = GenereteW(weapon);
            bool ready;
            if ((DateTime.Now - Shot).TotalMilliseconds >= 1000 / PlayerObject.weapon.FireRatio)
                ready = true;
            else 
                ready = false;

            if (e.Key == Key.Space && ready==true )
            {
                    weapon.Shoot.Shoot(PlayerObject, this, weapon);
                Shot = DateTime.Now;

            }
            else if (e.Key == Key.Left || e.Key == Key.A)
            {
                new PlayerMove(this).MoveLeft();
            }
            else if (e.Key == Key.Right || e.Key == Key.D)
            {
                new PlayerMove(this).MoveRight();
            }
            else if((e.Key == Key.Right || e.Key == Key.D) && e.Key == Key.Space && ready == true)
            {
                new PlayerMove(this).MoveRight();
                weapon.Shoot.Shoot(PlayerObject,this,weapon);
                Shot = DateTime.Now;
            }
            else if ((e.Key == Key.Left || e.Key == Key.A) && e.Key == Key.Space && ready == true)
            {
                new PlayerMove(this).MoveLeft();
                weapon.Shoot.Shoot(PlayerObject, this, weapon);
                Shot = DateTime.Now;
            }

        }

        private Weapon GenereteW(Weapon w)
        {
            switch(w.Id)
            {
                case 0:
                    return new BasicLaser().GetBasicLaser(w.Shooter,w.TeamId);
                    
                case 1:
                    return new DoubleLaser().GetDoubleLaser(w.Shooter, w.TeamId);
                    
                case 2:
                    return new Weapons.RailLaser.RailLaser().GetRailLaser(w.Shooter, w.TeamId);
                    
            }
            return new BasicLaser().GetBasicLaser(w.Shooter, w.TeamId);
        }
    }
}
