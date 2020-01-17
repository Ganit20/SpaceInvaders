using Newtonsoft.Json;
using SpaceInvaders.Model;
using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpaceInvaders.ViewModel
{
    class Save
    {
        public Save(Profile prof)
        {
            using(var writer = new StreamWriter("Profile.si"))
            {
                var save = JsonConvert.SerializeObject(prof);
                writer.WriteLine(save);
            }
        }
    }
}
