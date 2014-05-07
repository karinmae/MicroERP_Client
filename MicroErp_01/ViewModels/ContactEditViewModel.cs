using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    class ContactEditViewModel : ViewModel
    {
        public ContactEditViewModel(string ID)
        {
            Proxy proxy = new Proxy();
            ContactsList result= proxy.SearchID(ID);
            foreach (var obj in result.Contact)
            {
                ContactViewModel kon = new ContactViewModel(obj);
               
            }
            
        }    
    }
}
