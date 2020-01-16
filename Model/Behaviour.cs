using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SpaceInvaders.Model
{
    public abstract class Behaviour
    {

        public virtual void Start(FirstLevel level)
        {
        }
        public virtual void Stop()
        {
        }
        public virtual void SetObject(FrameworkElement value)
        {

        }
    }
}
