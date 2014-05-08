using MVVMCore.Helpers;
using MVVMCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OFFer
{
    class MainWndViewModel : BaseViewModel
    {
        private bool isRun = false;
        public bool IsRun
        {
            get
            {
                return isRun;
            }
            set
            {
                isRun = value;
                RaisePropertyChanged<bool>(() => IsRun);
            }
        }
        private ICommand _runCmd = null;
        public ICommand RunCmd
        {
            get
            {
                if (_runCmd == null)
                {
                    _runCmd = new DelegateCommand(x => DoRun());
                }
                return _runCmd;
            }
        }

        private void DoRun()
        {
            IsRun = !IsRun;
            Thread ddd = new Thread(() => Fetch()) { IsBackground = true };
            ddd.Start();
        }

        private void Clean()
        {
            FTP_Connector.FTPConnector conn = new FTP_Connector.FTPConnector("31.170.164.143", 21, "451417451417", "u486381274", (x) => Log = x);
            var file = conn.ReadFile("docu2/4704831.txt");
            if (!string.IsNullOrEmpty(file))
            {
                conn.DelFile("docu2/4704831.txt");
                Log = "Find";
            }
            Log = "Cleaned";
        }
        private void Fetch()
        {
            Clean();
            while (IsRun)
            {
                //UriBuilder bld = new UriBuilder("http", "31.170.164.143","") { Password = "451417451417", UserName = "u486381274" };

                FTP_Connector.FTPConnector conn = new FTP_Connector.FTPConnector("31.170.164.143", 21, "451417451417", "u486381274", (x) => Log = x);
                var file = conn.ReadFile("docu2/4704831.txt");
                if (!string.IsNullOrEmpty(file))
                {
                    conn.DelFile("docu2/4704831.txt");
                    Log = "Find";
                    Process.Start("shutdown", "/s /f");
                }
                Thread.Sleep(1000);
            }
        }

        private string log = string.Empty;
        public string Log
        {
            get
            {
                return log;
            }
            set
            {
                log += value + Environment.NewLine;
                RaisePropertyChanged<string>(() => Log);
            }
        }
    }
}
