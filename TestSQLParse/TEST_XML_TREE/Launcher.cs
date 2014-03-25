using DCA.ViewModel;
using MVVMCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA
{
    public static class Launcher
    {

        public static void RunSingleParseFile(ObservableCollection<BaseViewModel> Windows)
        {
            Windows.Add(new DCASingleParserViewModel("Sone"));
        }
    }
}
