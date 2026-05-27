using IWshRuntimeLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using static DropletScreenmate.Config;

namespace DropletScreenmate
{
    public partial class App : System.Windows.Application
    {
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenu;
        public ToolStripMenuItem _checkItem;
        private static string lnkPath, appPath;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CheckLnk();

            _checkItem = new ToolStripMenuItem("Run at Startup")
            {
                CheckOnClick = true,
                Checked = start
            };

            // Crear menú contextual.
            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.Add("Options", null, ShowOptions);
            _contextMenu.Items.Add(_checkItem);
            _contextMenu.Items.Add("About", null, ShowAbout);
            _contextMenu.Items.Add("Exit", null, ExitApp);

            _checkItem.Click += StartWith;

            Uri uri = new Uri("pack://application:,,,/icon.ico");
            using (Stream icon = GetResourceStream(uri)?.Stream)
            {
                // Crear NotifyIcon.
                _notifyIcon = new NotifyIcon
                {
                    Icon = new Icon(icon),
                    Visible = true,
                    Text = "Droplet Screenmate",
                    ContextMenuStrip = _contextMenu
                };
            }

            _notifyIcon.DoubleClick += (s, args) => ShowOptions(s, args);
        }

        private void CheckLnk()
        {
            // Checar si se incia al prender la PC, por medio del acceso directo en la carpeta Inicio.
            lnkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\Droplet Screenmate.lnk");
            appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (System.IO.File.Exists(lnkPath))
            {
                start = true;
            }
        }

        private void ShowOptions(object sender, EventArgs e)
        {
            Skin optionsDlg = new Skin();
            optionsDlg.Show();
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            About optionsDlg = new About();
            optionsDlg.Show();
        }

        private void ExitApp(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            _contextMenu.Dispose();
            _checkItem.Dispose();
            _notifyIcon.Dispose();
            Shutdown();
        }

        private static void StartWith(object sender, EventArgs e)
        {
            // Iniciar al momento de encender la PC, dependiendo del Config.ini
            if (!start)
            {
                // Crear acceso directo en la carpeta de Inicio.
                WshShell shell = new WshShell();

                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(lnkPath);
                shortcut.TargetPath = appPath;
                shortcut.Description = "A pet running on your desktop.";
                shortcut.Save();

                start = true;
            }
            else
            {
                // Eliminar el acceso directo para que no se inicie con la PC.
                if (System.IO.File.Exists(lnkPath))
                {
                    System.IO.File.Delete(lnkPath);
                    start = false;
                }
            }

            Console.WriteLine("Run at Startup: " + start.ToString().ToLower());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Librerar _notifyIcon solo si no ha sido liberado
            _notifyIcon?.Dispose();
            base.OnExit(e);
        }
    }
}
