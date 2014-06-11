using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MicroERP.ipdf;

namespace MicroErp.ViewModels
{
    public class InvoiceEditViewModel : ViewModel
    {
        private string ID2;
        InvoiceList result;
        public InvoiceEditViewModel(string ID)
        {
            ID2 = ID;
            Proxy proxy = new Proxy();
            result = proxy.SearchInvoiceID(ID);
            foreach (var obj in result.Invoice)
            {
                InvoiceNum = obj.Nummer;
                string PayDate1 = obj.Faelligkeit;
                string EditDate1 = obj.Datum;
                Name = obj.Name;
                BillingAdress = obj.Billingadress;
                Comment = obj.Kommentar;
                Note = obj.Nachricht;

                /* Rechungszeile 1 */
                Stk1 = obj.Menge1;
                Article1 = obj.Artikel1;
                Price1 = obj.Stueckpreis1;
                USt1 = obj.Ust1;

                /* Rechungszeile 2 */
                Stk2 = obj.Menge2;
                Article2 = obj.Artikel2;
                Price2 = obj.Stueckpreis2;
                USt2 = obj.Ust2;

                /* Rechungszeile 3 */
                Stk3 = obj.Menge3;
                Article3 = obj.Artikel3;
                Price3 = obj.Stueckpreis3;
                USt3 = obj.Ust3;

                string[] PayDateReg = Regex.Split(PayDate1, "T");
                PayDate = PayDateReg[0];

                string[] EditDateReg = Regex.Split(EditDate1, "T");
                EditDate = EditDateReg[0];

            }

        }

        #region Update
        private ICommandViewModel _UpdateContactCommand;
        public ICommandViewModel UpdateContactCommand
        {
            get
            {
                if (_PrintInvoiceCommand == null)
                {
                    _PrintInvoiceCommand = new SimpleCommandViewModel(
                        "Update",
                        "Startet Update",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            string resp = prx.UpdateInvoice
                            (ID2, Comment, Note,
                             Stk1, Article1, USt1, Price1,
                             Stk2, Article2, USt2, Price2,
                             Stk3, Article3, USt3, Price3
                             );
                            Result = resp;
                        });
                }
                return _PrintInvoiceCommand;
            }
        }
        #endregion

        #region PDF drucken
        private ICommandViewModel _PrintInvoiceCommand;
        public ICommandViewModel PrintInvoiceCommand
        {
            get
            {
                if (_PrintInvoiceCommand == null)
                {
                    _PrintInvoiceCommand = new SimpleCommandViewModel(
                        "Update",
                        "Startet Update",
                        () =>
                        {
                            foreach (var obj in result.Invoice)
                            {
                                PrintPDF prx = new PrintPDF(obj);
                            }
                        });
                }
                return _PrintInvoiceCommand;
            }
        }
        #endregion

        #region InvoiceNum
        private string _InvoiceNum;
        public string InvoiceNum
        {
            get
            {
                return _InvoiceNum;
            }
            set
            {
                if (_InvoiceNum != value)
                {
                    _InvoiceNum = value;
                    OnPropertyChanged("InvoiceNum");
                }
            }
        }
        #endregion

        #region PayDate
        private string _PayDate;
        public string PayDate
        {
            get
            {
                return _PayDate;
            }
            set
            {
                if (_PayDate != value)
                {
                    _PayDate = value;
                    OnPropertyChanged("PayDate");
                }
            }
        }
        #endregion

        #region EditDate
        private string _EditDate;
        public string EditDate
        {
            get
            {
                return _EditDate;
            }
            set
            {
                if (_EditDate != value)
                {
                    _EditDate = value;
                    OnPropertyChanged("EditDate");
                }
            }
        }
        #endregion

        #region Name
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region BillingAdress
        private string _DelAdress;
        public string BillingAdress
        {
            get
            {
                return _DelAdress;
            }
            set
            {
                if (_DelAdress != value)
                {
                    _DelAdress = value;
                    OnPropertyChanged("BillingAdress");
                }
            }
        }
        #endregion

        #region Comment
        private string _Comment;
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (_Comment != value)
                {
                    _Comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        #endregion

        #region Note
        private string _Note;
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                if (_Note != value)
                {
                    _Note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        #endregion

        /* Rechnungszeile 1 */
        #region Amount1
        private string _Stk1;
        public string Stk1
        {
            get
            {
                return _Stk1;
            }
            set
            {
                if (_Stk1 != value)
                {
                    _Stk1 = value;
                    OnPropertyChanged("Amount1");
                }
            }
        }
        #endregion

        #region Article1
        private string _Article1;
        public string Article1
        {
            get
            {
                return _Article1;
            }
            set
            {
                if (_Article1 != value)
                {
                    _Article1 = value;
                    OnPropertyChanged("Article1");
                }
            }
        }
        #endregion

        #region Price1
        private string _Price1;
        public string Price1
        {
            get
            {
                return _Price1;
            }
            set
            {
                if (_Price1 != value)
                {
                    _Price1 = value;
                    OnPropertyChanged("Price1");
                }
            }
        }
        #endregion

        #region USt1
        private string _USt1;
        public string USt1
        {
            get
            {
                return _USt1;
            }
            set
            {
                if (_USt1 != value)
                {
                    _USt1 = value;
                    OnPropertyChanged("USt1");
                    OnPropertyChanged("Netto1");
                }
            }
        }
        #endregion

        #region Netto1
        private string _Netto1;
        public string Netto1
        {
            get
            {
                return _Netto1;
            }
            set
            {
                int stk = Convert.ToInt32(Stk1);
                int preis = Convert.ToInt32(Price1);
                int netto = stk * preis;
                _Netto1 = Convert.ToString(netto);
                OnPropertyChanged("Brutto1");
            }
        }
        #endregion

        #region Brutto1
        private string _Brutto1;
        public string Brutto1
        {
            get
            {
                return _Brutto1;
            }
            set
            {
                int netto = Convert.ToInt32(Netto1);
                int Ust = Convert.ToInt32(USt1);
                int brutto = netto * ((Ust / 100) + 1);
                _Brutto1 = Convert.ToString(brutto);
            }
        }
        #endregion


        /* Rechnungszeile 2 */
        #region Amount2
        private string _Stk2;
        public string Stk2
        {
            get
            {
                return _Stk2;
            }
            set
            {
                if (_Stk2 != value)
                {
                    _Stk2 = value;
                    OnPropertyChanged("Amount2");
                }
            }
        }
        #endregion

        #region Article2
        private string _Article2;
        public string Article2
        {
            get
            {
                return _Article2;
            }
            set
            {
                if (_Article2 != value)
                {
                    _Article2 = value;
                    OnPropertyChanged("Article2");
                }
            }
        }
        #endregion

        #region Price2
        private string _Price2;
        public string Price2
        {
            get
            {
                return _Price2;
            }
            set
            {
                if (_Price2 != value)
                {
                    _Price2 = value;
                    OnPropertyChanged("Price2");
                }
            }
        }
        #endregion

        #region USt2
        private string _USt2;
        public string USt2
        {
            get
            {
                return _USt2;
            }
            set
            {
                if (_USt2 != value)
                {
                    _USt2 = value;
                    OnPropertyChanged("USt2");
                }
            }
        }
        #endregion

        #region Netto2
        private string _Netto2;
        public string Netto2
        {
            get
            {
                return _Netto2;
            }
            set
            {
                int stk = Convert.ToInt32(Stk2);
                int preis = Convert.ToInt32(Price2);
                int netto = stk * preis;
                _Netto2 = Convert.ToString(netto);
                OnPropertyChanged("Brutto2");
            }
        }
        #endregion

        #region Brutto2
        private string _Brutto2;
        public string Brutto2
        {
            get
            {
                return _Brutto2;
            }
            set
            {
                int netto = Convert.ToInt32(Netto2);
                int Ust = Convert.ToInt32(USt2);
                int brutto = netto * ((Ust / 100) + 1);
                _Brutto2 = Convert.ToString(brutto);
            }
        }
        #endregion


        /* Rechnungszeile 3 */
        #region Amount3
        private string _Stk3;
        public string Stk3
        {
            get
            {
                return _Stk3;
            }
            set
            {
                if (_Stk3 != value)
                {
                    _Stk3 = value;
                    OnPropertyChanged("Amount3");
                }
            }
        }
        #endregion

        #region Article3
        private string _Article3;
        public string Article3
        {
            get
            {
                return _Article3;
            }
            set
            {
                if (_Article3 != value)
                {
                    _Article3 = value;
                    OnPropertyChanged("Article3");
                }
            }
        }
        #endregion

        #region Price3
        private string _Price3;
        public string Price3
        {
            get
            {
                return _Price3;
            }
            set
            {
                if (_Price3 != value)
                {
                    _Price3 = value;
                    OnPropertyChanged("Price3");
                }
            }
        }
        #endregion

        #region USt3
        private string _USt3;
        public string USt3
        {
            get
            {
                return _USt3;
            }
            set
            {
                if (_USt3 != value)
                {
                    _USt3 = value;
                    OnPropertyChanged("USt3");
                }
            }
        }
        #endregion

        #region Netto3
        private string _Netto3;
        public string Netto3
        {
            get
            {
                return _Netto3;
            }
            set
            {
                int stk = Convert.ToInt32(Stk3);
                int preis = Convert.ToInt32(Price3);
                int netto = stk * preis;
                _Netto3 = Convert.ToString(netto);
                OnPropertyChanged("Brutto3");
            }
        }
        #endregion

        #region Brutto3
        private string _Brutto3;
        public string Brutto3
        {
            get
            {
                return _Brutto3;
            }
            set
            {
                int netto = Convert.ToInt32(Netto3);
                int Ust = Convert.ToInt32(USt3);
                int brutto = netto * ((Ust / 100) + 1);
                _Brutto3 = Convert.ToString(brutto);
            }
        }
        #endregion



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

    }
}


