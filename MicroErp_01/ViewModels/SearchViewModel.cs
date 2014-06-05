﻿using System;
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
                        () => !string.IsNullOrEmpty(SearchText));
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
                            var dlg = new EditContact();
                            if (SelectedItem.ID != "x")
                            {
                                dlg.DataContext = new ContactEditViewModel(SelectedItem.ID); ;
                                dlg.ShowDialog();
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
                    if (string.IsNullOrEmpty(AmountFrom))
                    {
                        AmountFrom = " ";
                    }
                    if (string.IsNullOrEmpty(AmountTo))
                    {
                        AmountTo = " ";
                    }
                    if (string.IsNullOrEmpty(SearchContact))
                    {
                        SearchContact = " ";
                    }
                    _SearchInvoiceCommand = new SimpleCommandViewModel(
                        "Suchen",
                        "Startet eine Suche",
                        Search,
                        () => (!string.IsNullOrEmpty(AmountFrom)) && (!string.IsNullOrEmpty(AmountTo)
                            && (!string.IsNullOrEmpty(SearchContact)))
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
