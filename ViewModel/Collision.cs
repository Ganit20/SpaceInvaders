using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpaceInvaders.ViewModel
{
    class Collision
    {
        public FrameworkElement IsCollision(FrameworkElement UIthing,Canvas canvas,Page window) 
        {
            var cordsUIthing = UIthing.TransformToAncestor(window).Transform(new Point(0, 0));
            Rect rUIthing = new Rect(cordsUIthing.X, cordsUIthing.Y, UIthing.ActualWidth, UIthing.ActualHeight);

            foreach (FrameworkElement element in canvas.Children)
            {
                var ElementCords = element.TransformToAncestor(window).Transform(new Point(0, 0));
                Rect r1 = new Rect(ElementCords.X, ElementCords.Y, element.ActualWidth, element.ActualHeight);
               if(r1.IntersectsWith(rUIthing))
                    return element;

            }
                return null;
        }
    }
}
