using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.ViewModel
{
    class Animator
    {
        public async Task Animate(Image objToAnimate,string directoryPath,string Name,int FrameNumber,int AnimationTime=1)
        {
            for(int i =1; i<=FrameNumber;i++)
             {
                objToAnimate.Source = new BitmapImage(new Uri(directoryPath + Name + i.ToString() + ".png", UriKind.Relative));
                await Task.Delay((AnimationTime*1000)/FrameNumber);
            }
           
        }
    }
}
