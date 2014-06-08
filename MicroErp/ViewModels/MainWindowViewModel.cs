using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MicroErp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
        }

        #region Invoice
        private InvoiceSearchViewModel _InvoiceSearchViewModel;
        public InvoiceSearchViewModel InvoiceSearchViewModel
        {
            get
            {
                if (_InvoiceSearchViewModel == null)
                {
                    _InvoiceSearchViewModel = new InvoiceSearchViewModel();
                }
                return _InvoiceSearchViewModel;
            }
        }
        #endregion

        #region Contacts
        private ContactSearchViewModel _ContactSearchViewModel;
        public ContactSearchViewModel ContactSearchViewModel
        {
            get
            {
                if (_ContactSearchViewModel == null)
                {
                    _ContactSearchViewModel = new ContactSearchViewModel();
                }
                return _ContactSearchViewModel;
            }
        }
        #endregion
    }
}
