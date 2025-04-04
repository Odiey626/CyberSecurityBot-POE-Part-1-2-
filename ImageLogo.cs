using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagelogo
{
    internal class Program
    {
        public static void LogoImage()
        {

            //get app full path
            string paths = AppDomain.CurrentDomain.BaseDirectory;

            //then replace the bin\\bebug\\
            string new_path = paths.Replace("bin\\Debug\\", "");

            //then combine the logo and the image
            string full_path = Path.Combine(new_path, "Cyber_Security_Bot_Logo.png");
            Console.WriteLine(full_path);
            //then start working on the ascii
            Bitmap Logo = new Bitmap(full_path);
            Logo = new Bitmap(Logo, new Size(150, 110));

            for (int height = 0; height < Logo.Height; height++)
            {
                //for width
                for (int width = 0; width < Logo.Width; width++)
                {
                    Color pixelColor = Logo.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                    Console.Write(asciiChar);

                }
                Console.WriteLine();
            }
        }
    }
}
