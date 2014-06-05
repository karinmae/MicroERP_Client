using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace MicroErp_01
{
    internal class Proxy
    {
        //Server
        protected string URL = "http://127.0.0.1:8080/";

        public Proxy()
        { }

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

        #region Search Firm
        public Firmlist SearchFirm(string text)
        {
            Firmlist list = new Firmlist();
            WebClient http = new WebClient();
            try
            {
                string result = http.DownloadString(new Uri(URL + "Contacts/SearchFirm?name=" + Uri.EscapeUriString(text)));
                Console.WriteLine(result);
                XmlSerializer serializer = new XmlSerializer(typeof(Firmlist));
                TextReader reader = new StringReader(result);
                list = (Firmlist)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (System.Net.WebException ex)
            {

            }
            return list;
        }
        #endregion

        #region Search Invoice
        public InvoiceList SearchInvoice(string AmountFrom, string AmountTo, string SearchContact)
        {
            InvoiceList list = new InvoiceList();
            WebClient http = new WebClient();
            try
            {
                string req = "&AmountTo=" + Uri.EscapeUriString(AmountTo)
                    + "&SearchContact=" + Uri.EscapeUriString(SearchContact);
                string result = http.DownloadString(new Uri(URL + "Invoice/Search?AmountFrom=" + Uri.EscapeUriString(AmountFrom) + req));
                Console.WriteLine(result);
                XmlSerializer serializer = new XmlSerializer(typeof(InvoiceList));
                TextReader reader = new StringReader(result);
                list = (InvoiceList)serializer.Deserialize(reader);
                reader.Close();

            }
            catch (System.Net.WebException ex)
            {

            }
            return list;

        }
        #endregion

        #region Search ID
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

        #region New Contacts
        public string New(string Name, string UID,
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