using MVVMCore.Helpers;
using MVVMCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FTPGUIBackupper
{
    class NotifyIconViewModel : BaseViewModel
    {
        private DelegateCommand _showWndCmd;
        public ICommand ShowWndCmd
        {
            get
            {
                if (_showWndCmd == null)
                {
                    _showWndCmd = new DelegateCommand((x) => OnShowWndCmd());
                }
                return _showWndCmd;
            }
        }
        private void OnShowWndCmd()
        {
            App.Current.MainWindow.Hide();
            App.Current.MainWindow.Show();
        }
        private DelegateCommand _hideWindowCommand;
        public ICommand HideWindowCommand
        {
            get
            {
                if (_hideWindowCommand == null)
                {
                    _hideWindowCommand = new DelegateCommand((x) => OnHideWindowCommand());
                }
                return _hideWindowCommand;
            }
        }

        public object IsRun
        {
            get
            {
                dynamic dyn = App.Current.MainWindow.DataContext;
                return dyn.IsRun;
            }
        }
        public bool IsOpen
        {
            set
            {
                RaisePropertyChanged<object>(() => IsRun);
            }
        }


        private void OnHideWindowCommand()
        {
            App.Current.MainWindow.Hide();
        }
        private DelegateCommand _exitApplicationCommand;
        public ICommand ExitApplicationCommand
        {
            get
            {
                if (_exitApplicationCommand == null)
                {
                    _exitApplicationCommand = new DelegateCommand((x) => OnExitApplicationCommand());
                }
                return _exitApplicationCommand;
            }
        }

        private void OnExitApplicationCommand()
        {
            App.Current.MainWindow.Close();
        }
    }
}
