using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using static DropletScreenmate.InactiveWindow;

namespace DropletScreenmate
{
    public partial class MainWindow : Window
    {
        #region Variables
        public static DispatcherTimer timerWalk;
        private static DispatcherTimer timerIdle;

        public static int stepSize;
        public static double velocity;
        public static string dir;

        private int screenW, screenH;
        private bool idle = false, idleAlt = false;
        private bool walkLeft = true;
        #endregion

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Ventana tipo Overlay
            var hwnd = new WindowInteropHelper(this).Handle;
            int exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, exStyle
                | WS_EX_NOACTIVATE
                | WS_EX_TOOLWINDOW);
        }

        public MainWindow()
        {
            // Obtener el directorio desde donde se ejecuta la app, skin y config.
            dir = AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("\\", "/");

            InitializeComponent();
            Config.GetSkin();
            Config.CheckConfig(Config.skin);
            Bitmaps.CustomBitmaps();

            timerWalk = new DispatcherTimer();
            timerIdle = new DispatcherTimer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtener el tamaño de la pantalla sin contar la barra de tareas.
            // Se le resta 128 (tamaño de ventana de la app).
            double width = SystemParameters.WorkArea.Width - 128;
            double height = SystemParameters.WorkArea.Height - 128;
            double center = width / 2;

            screenW = (int)width;
            screenH = (int)height;

            Top = screenH;
            Left = (int)center;

            timerWalk.Tick += TimerWalk_Tick;
            timerWalk.Interval = TimeSpan.FromSeconds(velocity);
            timerWalk.Start();

            timerIdle.Tick += TimerIdle_Tick;
            timerIdle.Interval = TimeSpan.FromSeconds(60);
            timerIdle.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Mover el screenmate con el clic.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TimerWalk_Tick(object sender, EventArgs e)
        {
            double position = Left;
            Image.Source = Image.Source == Bitmaps.img_walk1 ? Bitmaps.img_walk2 : Bitmaps.img_walk1;

            // Hacer que el screenmate camine y que las imágenes cambien en modo espejo
            // dependiendo si camina hacia la izquierda o derecha.
            if (walkLeft)
            {
                Image.FlowDirection = FlowDirection.RightToLeft;
                Left = position - stepSize;
                if (position < 0) walkLeft = false;
            }
            else
            {
                Image.FlowDirection = FlowDirection.LeftToRight;
                Left = position + stepSize;
                if (position > screenW) walkLeft = true;
            }
        }

        private void TimerIdle_Tick(object sender, EventArgs e)
        {
            if (!idle) // El screenmate se quedará en modo idle.
            {
                idle = true;
                timerWalk.Stop();
                timerIdle.Interval = TimeSpan.FromSeconds(20);
                Image.Source = idleAlt ? Bitmaps.img_idleAlt : Bitmaps.img_idle;
            }
            else // ...modo idleAlt a partir de un cierta cantidad de tiempo random.
            {
                idle = false;
                idleAlt = !idleAlt;
                timerWalk.Start();
                Image.Source = Bitmaps.img_walk1;
                int random = DateTime.Now.Minute + 60;
                timerIdle.Interval = TimeSpan.FromSeconds(random);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timerWalk.Stop();
            timerIdle.Stop();
            
            Image.Source = null; // Liberar referencia explícitamente
            Bitmaps.Dispose();   // Limpieza de bitmaps
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Al soltar el screenmate, vuelve a caminar.
            Image.Source = Bitmaps.img_walk1;
            Top = screenH;
            timerWalk.Start();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Efecto de levantar al screenmate.
            timerWalk.Stop();
            Image.Source = Bitmaps.img_drag;
            walkLeft = !walkLeft;
        }
    }
}

