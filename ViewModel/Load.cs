using Newtonsoft.Json;
using SpaceInvaders.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpaceInvaders.Model
{
    class Load
    {
        public Load(GameWindow m)
        {
            if (File.Exists("Profile.si"))
            {
                Profile prof;
                using (var reader = new StreamReader("Profile.si"))
                {
                    var save = reader.ReadToEnd();
                    prof = JsonConvert.DeserializeObject<Profile>(save);
                }
                m.MainFrame.Navigate(new MainMenu(m,prof));
            }
            else
            {
                m.MainFrame.Navigate(new CreateProfile(m));
                
            }
        }
    }
}
