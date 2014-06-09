using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace MicroErp
{
    internal class Proxy
    {
        //Server
        protected string URL = MicroERP.Properties.Settings.Default.ServerString;

        public Proxy()
        { }

        /* Contacts */
        #region Search Contacts
        public ContactsList Search(string text)
        {
            ContactsList list = new ContactsList();
            WebClient http = new WebClient();
            try
            {
                string result = http.DownloadString(new Uri(URL + "Contacts/Search?name=" + Uri.EscapeUriString(text)));
                Console.WriteLine(result);
                XmlSerializer serializer = new XmlSerializer(typeof(ContactsList));
                TextReader reader = new StringReader(result);
                list = (ContactsList)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (System.Net.WebException ex)
            {

            }
            return list;

        }
        #endregion

        #region Search Contact ID
        public ContactsList SearchID(string text)
        {
            WebClient http = new WebClient();
            //Console.WriteLine(text);
            string result = http.DownloadString(new Uri(URL + "Contacts/ID?id=" + Uri.EscapeUriString(text)));
            //Contact list=null;
            Console.WriteLine(result);
            XmlSerializer serializer = new XmlSerializer(typeof(ContactsList));
            TextReader reader = new StringReader(result);
            ContactsList list = (ContactsList)serializer.Deserialize(reader);
            Display(list);
            reader.Close();
            return list;
        }
        #endregion

        #region New Contact
        public string NewContact(string Titel, string Vorname, string Nachname,
                            string Suffix, string Geburtstag,
                            string AStrasse, string APlz, string AOrt,
                            string LStrasse, string LPlz, string LOrt,
                            string RStrasse, string RPlz, string ROrt)
        {
            string Deliveryaddress, Billingaddress, Adress;

            Adress = AStrasse + " " + APlz + " " + AOrt;
            Deliveryaddress = LStrasse + " " + LPlz + " " + LOrt;
            Billingaddress = RStrasse + " " + RPlz + " " + ROrt;
            Console.WriteLine(Geburtstag);

            WebClient http = new WebClient();
            string req =
                "&vorname=" + Uri.EscapeUriString(Vorname) +
                "&nachname=" + Uri.EscapeUriString(Nachname) +
                "&suffix=" + Uri.EscapeUriString(Suffix) +
                "&adress=" + Uri.EscapeUriString(Adress) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Contact/New?Titel=" + Uri.EscapeUriString(Titel) + req));

            return result;
        }
        #endregion

        #region Edit Contacts
        public string Update(string ID, string FirstName, string LastName, string Titel, string Suffix, string Birthday, string Adresse, string Deliveryaddress, string Billingaddress)
        {
            WebClient http = new WebClient();
            string req =
                "&firstname=" + Uri.EscapeUriString(FirstName) +
                "&lastname=" + Uri.EscapeUriString(LastName) +
                "&title=" + Uri.EscapeUriString(Titel) +
                "&suffix=" + Uri.EscapeUriString(Suffix) +
                "&birthday=" + Uri.EscapeUriString(Birthday) +
                "&adress=" + Uri.EscapeUriString(Adresse) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Contacts/Update?id=" + Uri.EscapeUriString(ID) + req));

            return result;
        }
        #endregion


        /* Firms */
        #region Search Firm
        public FirmList SearchFirm(string text)
        {
            FirmList list = new FirmList();
            WebClient http = new WebClient();
            try
            {
                string result = http.DownloadString(new Uri(URL + "Contacts/SearchFirm?name=" + Uri.EscapeUriString(text)));
                Console.WriteLine(result);
                XmlSerializer serializer = new XmlSerializer(typeof(FirmList));
                TextReader reader = new StringReader(result);
                list = (FirmList)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (System.Net.WebException ex)
            {

            }
            return list;
        }
        #endregion

        #region Search Firm ID
        public FirmList SearchFirmID(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Contacts/FirmID?id=" + Uri.EscapeUriString(text)));
            Console.WriteLine(result);
            XmlSerializer serializer = new XmlSerializer(typeof(FirmList));
            TextReader reader = new StringReader(result);
            FirmList list = (FirmList)serializer.Deserialize(reader);
            reader.Close();
            return list;
        }
        #endregion

        #region New Firm
        public string NewFirm(string Name, string UID,
                            string AStrasse, string APlz, string AOrt,
                            string LStrasse, string LPlz, string LOrt,
                            string RStrasse, string RPlz, string ROrt)
        {
            string Deliveryaddress, Billingaddress, Adress;

            Adress = AStrasse + " " + APlz + " " + AOrt;
            Deliveryaddress = LStrasse + " " + LPlz + " " + LOrt;
            Billingaddress = RStrasse + " " + RPlz + " " + ROrt;

            WebClient http = new WebClient();
            string req =
                "&UID=" + Uri.EscapeUriString(UID) +
                "&adress=" + Uri.EscapeUriString(Adress) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Firma/New?Name=" + Uri.EscapeUriString(Name) + req));

            return result;
        }
        #endregion

        #region Edit Firm
        public string UpdateFirm(string ID, string Name, string UID, string Adresse, string Deliveryaddress, string Billingaddress)
        {
            WebClient http = new WebClient();
            string req =
                "&firstname=" + Uri.EscapeUriString(Name) +
                "&lastname=" + Uri.EscapeUriString(UID) +
                "&adress=" + Uri.EscapeUriString(Adresse) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Contacts/UpdateFirm?id=" + Uri.EscapeUriString(ID) + req));

            return result;
        }
        #endregion


        /* Invoices */
        #region Search Invoice
        public InvoiceList SearchInvoice(string DateFrom, string DateTo, string AmountFrom, string AmountTo, string SearchContact)
        {
            if (string.IsNullOrEmpty(DateFrom))
                DateFrom = "";

            if (string.IsNullOrEmpty(DateTo))
                DateTo = "";

            if (string.IsNullOrEmpty(AmountFrom))
                AmountFrom = "";

            if (string.IsNullOrEmpty(AmountTo))
                AmountTo = "";

            if (string.IsNullOrEmpty(SearchContact))
                SearchContact = "";


            InvoiceList list = new InvoiceList();
            Console.WriteLine(DateFrom);
            Console.WriteLine(DateTo);
            Console.WriteLine(AmountFrom);
            Console.WriteLine(AmountTo);
            Console.WriteLine(SearchContact);
            WebClient http = new WebClient();
            try
            {
                string req = "&DateTo=" + Uri.EscapeUriString(DateTo) + "&AmountTo=" + Uri.EscapeUriString(AmountTo)
                    + "&SearchContact=" + Uri.EscapeUriString(SearchContact);
                string ResultContact = http.DownloadString(new Uri(URL + "Invoice/Search?DateFrom=" + Uri.EscapeUriString(AmountFrom) + req));
                Console.WriteLine(ResultContact);
                XmlSerializer serializer = new XmlSerializer(typeof(InvoiceList));
                TextReader reader = new StringReader(ResultContact);
                list = (InvoiceList)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (System.Net.WebException ex)
            {

            }
            return list;

        }
        #endregion

        #region Search Invoice ID
        public InvoiceList SearchInvoiceID(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Invoice/ID?id=" + Uri.EscapeUriString(text)));
            Console.WriteLine(result);
            XmlSerializer serializer = new XmlSerializer(typeof(InvoiceList));
            TextReader reader = new StringReader(result);
            InvoiceList list = (InvoiceList)serializer.Deserialize(reader);
            reader.Close();
            return list;
        }
        #endregion

        #region Edit Invoice
        public string UpdateInvoice(string ID, string Comment, string Note,
                             string Stk1, string Article1, string USt1, string Price1,
                             string Stk2, string Article2, string USt2, string Price2,
                             string Stk3, string Article3, string USt3, string Price3
                             )
        {

            if (string.IsNullOrEmpty(Comment))
                Comment = "";

            if (string.IsNullOrEmpty(Note))
                Note = "";

            if (string.IsNullOrEmpty(Stk1))
                Stk1 = "";

            if (string.IsNullOrEmpty(Article1))
                Article1 = "";

            if (string.IsNullOrEmpty(USt1))
                USt1 = "";

            if (string.IsNullOrEmpty(Price1))
                Price1 = "";

            if (string.IsNullOrEmpty(Article2))
                Article2 = "";

            if (string.IsNullOrEmpty(USt2))
                USt2 = "";

            if (string.IsNullOrEmpty(Price2))
                Price2 = "";

            if (string.IsNullOrEmpty(Article3))
                Article3 = "";

            if (string.IsNullOrEmpty(USt3))
                USt3 = "";

            if (string.IsNullOrEmpty(Price3))
                Price3 = "";
            WebClient http = new WebClient();
            string req =
                "&Comment=" + Uri.EscapeUriString(Comment) +
                "&Note=" + Uri.EscapeUriString(Note) +
                "&Article1=" + Uri.EscapeUriString(Article1) +
                "&Price1=" + Uri.EscapeUriString(Price1) +
                "&Stk1=" + Uri.EscapeUriString(Stk1) +
                "&UST1=" + Uri.EscapeUriString(USt1) +
                "&Article2=" + Uri.EscapeUriString(Article2) +
                "&Price2=" + Uri.EscapeUriString(Price2) +
                "&Stk2=" + Uri.EscapeUriString(Stk2) +
                "&UST2=" + Uri.EscapeUriString(USt2) +
                "&Article3=" + Uri.EscapeUriString(Article3) +
                "&Price3=" + Uri.EscapeUriString(Price3) +
                "&Stk3=" + Uri.EscapeUriString(Stk3) +
                "&UST3=" + Uri.EscapeUriString(USt3);
            string result = http.DownloadString(new Uri(URL + "Contacts/Update?id=" + Uri.EscapeUriString(ID) + req));

            return result;
        }
        #endregion

        #region Display
        private static void Display(ContactsList list)
        {
            Console.WriteLine("Count: {0}", list.Contact.Count);
            foreach (Contact value in list.Contact)
            {
                Console.WriteLine("Name: {0}", value.Vorname);
                Console.WriteLine("Phone: {0}", value.Nachname);
            }
        }
        #endregion
    }
}