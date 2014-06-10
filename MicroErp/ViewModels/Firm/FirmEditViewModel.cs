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
        private string id2;
        public FirmEditViewModel(string id)
        {
            id2 = id;
            Proxy proxy = new Proxy();
            FirmList result = proxy.SearchFirmID(id);
            foreach (var obj in result.Firma)
            {

                Name = obj.Name;
                Uid = obj.UID;
                Adresse = obj.Adresse;
                Deliveryaddress = obj.Lieferadresse;
                Billingaddress = obj.Rechnungsadresse;
                id = obj.ID;

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
                            string resp = prx.UpdateFirm(id2, Name, Uid, Adresse, Deliveryaddress, Billingaddress);
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

        #region Name
        private string _name;
        public string Name
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

        #region Uid
        private string _UID;
        public string Uid
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


