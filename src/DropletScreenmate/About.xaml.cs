using System.Diagnostics;
using System.Windows;

namespace DropletScreenmate
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void DropletScreenmate_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Process.Start("https://genesistoxical.github.io/droplet-screenmate/");
        }
    }
}
