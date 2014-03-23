using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMCore.ViewModels;

namespace AnalyzerShell.ViewModel.MDI
{
    public class FileViewModel : BaseViewModel
    {
        public FileViewModel(string title)
        {
            Title = title;
        }
        public string Title
        {
            get;
            set;
        }
        public object Data
        {
            get;
            set;
        }
        public object Date
        {
            get;
            set;
        }
    }
}
