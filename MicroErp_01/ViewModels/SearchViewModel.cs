using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace MicroErp_01.ViewModels
{
    public abstract class SearchViewModel : ViewModel
    {
        public SearchViewModel()
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
        }

        /* Contact */
        #region Contacts
        /* Der Text der Suchbox */
        #region Search Text
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("SearchText");
                }
            }
        }

        private string _Contact1 = "Kontakte";
        public string Contact1
        {
            get { return this._Contact1; }
            set
            {
                this._Contact1 = value;
                this.OnPropertyChanged("Contact1");
            }
        }

        private bool _ContactIsCheck;
        public bool ContactIsCheck
        {
            get { return this._ContactIsCheck; }
            set
            {
                this._ContactIsCheck = value;
                this.OnPropertyChanged("ContactIsCheck");
                this.OnPropertyChanged("selected");
            }
        }

        private bool _FirmIsCheck;
        public bool FirmIsCheck
        {
            get { return this._FirmIsCheck; }
            set
            {
                this._FirmIsCheck = value;
                this.OnPropertyChanged("FirmIsCheck");
                this.OnPropertyChanged("selected");
            }
        }

        private string _Firm1 = "Firma";
        public string Firm1
        {
            get { return this._Firm1; }
            set
            {
                this._Firm1 = value;
                this.OnPropertyChanged("Firm1");
            }
        }

        private string _selected;
        public string selected
        {
            
            get
            {
                _selected = this.ContactIsCheck ? this.Contact1 : this.Firm1;
                return _selected;
            }

        }

        #endregion

        /* Ausgewählte Items der ListView */
        #region SelectedItem
        private InvoiceViewModel _SelectedItem;
        public InvoiceViewModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        #endregion

        /* Such-Button */
        #region SearchCommand
        private ICommandViewModel _searchCommand;
        public ICommandViewModel SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                       
                        _searchCommand = new SimpleCommandViewModel(
                            "Suchen",
                            "Startet eine Suche",
                            Search,
                            () => !string.IsNullOrEmpty(SearchText) &&
                                  !string.IsNullOrEmpty(selected)) ;
                            
                    
                }
                return _searchCommand;
            }
        }
        #endregion

        /* Neuen Kontakt anlegen */
        #region NewContactCommand
        private ICommandViewModel _NewContactCommand;
        public ICommandViewModel NewContactCommand
        {
            get
            {
                if (_NewContactCommand == null)
                {
                    _NewContactCommand = new SimpleCommandViewModel(
                        "NewContact",
                        "Öffnet das NewContact Beispiel",
                        () =>
                        {
                            var dlg = new NewContact();
                            dlg.ShowDialog();
                        });
                }
                return _NewContactCommand;
            }
        }
        #endregion

        /* Kontakt editieren/anzeigen */
        #region EditContactCommand
        private ICommandViewModel _EditContactCommand;
        public ICommandViewModel EditContactCommand
        {
            get
            {
                if (_EditContactCommand == null)
                {
                    _EditContactCommand = new SimpleCommandViewModel(
                        "EditContact",
                        "Öffnet das EditContact Beispiel",
                        () =>
                        {
                            
                            if (SelectedItem.ID != "x")
                            {
                                if (selected == "Kontakte")
                                {
                                    var dlg = new EditContact();
                                    dlg.DataContext = new ContactEditViewModel(SelectedItem.ID, selected); ;
                                    dlg.ShowDialog();
                                }
                                else
                                {
                                    var dlg = new EditFirmContact();
                                    dlg.DataContext = new FirmEditViewModel(SelectedItem.ID, selected); ;
                                    dlg.ShowDialog();
                                }
                            }
                        });
                }
                return _EditContactCommand;
            }
        }
        #endregion
        #endregion

        /* Invoice */
        #region Invoice

        /* Rechnungsdatum von */
        #region DateFrom
        private string _DateFrom;
        public string DateFrom
        {
            get
            {
                return _DateFrom;
            }
            set
            {
                if (_DateFrom != value)
                {
                    _DateFrom = value;
                    SearchInvoiceCommand.OnCanExecuteChanged();
                    OnPropertyChanged("DateFrom");
                }
            }
        }
        #endregion

        /* Rechnungsdatum bis */
        #region DateTo
        private string _DateTo;
        public string DateTo
        {
            get
            {
                return _DateTo;
            }
            set
            {
                if (_DateTo != value)
                {
                    _DateTo = value;
                    SearchInvoiceCommand.OnCanExecuteChanged();
                    OnPropertyChanged("DateTo");
                }
            }
        }
        #endregion

        /* Rechnungsbetrag von */
        #region AmountFrom
        private string _AmountFrom;
        public string AmountFrom
        {
            get
            {
                return _AmountFrom;
            }
            set
            {
                if (_AmountFrom != value)
                {
                    _AmountFrom = value;
                    SearchInvoiceCommand.OnCanExecuteChanged();
                    OnPropertyChanged("AmountFrom");
                }
            }
        }
        #endregion

        /* Rechnungsbetrag bis */
        #region Amount To
        private string _AmountTo;
        public string AmountTo
        {
            get
            {
                return _AmountTo;
            }
            set
            {
                if (_AmountTo != value)
                {
                    _AmountTo = value;
                    SearchInvoiceCommand.OnCanExecuteChanged();
                    OnPropertyChanged("AmountTo");
                }
            }
        }
        #endregion

        /* Search Contact */
        #region Search Contact
        private string _SearchContact;
        public string SearchContact
        {
            get
            {
                return _SearchContact;
            }
            set
            {
                if (_SearchContact != value)
                {
                    _SearchContact = value;
                    SearchInvoiceCommand.OnCanExecuteChanged();
                    OnPropertyChanged("SearchContact");
                }
            }
        }
        #endregion

        /* Such-Button */
        #region SearchInvoiceCommand
        private ICommandViewModel _SearchInvoiceCommand;
        public ICommandViewModel SearchInvoiceCommand
        {
            get
            {
                if (_SearchInvoiceCommand == null)
                {
                    _SearchInvoiceCommand = new SimpleCommandViewModel(
                        "Suchen",
                        "Startet eine Suche",
                        Search,
                        () => //!string.IsNullOrEmpty(SearchContact)
                            (!string.IsNullOrEmpty(DateFrom)) || (!string.IsNullOrEmpty(DateTo)) ||
                            (!string.IsNullOrEmpty(AmountFrom)) || (!string.IsNullOrEmpty(AmountTo))
                            || (!string.IsNullOrEmpty(SearchContact))
                        );
                }
                return _SearchInvoiceCommand;
            }
        }
        #endregion

        #endregion

        public abstract void Search();

        public abstract GridDisplayConfiguration DisplayedColumns { get; }

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        public virtual void ActivateItems()
        {
        }
    }
}
