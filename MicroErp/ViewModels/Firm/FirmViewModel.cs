using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp.ViewModels.Firm
{
    public class FirmViewModel : ViewModel
    {
        public FirmViewModel(Firma obj)
        {
            this.Object = obj;

            this.Id = obj.ID;

            this.name = obj.Name;
            this.UID = obj.UID;
            this.Adresse = obj.Adresse;
            this.Deliveryaddress = obj.Lieferadresse;
            this.Billingaddress = obj.Rechnungsadresse;
        }

        public Firma Object { get; set; }

        #region Name
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
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region Id
        private string _ID;
        public string Id
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
                    OnPropertyChanged("Id");
                }
            }
        }
        #endregion

        #region Uid
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
                    OnPropertyChanged("Uid");
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
