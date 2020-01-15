using SpaceInvaders.View;
using System;

namespace SpaceInvaders.ViewModel
{
    internal interface IAiscript
    {
        public void Start(FirstLevel level);
        public void Behaviour(object sender, EventArgs e);
        public void Stop();
    }
}
