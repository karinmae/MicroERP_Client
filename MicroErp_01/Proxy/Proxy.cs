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
        protected string URL = "http://localhost:8080/";

        public Proxy()
        {}

        /*Search Contacts */
        #region Search Contacts
        public ContactsList Search(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Contacts/Search?name=" + Uri.EscapeUriString(text)));
            Console.WriteLine(result);
            XmlSerializer serializer = new XmlSerializer(typeof(ContactsList));
            TextReader reader = new StringReader(result);
            ContactsList list = (ContactsList)serializer.Deserialize(reader);
            Display(list);
            reader.Close();
            return list;
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