using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Core.ViewModels
{
    class MVVMViewModel : ViewModel
    {
        private string _test = "Test";
        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                OnPropertyChanged("Test");
            }
        }
    }
}
