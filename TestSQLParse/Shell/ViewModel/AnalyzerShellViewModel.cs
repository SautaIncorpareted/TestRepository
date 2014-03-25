using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCore.ViewModels;
using System.Collections.ObjectModel;
using MVVMCore.Helpers;
using System.Windows.Input;
using AnalyzerShell.ViewModel.MDI;

namespace AnalyzerShell.ViewModel
{
    public class AnalyzerShellViewModel : BaseViewModel
    {
        public AnalyzerShellViewModel()
        {

        }

        private DelegateCommand parseSingleFile;
        public ICommand ParseSingleFile
        {
            get
            {
                if (parseSingleFile == null)
                {
                    parseSingleFile = new DelegateCommand((x) => DCA.Launcher.RunSingleParseFile(Windows), null);
                }
                return parseSingleFile;
            }
        }
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
            Windows.Add(new FileViewModel("Прохорчик ебанашка"));
        }
        public ObservableCollection<BaseViewModel> Windows
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
        private ObservableCollection<BaseViewModel> _windows = new ObservableCollection<BaseViewModel>();
    }
}
