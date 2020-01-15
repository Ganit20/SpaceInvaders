using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.ViewModel
{
    interface IAiscript
    {
        public void Start(FirstLevel level);
        public void Behaviour(object sender, EventArgs e);
        public void Stop();
    }
}
