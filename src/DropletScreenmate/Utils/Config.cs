using System;
using System.IO;
using System.Windows;
using static DropletScreenmate.MainWindow;

namespace DropletScreenmate
{
    public class Config
    {
        #region Variables
        public static string skin_iniPath, app_iniPath, skin, skinSelect;
        public static string[] skin_iniLines, app_iniLines;
        public static bool restart = false, start = false;
        #endregion

        public static void CheckConfig(string folderSkin)
        {
            // Obtener la ruta del archivo Config.ini del skin y leerlo.
            skin_iniPath = dir + "/Skins/" + folderSkin + "/Config.ini";

            try
            {
                skin_iniLines = File.ReadAllLines(skin_iniPath);
                Console.WriteLine("Config File: " + skin_iniPath);

                // Config.ini; obtiene únicamente los valores velocity y stepSize (después de "=").
                string iniVelocity = skin_iniLines[1].Split('=')[1].Trim();
                string iniStepsize = skin_iniLines[2].Split('=')[1].Trim();
                velocity = Convert.ToDouble(iniVelocity);
                stepSize = Convert.ToInt32(iniStepsize);

                bool okVelocity = true;
                bool okStepsize = true;

                // Verifica que la velocidad y stepSize sean números aceptables.
                if (velocity > 1.4 || velocity < 0.2)
                {
                    okVelocity = false;
                }
                if (stepSize > 60 || stepSize < 0)
                {
                    okStepsize = false;
                }

                if (okVelocity && okStepsize)
                {
                    Console.WriteLine("Step size = " + stepSize + " || Velocity = " + velocity);
                }
                else
                {
                    // En caso de que la configuración no sea correcta, mensaje de error...
                    MessageBoxResult result = MessageBox.Show("Invalid " + folderSkin + " skin configuration.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (result == MessageBoxResult.OK)
                    {
                        // Mostrar ventana para cambiar skin
                        Skin subWindow = new Skin();
                        subWindow.Show();
                    }
                }
            }
            catch
            {
                // En caso de que no exista Config.ini, mensaje de error...
                MessageBoxResult result = MessageBox.Show(folderSkin + " skin Config.ini file missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                // Aplicar skin y configuración por default.
                skin = "Mushroom";
                velocity = 0.2;
                stepSize = 12;

                if (result == MessageBoxResult.OK)
                {
                    // Mostrar ventana para cambiar skin
                    Skin subWindow = new Skin();
                    subWindow.Show();
                }
            }

        }

        public static void GetSkin()
        {
            try
            {
                // Obtener el skin desde el archivo Config.ini de la app.
                app_iniPath = dir + "/Config.ini";
                app_iniLines = File.ReadAllLines(app_iniPath);

                // Obtiene únicamente el nombre del skin (después de "=").
                skin = app_iniLines[1].Split('=')[1].Trim();
                Console.WriteLine("App ini path: " + app_iniPath + " Skin = " + skin);
            }
            catch
            {
                // En caso de que no exista, crear archivo Config.ini y aplicar skin por defecto.
                File.WriteAllText(dir + "/Config.ini", "Skin = Mushroom");
                skin = "Mushroom";
            }
        }
    }
}
