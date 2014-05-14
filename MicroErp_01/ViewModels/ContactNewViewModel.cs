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
    }
}
