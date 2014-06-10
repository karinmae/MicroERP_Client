using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MicroErp.ViewModels
{
    public class ContactEditViewModel : ViewModel
    {
        private string id2;
        public ContactEditViewModel(string id)
        {
            id2 = id;
            Proxy proxy = new Proxy();
             ContactsList result = proxy.SearchID(id);
                foreach (var obj in result.contact)
                {
                    FirstName = obj.Vorname;
                    LastName = obj.Nachname;
                    Titel = obj.Titel;
                    Suffix = obj.Suffix;
                    string birth2 = obj.Geburtsdatum;
                    Adresse = obj.Adresse;
                    Deliveryaddress = obj.Lieferadresse;
                    Billingaddress = obj.Rechnungsadresse;
                    id = obj.ID;

                    string[] birth = Regex.Split(birth2, "T");
                    Birthday = birth[0];

                }
            
        }

        private ICommandViewModel _UpdateContactCommand;
        public ICommandViewModel UpdateContactCommand
        {
            get
            {
                if (_UpdateContactCommand == null)
                {
                    _UpdateContactCommand = new SimpleCommandViewModel(
                        "Update",
                        "Startet Update",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            string resp = prx.Update(id2, FirstName, LastName, Titel, Suffix, Birthday, Adresse, Deliveryaddress, Billingaddress);
                            Result = resp;
                        });
                }
                return _UpdateContactCommand;
            }
        }

        #region Result
        private string _Result;
        public string Result
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
                    OnPropertyChanged("Result");
                }
            }
        }
        #endregion

        #region Firstname
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
        #endregion

        #region Titel
        private string _Titel;
        public string Titel
        {
            get
            {
                return _Titel;
            }
            set
            {
                if (_Titel != value)
                {
                    _Titel = value;
                    OnPropertyChanged("Titel");
                }
            }
        }
        #endregion

        #region Lastname
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
        #endregion

        #region Suffix
        private string _Suffix;
        public string Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                if (_Suffix != value)
                {
                    _Suffix = value;
                    OnPropertyChanged("Suffix");
                }
            }
        }
        #endregion

        #region Birthday
        private string _Birthday;
        public string Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }
        #endregion

        #region Adresse
        private string _Adresse;
        public string Adresse
        {
            get
            {
                return _Adresse;
            }
            set
            {
                if (_Adresse != value)
                {
                    _Adresse = value;
                    OnPropertyChanged("Adresse");
                }
            }
        }
        #endregion

        #region Billingaddress
        private string _Billingaddress;
        public string Billingaddress
        {
            get
            {
                return _Billingaddress;
            }
            set
            {
                if (_Billingaddress != value)
                {
                    _Billingaddress = value;
                    OnPropertyChanged("Billingaddress");
                }
            }
        }
        #endregion

        #region Deliveryaddress
        private string _Deliveryaddress;
        public string Deliveryaddress
        {
            get
            {
                return _Deliveryaddress;
            }
            set
            {
                if (_Deliveryaddress != value)
                {
                    _Deliveryaddress = value;
                    OnPropertyChanged("Deliveryaddress");
                }
            }
        }
        #endregion
    }
}


