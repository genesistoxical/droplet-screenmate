using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace DropletScreenmate
{
    internal class Bitmaps
    {
        public static BitmapImage img_walk1;
        public static BitmapImage img_walk2;
        public static BitmapImage img_drag;
        public static BitmapImage img_idle;
        public static BitmapImage img_idleAlt;

        public static BitmapImage FreeUpBitmap(string img_path)
        {
            // Liberar bitmaps...
            string path = MainWindow.dir + "/Skins/" + Config.skin + img_path;
            Console.WriteLine(path);
           
            if (!File.Exists(path))
            {
                return null;
            }

            using (FileStream stream = File.OpenRead(path))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                bitmap.Freeze();
                return bitmap;
            }
        }

        public static void CustomBitmaps()
        {
            // Imágenes del skin, pero liberadas.
            img_walk1 = FreeUpBitmap("/walk-1.png");
            img_walk2 = FreeUpBitmap("/walk-2.png");
            img_drag = FreeUpBitmap("/drag.png");
            img_idle = FreeUpBitmap("/idle.png");
            img_idleAlt = FreeUpBitmap("/idleAlt.png");
        }

        public static void Dispose()
        {
            img_walk1 = null;
            img_walk2 = null;
            img_drag = null;
            img_idle = null;
            img_idleAlt = null;
        }
    }
}
