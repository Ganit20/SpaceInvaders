using SpaceInvaders.Model;
using SpaceInvaders.View;
using System.Windows;

namespace SpaceInvaders.Weapons.RailLaser
{
    public interface IShootBehaviour
    {
        public void Shoot(FrameworkElement shooter, FirstLevel level, Weapon laser);
    }
}