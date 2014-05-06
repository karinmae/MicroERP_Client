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

        private string _label;
        public string Label
        {
            get
            {
                return _label ?? "Suche:";
            }
            set
            {
                if (_label != value)
                {
                    _label = value;
                    OnPropertyChanged("Label");
                }
            }
        }

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
                            //dlg.DataContext = new ContactNewViewModel();
                            dlg.ShowDialog();
                        });
                }
                return _NewContactCommand;
            }
        }

        private ICommandViewModel _EditContactCommand;
        public ICommandViewModel EditContactCommand
        {
            get
            {
                if (_EditContactCommand == null)
                {
                    _EditContactCommand = new SimpleCommandViewModel(
                        "EditContact",
                        "Öffnet das NewContact Beispiel",
                        () =>
                        {
                            var dlg = new EditContact();
                            //dlg.DataContext = new ContactNewViewModel();
                            dlg.ShowDialog();
                        });
                }
                return _EditContactCommand;
            }
        }
        public abstract void Search();

        public abstract GridDisplayConfiguration DisplayedColumns { get; }

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        public virtual void ActivateItems()
        {
        }
    }
}
