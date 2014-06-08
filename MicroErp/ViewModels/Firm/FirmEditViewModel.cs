using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MicroErp.ViewModels
{
    public class FirmEditViewModel : ViewModel
    {
        private string ID2;
        public FirmEditViewModel(string ID)
        {
            ID2 = ID;
            Proxy proxy = new Proxy();
            Firmlist result = proxy.SearchFirmID(ID);
            foreach (var obj in result.Firma)
            {

                name = obj.Name;
                UID = obj.UID;
                Adresse = obj.Adresse;
                Deliveryaddress = obj.Lieferadresse;
                Billingaddress = obj.Rechnungsadresse;
                ID = obj.ID;

            }

        }

        private ICommandViewModel _UpdateFirmContactCommand;
        public ICommandViewModel UpdateFirmContactCommand
        {
            get
            {
                if (_UpdateFirmContactCommand == null)
                {
                    _UpdateFirmContactCommand = new SimpleCommandViewModel(
                        "Update",
                        "Startet Update",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            string resp = prx.UpdateFirm(ID2, name, UID, Adresse, Deliveryaddress, Billingaddress);
                            Result = resp;
                        });
                }
                return _UpdateFirmContactCommand;
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

        #region UID
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


