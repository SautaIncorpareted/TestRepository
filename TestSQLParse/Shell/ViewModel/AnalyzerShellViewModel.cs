using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCore.ViewModels;
using System.Collections.ObjectModel;
using MVVMCore.Helpers;
using System.Windows.Input;

namespace AnalyzerShell.ViewModel
{
    public class AnalyzerShellViewModel : BaseViewModel
    {
        private DelegateCommand addToWindows;
        public ICommand AddToWindowsCmd
        {
            get
            {
                if (addToWindows == null)
                {
                    addToWindows = new DelegateCommand((x) => OnAddToWindows(), null);
                }
                return addToWindows;
            }
        }


        private void OnAddToWindows()
        {
            Windows.Add(new FileViewModel());
        }
        public ObservableCollection<FileViewModel> Windows
        {
            get
            {
                return _windows;
            }
            set
            {
                _windows = value;
            }
        }
        private ObservableCollection<FileViewModel> _windows = new ObservableCollection<FileViewModel>();
    }
}
