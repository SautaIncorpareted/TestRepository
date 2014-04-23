using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FTPGUIBackupper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon notifyIcon;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            Launcher.RunConfigWnd();
        }



        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Visibility = Visibility.Collapsed;
            notifyIcon.CloseBalloon();
            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }
    }
}
