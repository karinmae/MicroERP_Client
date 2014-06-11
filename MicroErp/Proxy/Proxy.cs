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
                string result = http.DownloadString(new Uri(URL + "Contacts/Search?Name=" + Uri.EscapeUriString(text)));
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

        #region Search Contact Id
        public ContactsList SearchID(string text)
        {
            WebClient http = new WebClient();
            //Console.WriteLine(text);
            string result = http.DownloadString(new Uri(URL + "Contacts/Id?Id=" + Uri.EscapeUriString(text)));
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
                            string Suffix, string FirmName, string Geburtstag,
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
            if (string.IsNullOrEmpty(Titel))
                Titel = "";
            if (string.IsNullOrEmpty(Suffix))
                Suffix = "";
            if (string.IsNullOrEmpty(FirmName))
                FirmName = "";
            if (string.IsNullOrEmpty(Geburtstag))
                Geburtstag = "";
            if (string.IsNullOrEmpty(Adress))
                Adress = "";
            if (string.IsNullOrEmpty(Deliveryaddress))
                Deliveryaddress = "";
            if (string.IsNullOrEmpty(Billingaddress))
                Billingaddress = "";

            string req =
                "&firstname=" + Uri.EscapeUriString(Vorname) +
                "&lastname=" + Uri.EscapeUriString(Nachname) +
                "&suffix=" + Uri.EscapeUriString(Suffix) +
                "&FirmName=" + Uri.EscapeUriString(FirmName) +
                "&birthday=" + Uri.EscapeUriString(Geburtstag) +
                "&address=" + Uri.EscapeUriString(Adress) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Contacts/New?Title=" + Uri.EscapeUriString(Titel) + req));

            return result;
        }
        #endregion

        #region Edit Contacts
        public string Update(string ID, string FirstName, string LastName, string Titel, string Suffix, string Birthday, string Adresse, string Deliveryaddress, string Billingaddress)
        {
            WebClient http = new WebClient();
            if (string.IsNullOrEmpty(Titel))
                Titel = "";
            if (string.IsNullOrEmpty(Suffix))
                Suffix = "";
            if (string.IsNullOrEmpty(Birthday))
                Birthday = "";
            if (string.IsNullOrEmpty(Adresse))
                Adresse = "";
            if (string.IsNullOrEmpty(Deliveryaddress))
                Deliveryaddress = "";
            if (string.IsNullOrEmpty(Billingaddress))
                Billingaddress = "";
            string req =
                "&firstname=" + Uri.EscapeUriString(FirstName) +
                "&lastname=" + Uri.EscapeUriString(LastName) +
                "&title=" + Uri.EscapeUriString(Titel) +
                "&suffix=" + Uri.EscapeUriString(Suffix) +
                "&birthday=" + Uri.EscapeUriString(Birthday) +
                "&adress=" + Uri.EscapeUriString(Adresse) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Contacts/Update?Id=" + Uri.EscapeUriString(ID) + req));

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
                string result = http.DownloadString(new Uri(URL + "Firm/Search?Name=" + Uri.EscapeUriString(text)));
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

        #region Search Firm Id
        public FirmList SearchFirmID(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Firm/Id?Id=" + Uri.EscapeUriString(text)));
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
                "&Uid=" + Uri.EscapeUriString(UID) +
                "&address=" + Uri.EscapeUriString(Adress) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Firm/New?Name=" + Uri.EscapeUriString(Name) + req));

            return result;
        }
        #endregion

        #region Edit Firm
        public string UpdateFirm(string ID, string Name, string UID, string Adresse, string Deliveryaddress, string Billingaddress)
        {
            WebClient http = new WebClient();
            if (string.IsNullOrEmpty(Deliveryaddress))
                Deliveryaddress = "";
            if (string.IsNullOrEmpty(Billingaddress))
                Billingaddress = "";

            string req =
                "&name=" + Uri.EscapeUriString(Name) +
                "&Uid=" + Uri.EscapeUriString(UID) +
                "&adress=" + Uri.EscapeUriString(Adresse) +
                "&deliveryaddress=" + Uri.EscapeUriString(Deliveryaddress) +
                "&billingaddress=" + Uri.EscapeUriString(Billingaddress);
            string result = http.DownloadString(new Uri(URL + "Firm/Update?Id=" + Uri.EscapeUriString(ID) + req));

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

        #region Search Invoice Id
        public InvoiceList SearchInvoiceID(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Invoice/Id?Id=" + Uri.EscapeUriString(text)));
            Console.WriteLine(result);
            XmlSerializer serializer = new XmlSerializer(typeof(InvoiceList));
            TextReader reader = new StringReader(result);
            InvoiceList list = (InvoiceList)serializer.Deserialize(reader);
            reader.Close();
            return list;
        }
        #endregion

        #region New Invoice
        public string NewInvoice(string InvoiceNumber, string PayDate, string Costumer, string Comment, string Note,
                                 string Amount1, string Article1, string Price1, string USt1, 
                                 string Amount2, string Article2, string Price2, string USt2,
                                 string Amount3, string Article3, string Price3, string USt3)
        {
            if ((string.IsNullOrEmpty(Amount1)) || (string.IsNullOrEmpty(Article1)) || (string.IsNullOrEmpty(Price1)) || (string.IsNullOrEmpty(USt1)))
            {
                Amount1 ="";
                Article1 ="";
                Price1="";
                USt1="";
            }
            if ((string.IsNullOrEmpty(Amount2)) || (string.IsNullOrEmpty(Article2)) || (string.IsNullOrEmpty(Price2)) || (string.IsNullOrEmpty(USt2)))
            {
                Amount2 = "";
                Article2 = "";
                Price2 = "";
                USt2 = "";
            }
            if ((string.IsNullOrEmpty(Amount3)) || (string.IsNullOrEmpty(Article3)) || (string.IsNullOrEmpty(Price3)) || (string.IsNullOrEmpty(USt3)))
            {
                Amount3 = "";
                Article3 = "";
                Price3 = "";
                USt3 = "";
            }
            
                                
            WebClient http = new WebClient();
            string req =
                "&PayDate=" + Uri.EscapeUriString(PayDate) +
                "&Id=" + Uri.EscapeUriString(Costumer) +
                "&Message=" + Uri.EscapeUriString(Note) +
                "&Comment=" + Uri.EscapeUriString(Comment) +
                    "&A1=" + Uri.EscapeUriString(Amount1) +
                    "&Art1=" + Uri.EscapeUriString(Article1) +
                    "&P1=" + Uri.EscapeUriString(Price1) +
                    "&U1=" + Uri.EscapeUriString(USt1) +
                    "&A2=" + Uri.EscapeUriString(Amount2) +
                    "&Art2=" + Uri.EscapeUriString(Article2) +
                    "&P2=" + Uri.EscapeUriString(Price2) +
                    "&U2=" + Uri.EscapeUriString(USt2) +
                    "&A3=" + Uri.EscapeUriString(Amount3) +
                    "&Art3=" + Uri.EscapeUriString(Article3) +
                    "&P3=" + Uri.EscapeUriString(Price3) +
                    "&U3=" + Uri.EscapeUriString(USt3);
            string result = http.DownloadString(new Uri(URL + "Invoice/New?Number=" + Uri.EscapeUriString(InvoiceNumber) + req));

            return result;
        }
        #endregion

        #region Edit Invoice
        public string UpdateInvoice(string ID, string Comment, string Note,
                             string Amount1, string Article1, string USt1, string Price1,
                             string Amount2, string Article2, string USt2, string Price2,
                             string Amount3, string Article3, string USt3, string Price3
                             )
        {

            if (string.IsNullOrEmpty(Comment))
                Comment = "";

            if (string.IsNullOrEmpty(Note))
                Note = "";

            if (string.IsNullOrEmpty(Amount1))
                Amount1 = "";

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
                "&Amount1=" + Uri.EscapeUriString(Amount1) +
                "&UST1=" + Uri.EscapeUriString(USt1) +
                "&Article2=" + Uri.EscapeUriString(Article2) +
                "&Price2=" + Uri.EscapeUriString(Price2) +
                "&Amount2=" + Uri.EscapeUriString(Amount2) +
                "&UST2=" + Uri.EscapeUriString(USt2) +
                "&Article3=" + Uri.EscapeUriString(Article3) +
                "&Price3=" + Uri.EscapeUriString(Price3) +
                "&Amount3=" + Uri.EscapeUriString(Amount3) +
                "&UST3=" + Uri.EscapeUriString(USt3);
            string result = http.DownloadString(new Uri(URL + "Contacts/Update?Id=" + Uri.EscapeUriString(ID) + req));

            return result;
        }
        #endregion

        #region Display
        private static void Display(ContactsList list)
        {
            Console.WriteLine("Count: {0}", list.contact.Count);
            foreach (Contact value in list.contact)
            {
                Console.WriteLine("Name: {0}", value.Vorname);
                Console.WriteLine("Phone: {0}", value.Nachname);
            }
        }
        #endregion
    }
}