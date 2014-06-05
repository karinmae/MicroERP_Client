using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class InvoiceSearchViewModel : SearchViewModel
    {
        public override void Search()
        {
            Proxy proxy = new Proxy();
            result = proxy.SearchInvoice(AmountFrom,AmountTo,SearchContact);
            Items.Clear();
            if (result.Invoice != null)
            {
                foreach (var obj in result.Invoice)
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

        #region ContacList Result
        private InvoiceList _result;
        public InvoiceList result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result != value)
                {
                    _result = value;
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
