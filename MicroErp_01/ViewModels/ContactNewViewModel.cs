using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    class ContactNewViewModel : ViewModel
    {
        public ContactNewViewModel()
        {

        }
       
        #region Firma
        private string _Firmenname;
        public string Firmenname
        {
            get
            {
                return _Firmenname;
            }
            set
            {
                if (_Firmenname != value)
                {
                    _Firmenname = value;
                    OnPropertyChanged("Firmenname");
                    NotifyStateChanged();
                }
            }
        }
        private string _UID;
        public string UID
        {
            get
            {
                return _UID;
            }
            set
            {
                if (_UID != value)
                {
                    _UID = value;
                    OnPropertyChanged("UID");
                    NotifyStateChanged();
                }
            }
        }
        #endregion

        #region Person
        private string _VName;
        public string VName
        {
            get
            {
                return _VName;
            }
            set
            {
                if (_VName != value)
                {
                    _VName = value;
                    OnPropertyChanged("Vorname");
                    NotifyStateChanged();
                }
            }
        }

        private string _NName;
        public string NName
        {
            get
            {
                return _NName;
            }
            set
            {
                if (_NName != value)
                {
                    _NName = value;
                    OnPropertyChanged("Nachname");
                    NotifyStateChanged();
                }
            }
        }
        public string _GebTag;
        public string GebTag
        {
            get
            {
                return _GebTag;
            }
            set
            {
                if (_GebTag != value)
                {
                    _GebTag = value;
                    OnPropertyChanged("GebTag");
                    //NotifyStateChanged();
                }
            }
        }
        #endregion

        #region Adresse
        public string _AStrasse;
        public string AStrasse
        {
            get
            {
                return _AStrasse;
            }
            set
            {
                if (_AStrasse != value)
                {
                    _AStrasse = value;
                    OnPropertyChanged("AStrasse");
                }
            }
        }

        public string _APlz;
        public string APlz
        {
            get
            {
                return _APlz;
            }
            set
            {
                if (_APlz != value)
                {
                    _APlz = value;
                    OnPropertyChanged("APlz");
                }
            }
        }

        public string _AOrt;
        public string AOrt
        {
            get
            {
                return _AOrt;
            }
            set
            {
                if (_AOrt != value)
                {
                    _AOrt = value;
                    OnPropertyChanged("AOrt");
                }
            }
        }
        #endregion

        #region Lieferadresse
        public string _LStrasse;
        public string LStrasse
        {
            get
            {
                return _LStrasse;
            }
            set
            {
                if (_LStrasse != value)
                {
                    _LStrasse = value;
                    OnPropertyChanged("LStrasse");
                }
            }
        }

        public string _LPlz;
        public string LPlz
        {
            get
            {
                return _LPlz;
            }
            set
            {
                if (_LPlz != value)
                {
                    _LPlz = value;
                    OnPropertyChanged("LPlz");
                }
            }
        }

        public string _LOrt;
        public string LOrt
        {
            get
            {
                return _LOrt;
            }
            set
            {
                if (_LOrt != value)
                {
                    _LOrt = value;
                    OnPropertyChanged("LOrt");
                }
            }
        }
        #endregion

        #region Rechnungsadresse
        public string _RStrasse;
        public string RStrasse
        {
            get
            {
                return _RStrasse;
            }
            set
            {
                if (_RStrasse != value)
                {
                    _RStrasse = value;
                    OnPropertyChanged("RStrasse");
                }
            }
        }

        public string _RPlz;
        public string RPlz
        {
            get
            {
                return _RPlz;
            }
            set
            {
                if (_RPlz != value)
                {
                    _RPlz = value;
                    OnPropertyChanged("RPlz");
                }
            }
        }

        public string _ROrt;
        public string ROrt
        {
            get
            {
                return _ROrt;
            }
            set
            {
                if (_ROrt != value)
                {
                    _ROrt = value;
                    OnPropertyChanged("ROrt");
                }
            }
        }
        #endregion

        #region View
        public bool? IsFirma
        {
            get
            {
                if (string.IsNullOrWhiteSpace(NName) && string.IsNullOrWhiteSpace(VName) && string.IsNullOrWhiteSpace(Firmenname)) return null;
                return !string.IsNullOrWhiteSpace(Firmenname);
            }
        }

        public bool CanEditPerson
        {
            get
            {
                return IsFirma == null || IsFirma == false;
            }
        }

        public bool CanEditFirma
        {
            get
            {
                return IsFirma == null || IsFirma == true;
            }
        }

        private void NotifyStateChanged()
        {
            OnPropertyChanged("IsFirma");
            OnPropertyChanged("CanEditPerson");
            OnPropertyChanged("CanEditFirma");
        }
        #endregion

        #region Command
        private ICommandViewModel _UpdateContactCommand;
        public ICommandViewModel UpdateContactCommand
        {
            get
            {
                if (_UpdateContactCommand == null)
                {
                    _UpdateContactCommand = new SimpleCommandViewModel(
                        "New",
                        "Startet New",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            //string resp = prx.New(ID2, FirstName, LastName, Titel, Suffix, Birthday, Adresse, Deliveryaddress, Billingaddress);
                            //Result = resp;

                        });
                }
                return _UpdateContactCommand;
            }
        }

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

    }
}
