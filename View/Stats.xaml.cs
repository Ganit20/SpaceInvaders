using SpaceInvaders.Model;
using System.Windows.Controls;

namespace SpaceInvaders.View
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Page
    {
        public Stats()
        {
            InitializeComponent();
            Points.DataContext = new stats().Points;
        }
    }
}
