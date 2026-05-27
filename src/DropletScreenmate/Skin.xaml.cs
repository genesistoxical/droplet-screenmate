using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static DropletScreenmate.MainWindow;
using Path = System.IO.Path;

namespace DropletScreenmate
{
    public partial class Skin : Window
    {
        public Skin()
        {
            InitializeComponent();
            Folders();
            velocityNo.Text = velocity.ToString();
            stepsizeNo.Text = stepSize.ToString();
        }

        private void Folders()
        {
            string[] directories = Directory.GetDirectories(dir + "Skins");

            foreach (string filePath in directories)
            {
                skinDir.Items.Add(Path.GetFileName(filePath));
            }
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string v = velocity.ToString();
            string s = stepSize.ToString();

            if (skinDir.SelectedValue == null)
            {
                // Si la velocidad y stepsize no han cambiado
                if (velocityNo.ToString() == v && stepsizeNo.ToString() == s)
                {
                    // Do nothing
                }
                else
                {
                    // De haber cambiado, actualizar actualizar valores y timer
                    velocity = Convert.ToDouble(velocityNo.Text);
                    stepSize = Convert.ToInt16(stepsizeNo.Text);

                    timerWalk.Stop();
                    timerWalk.Interval = TimeSpan.FromSeconds(velocity);
                    timerWalk.Start();

                    // Sobreescribir valores en el archivo Config.ini del skin
                    File.WriteAllLines(Config.skin_iniPath, new[]
                    {
                        "[Config]",
                        "Velocity = " + velocityNo.Text,
                        "Step size = " + stepsizeNo.Text
                    });
                }
            }
            else
            {
                Config.skinSelect = skinDir.SelectedValue.ToString();
                Console.WriteLine("Skin Selected: " + Config.skinSelect);

                // Si el skin elegido no es el mismo que se está utilizando...
                if (Config.skinSelect != Config.skin)
                {
                    // Entonces cambió, reiniciar app al aplicar
                    Config.restart = true;
                    Close();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Config.restart)
            {
                // Cambiar al skin seleccionado en el archivo Config.ini de la app.
                Config.app_iniLines = File.ReadAllLines(dir + "/Config.ini");
                Config.app_iniLines[1] = "Skin = " + Config.skinSelect;
                File.WriteAllLines(Config.app_iniPath, Config.app_iniLines);
                Console.WriteLine(Config.skinSelect);

                // Reiniciar app 
                Utils.AppRestarter.Restart();
            }
        }

        private void UpDownButton(TextBox input, double value, double max, double min, bool add)
        {
            double current = Convert.ToDouble(input.Text);

            if (add)
            {
                if (current <= max)
                {
                    current += value;
                }
            }
            else
            {
                if (current >= min)
                {
                    current -= value;
                }
            }

            input.Text = current.ToString();
        }

        private void VelocityUp_Click(object sender, RoutedEventArgs e)
        {
            UpDownButton(velocityNo, 0.1, 1.4, 0.2, true);
        }

        private void VelocityDown_Click(object sender, RoutedEventArgs e)
        {
            UpDownButton(velocityNo, 0.1, 1.4, 0.2, false);
        }

        private void StepsizeUp_Click(object sender, RoutedEventArgs e)
        {
            UpDownButton(stepsizeNo, 1, 59, 2, true);
        }

        private void StepsizeDown_Click(object sender, RoutedEventArgs e)
        {
            UpDownButton(stepsizeNo, 1, 59, 2, false);
        }
    }
}
