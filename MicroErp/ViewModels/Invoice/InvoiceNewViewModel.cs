﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroErp.ViewModels
{
    class InvoiceNewViewModel : ViewModel
    {
        public InvoiceNewViewModel()
        {

        }

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

        #region Costumer
        private string _Costumer;
        public string Costumer
        {
            get
            {
                return _Costumer;
            }
            set
            {
                if (_Costumer != value)
                {
                    _Costumer = value;
                    OnPropertyChanged("Costumer");
                }
            }
        }
        #endregion

        #region Date
        private string _Date;
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        #endregion

        #region InvoiceNumber
        private string _InvoiceNumber;
        public string InvoiceNumber
        {
            get
            {
                return _InvoiceNumber;
            }
            set
            {
                if (_InvoiceNumber != value)
                {
                    _InvoiceNumber = value;
                    OnPropertyChanged("InvoiceNumber");
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

        #region Artikel 1
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
                    //calcNetto1();
                    calcBrutto1();
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
                    calcNetto1();
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
                if (_Netto1 != value)
                {
                    _Netto1 = value;
                    OnPropertyChanged("Netto1");
                }
            }
        }

        private void calcNetto1()
        {
            int stk = Convert.ToInt32(Stk1);
            int preis = Convert.ToInt32(Price1);
            int netto = stk * preis;
            Netto1 = Convert.ToString(netto);
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
                if (_Brutto1 != value)
                {
                    _Brutto1 = value;
                    OnPropertyChanged("Brutto1");
                }
            }
        }

        private void calcBrutto1()
        {

            int netto = Convert.ToInt32(Netto1);
            int Ust = Convert.ToInt32(USt1);
            float brutto = ((netto / 100) * Ust) + netto;
            Brutto1 = Convert.ToString(brutto);
        }
        #endregion
        #endregion

        #region Artikel 2
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
                    calcBrutto2();
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
                    calcNetto2();
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
                if (_Netto2 != value)
                {
                    _Netto2 = value;
                    OnPropertyChanged("Netto2");
                }
            }
        }

        private void calcNetto2()
        {
            int stk = Convert.ToInt32(Stk2);
            int preis = Convert.ToInt32(Price2);
            int netto = stk * preis;
            Netto2 = Convert.ToString(netto);
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
                if (_Brutto2 != value)
                {
                    _Brutto2 = value;
                    OnPropertyChanged("Brutto2");
                }
            }
        }

        private void calcBrutto2()
        {

            int netto = Convert.ToInt32(Netto2);
            int Ust = Convert.ToInt32(USt1);
            float brutto = ((netto / 100) * Ust) + netto;
            Brutto2 = Convert.ToString(brutto);
        }
        #endregion
        #endregion

        #region Artikel 3
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
                    calcBrutto3();
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
                    calcNetto3();
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
                if (_Netto3 != value)
                {
                    _Netto3 = value;
                    OnPropertyChanged("Netto3");
                }
            }
        }

        private void calcNetto3()
        {
            int stk = Convert.ToInt32(Stk3);
            int preis = Convert.ToInt32(Price3);
            int netto = stk * preis;
            Netto3 = Convert.ToString(netto);
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
                if (_Brutto3 != value)
                {
                    _Brutto3 = value;
                    OnPropertyChanged("Brutto3");
                }
            }
        }

        private void calcBrutto3()
        {

            int netto = Convert.ToInt32(Netto3);
            int Ust = Convert.ToInt32(USt3);
            float brutto = ((netto / 100) * Ust) + netto;
            Brutto3 = Convert.ToString(brutto);
        }
        #endregion
        #endregion

        #region Command
        private ICommandViewModel _NewInvoiceCommand;
        public ICommandViewModel NewInvoiceCommand
        {
            get
            {
                if (_NewInvoiceCommand == null)
                {
                    _NewInvoiceCommand = new SimpleCommandViewModel(
                        "New",
                        "Startet New",
                        () =>
                        {
                            Proxy prx = new Proxy();

                            string resp = prx.NewInvoice(InvoiceNumber, PayDate, Costumer, Comment, Note,
                                                         Stk1, Article1, Price1, USt1, 
                                                         Stk2, Article2, Price2, USt2,
                                                         Stk3, Article3, Price3, USt3);
                            Result = resp;

                        }
                        );
                }
                return _NewInvoiceCommand;
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

        #region Search
        private ICommandViewModel _SearchCostumer;
        public ICommandViewModel SearchCostumer
        {
            get
            {
                if (_SearchCostumer == null)
                {
                    _SearchCostumer = new SimpleCommandViewModel(
                        "New",
                        "Startet New",
                        () =>
                        {
                            Proxy prx = new Proxy();
                            ResultContact = prx.Search(Costumer);
                            //Costumer.
                        }
                        );
                }
                return _NewInvoiceCommand;
            }
        }

        private ContactsList _ResultContact;
        public ContactsList ResultContact
        {
            get
            {
                return _ResultContact;
            }
            set
            {
                if (_ResultContact != value)
                {
                    _ResultContact = value;
                }
            }
        }
        #endregion
    }
}
