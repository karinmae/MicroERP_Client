using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class FirmSearchViewModel : SearchViewModel
    {
        public override void Search()
        {
            Proxy proxy = new Proxy();
            result = proxy.SearchFirm(SearchText);
            Items.Clear();
            if (result.Firma != null)
            {
                foreach (var obj in result.Firma)
                {
                    Items.Add(new FirmViewModel(obj));
                }
            }
            else
            {
                Firma obj = new Firma();
                obj.Name = "Keinen Eintrag gefunden!";
                obj.ID = "x";
                Items.Add(new FirmViewModel(obj));
            }
        }

        #region Firmlist Result
        private Firmlist _result;
        public Firmlist result
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
