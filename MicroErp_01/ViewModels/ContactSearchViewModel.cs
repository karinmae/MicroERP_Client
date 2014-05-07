using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {
        public override void Search()
        {
            Proxy proxy = new Proxy();
            result = proxy.Search(SearchText);
            Items.Clear();
            foreach (var obj in result.Contact)
            {
                Items.Add(new ContactViewModel(obj));
            }
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

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
    }

}
