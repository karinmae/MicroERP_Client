using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp_01.ViewModels
{
    public class InvoiceViewModel : ViewModel
    {
        public InvoiceViewModel(Invoice obj)
        {
            this.Object = obj;

            this.ID = obj.ID;
            this.Datum = obj.Datum;
            this.Faelligkeit = obj.Faelligkeit;
            this.Nummer = obj.Nummer;
            this.Kommentar = obj.Kommentar;
            this.Nachricht = obj.Nachricht;
            this.Menge = obj.Menge;
            this.Stueckpreis = obj.Stueckpreis;
            this.Ust = obj.Ust;
        }

        public Invoice Object { get; set; }

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

        #region Datum
        private string _Datum;
        public string Datum
        {
            get
            {
                return _Datum;
            }
            set
            {
                if (_Datum != value)
                {
                    _Datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        #endregion

        #region Faelligkeit
        private string _Faelligkeit;
        public string Faelligkeit
        {
            get
            {
                return _Faelligkeit;
            }
            set
            {
                if (_Faelligkeit != value)
                {
                    _Faelligkeit = value;
                    OnPropertyChanged("Faelligkeit");
                }
            }
        }
        #endregion

        #region Nummer
        private string _Nummer;
        public string Nummer
        {
            get
            {
                return _Nummer;
            }
            set
            {
                if (_Nummer != value)
                {
                    _Nummer = value;
                    OnPropertyChanged("Nummer");
                }
            }
        }
        #endregion

        #region Kommentar
        private string _Kommentar;
        public string Kommentar
        {
            get
            {
                return _Kommentar;
            }
            set
            {
                if (_Kommentar != value)
                {
                    _Kommentar = value;
                    OnPropertyChanged("Kommentar");
                }
            }
        }
        #endregion

        #region Nachricht
        private string _Nachricht;
        public string Nachricht
        {
            get
            {
                return _Nachricht;
            }
            set
            {
                if (_Nachricht != value)
                {
                    _Nachricht = value;
                    OnPropertyChanged("Nachricht");
                }
            }
        }
        #endregion

        #region Menge
        private string _Menge;
        public string Menge
        {
            get
            {
                return _Menge;
            }
            set
            {
                if (_Menge != value)
                {
                    _Menge = value;
                    OnPropertyChanged("Menge");
                }
            }
        }
        #endregion

        #region Stueckpreis
        private string _Stueckpreis;
        public string Stueckpreis
        {
            get
            {
                return _Stueckpreis;
            }
            set
            {
                if (_Stueckpreis != value)
                {
                    _Stueckpreis = value;
                    OnPropertyChanged("Stueckpreis");
                }
            }
        }
        #endregion

        #region Ust
        private string _Ust;
        public string Ust
        {
            get
            {
                return _Ust;
            }
            set
            {
                if (_Ust != value)
                {
                    _Ust = value;
                    OnPropertyChanged("Ust");
                }
            }
        }
        #endregion
    }
}
