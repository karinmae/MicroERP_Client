using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {
        #region Search Button
        public override void Search()
        {
            Proxy proxy = new Proxy();
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
        #endregion

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

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
