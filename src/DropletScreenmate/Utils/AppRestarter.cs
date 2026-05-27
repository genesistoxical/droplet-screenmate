using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace DropletScreenmate.Utils
{
    public static class AppRestarter
    {
        public static void Restart()
        {
            Application app = Application.Current;

            _ = app.Dispatcher.BeginInvoke(new Action(() =>
            {
                // Cerrar todas las ventanas actuales.
                foreach (Window win in app.Windows.Cast<Window>().ToList())
                {
                    win.Close();
                }

                // Crear nueva MainWindow para el nuevo skin, en el siguiente ciclo.
                _ = app.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow newSkin = new MainWindow();
                    app.MainWindow = newSkin;
                    newSkin.Show();
                    newSkin.Activate();

                }), DispatcherPriority.ApplicationIdle);

            }), DispatcherPriority.ApplicationIdle);
        }
    }
}
