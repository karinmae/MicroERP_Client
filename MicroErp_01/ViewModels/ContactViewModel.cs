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

            this.ID = obj.ID;
            this.Titel = obj.Titel;
            this.FirstName = obj.Vorname;
            this.LastName = obj.Nachname;
            this.Suffix = obj.Suffix;
            this.Birthday = obj.Geburtsdatum;
            this.Adresse = obj.Adresse;
            this.Deliveryaddress = obj.Lieferadresse;
            this.Billingaddress = obj.Rechnungsadresse;

            this.name = FirstName + " " + LastName;
        }

        public Contact Object { get; set; }

        #region name 
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
        #endregion

        #region ID
        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged("ID");
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
