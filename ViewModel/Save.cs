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
                var profile = new Profile()
                {
                    Name = prof.Name,
                    Money = prof.Money,
                    HighestScore = prof.HighestScore,
                    WeaponsUnlocked = prof.WeaponsUnlocked,
                    ShipsUnlocked = prof.ShipsUnlocked
                };
                var save = JsonConvert.SerializeObject(profile);
                writer.WriteLine(save);
            }
        }
    }
}
