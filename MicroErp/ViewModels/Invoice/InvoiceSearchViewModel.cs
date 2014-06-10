using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp.ViewModels
{
    public class InvoiceSearchViewModel : SearchViewModel
    {
        public override void Search()
        {
            Proxy proxy = new Proxy();
            Result = proxy.SearchInvoice(DateFrom, DateTo, AmountFrom,AmountTo,SearchContact);
            Items.Clear();
            if (Result.Invoice != null)
            {
                foreach (var obj in Result.Invoice)
                {
                    Items.Add(new InvoiceViewModel(obj));
                }
            }
            else
            {
                Invoice obj = new Invoice();
                obj.Nummer = "Keinen Eintrag gefunden!";
                obj.ID = "x";
                Items.Add(new InvoiceViewModel(obj));
            }
        }

        #region InvoiceList Result
        private InvoiceList _Result;
        public InvoiceList Result
        {
            get
            {
                return _Result;
            }
            set
            {
                if (_Result != value)
                {
                    _Result = value;
                }
            }
        }
        #endregion

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }
    }
}
