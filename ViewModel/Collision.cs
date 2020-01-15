using System.Windows;
using System.Windows.Controls;

namespace SpaceInvaders.ViewModel
{
    internal class Collision
    {
        public FrameworkElement IsCollision(FrameworkElement UIthing, Canvas canvas, Page window)
        {
            Point cordsUIthing = UIthing.TransformToAncestor(window).Transform(new Point(0, 0));
            Rect rUIthing = new Rect(cordsUIthing.X, cordsUIthing.Y, UIthing.ActualWidth, UIthing.ActualHeight);

            foreach (FrameworkElement element in canvas.Children)
            {
                Point ElementCords = element.TransformToAncestor(window).Transform(new Point(0, 0));
                Rect r1 = new Rect(ElementCords.X, ElementCords.Y, element.ActualWidth, element.ActualHeight);
                if (r1.IntersectsWith(rUIthing))
                {
                    return element;
                }
            }
            return null;
        }
    }
}
