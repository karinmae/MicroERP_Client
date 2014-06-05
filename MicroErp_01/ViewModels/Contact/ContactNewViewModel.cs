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
                    NotifyStateChanged();
                }
            }
        }

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
                if (string.IsNullOrWhiteSpace(NName) && string.IsNullOrWhiteSpace(VName) && string.IsNullOrWhiteSpace(Titel)
                    && string.IsNullOrWhiteSpace(Suffix) && string.IsNullOrWhiteSpace(GebTag) && string.IsNullOrWhiteSpace(Firmenname))
                    return null;
                return !string.IsNullOrWhiteSpace(Firmenname);
            } // && string.IsNullOrWhiteSpace(Firmenname)
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
        private ICommandViewModel _NewContactCommand;
        public ICommandViewModel NewContactCommand
        {
            get
            {
                if (_NewContactCommand == null)
                {
                    _NewContactCommand = new SimpleCommandViewModel(
                        "New",
                        "Startet New",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            if (CanEditFirma == true)
                            {
                                string resp = prx.NewFirm(Firmenname, UID, AStrasse, APlz, AOrt,
                                LStrasse, LPlz, LOrt,
                                RStrasse, RPlz, ROrt);
                                Result = resp;
                            }
                            if (CanEditPerson == true)
                            {
                                string resp = prx.NewContact(Titel, VName, NName, Suffix, GebTag, AStrasse, APlz, AOrt,
                                LStrasse, LPlz, LOrt,
                                RStrasse, RPlz, ROrt);
                                Result = resp;
                            }
                            

                        });
                }
                return _NewContactCommand;
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
