using System;
using System.Windows;

namespace Aurelius
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Set up application-wide resources and services
            // Load settings, initialize data repositories, etc.

            // Create and show the main window
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}