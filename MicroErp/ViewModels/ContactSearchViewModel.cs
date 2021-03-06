﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroErp.ViewModels.Firm;

namespace MicroErp.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {
        #region Search Button
        public override void Search()
        {
            Proxy proxy = new Proxy();
            if (Selected == "Kontakte")
            {
                ResultContact = proxy.Search(SearchText);
                Items.Clear();
                if (ResultContact.contact != null)
                {
                    foreach (var obj in ResultContact.contact)
                    {
                        Items.Add(new ContactViewModel(obj));
                    }
                }
                else
                {
                    Contact obj = new Contact();
                    obj.Vorname = "Keinen Eintrag gefunden!";
                    obj.Id = "x";
                    Items.Add(new ContactViewModel(obj));
                }
            }
            else
            {
                ResultFirm = proxy.SearchFirm(SearchText);
                Items.Clear();
                if (ResultFirm.Firma != null)
                {
                    foreach (var obj in ResultFirm.Firma)
                    {
                        Items.Add(new FirmViewModel(obj));
                    }
                }
                else
                {
                    Firma obj = new Firma();
                    obj.Name = "Keinen Eintrag gefunden!";
                    obj.Id = "x";
                    Items.Add(new FirmViewModel(obj));
                }
            }
        }
        #endregion

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        #region FirmList Result2
        private FirmList _ResultFirm;
        public FirmList ResultFirm
        {
            get
            {
                return _ResultFirm;
            }
            set
            {
                if (_ResultFirm != value)
                {
                    _ResultFirm = value;
                }
            }
        }
        #endregion

        #region ContacList Result
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
