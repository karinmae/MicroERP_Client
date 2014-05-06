using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class ContactViewModel : ViewModel
    {
        public ContactViewModel(Contact obj)
        {
            this.Object = obj;

            

            this.FirstName = obj.Vorname;
            this.LastName = obj.Nachname;
            this.name = FirstName + " " + LastName;
        }

        public Contact Object { get; set; }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("name");
                }
            }
        }

        private string _firstname;
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged("LastName");
                }
            }
        }


    }
}
