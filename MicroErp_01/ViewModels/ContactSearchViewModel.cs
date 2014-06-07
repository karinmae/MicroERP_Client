using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroErp_01.ViewModels.Firm;

namespace MicroErp_01.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {
        #region Search Button
        public override void Search()
        {
            Proxy proxy = new Proxy();
            if (selected == "Kontakte")
            {
                result = proxy.Search(SearchText);
                Items.Clear();
                if (result.Contact != null)
                {
                    foreach (var obj in result.Contact)
                    {
                        Items.Add(new ContactViewModel(obj));
                    }
                }
                else
                {
                    Contact obj = new Contact();
                    obj.Vorname = "Keinen Eintrag gefunden!";
                    obj.ID = "x";
                    Items.Add(new ContactViewModel(obj));
                }
            }
            else
            {
                result2 = proxy.SearchFirm(SearchText);
                Items.Clear();
                if (result2.Firma != null)
                {
                    foreach (var obj in result2.Firma)
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
        }
        #endregion

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        #region Firmlist Result2
        private Firmlist _result2;
        public Firmlist result2
        {
            get
            {
                return _result2;
            }
            set
            {
                if (_result2 != value)
                {
                    _result2 = value;
                }
            }
        }
        #endregion

        #region ContacList Result
        private ContactsList _result;
        public ContactsList result
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
    }

}
