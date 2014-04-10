using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MicroErp_01
{
    class Proxy
    {
         protected string URL = "http://localhost:8080/";
        //private static List<Contact> con = new List<Contact>();

        public Proxy(string text)
        {
            WebClient http = new WebClient();
            string result = http.DownloadString(new Uri(URL + "Contacts/Search?name=" + Uri.EscapeUriString(text)));
            if (!String.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
                XMLParse(result);

            }
            //else Console.WriteLine("fail");
            //reader.Close();
            //Console.ReadLine();
            //return result.FromXmlString();
        }

        private void XMLParse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            Console.WriteLine(doc);
            //List<Contact> con =
            //(
            //    from x in doc.Elements("Contact")
            //    select new Contact()
            //    {
            //        name = (string)x.Element("Name").Value,
            //        phone = (string)x.Element("Phone").Value
            //    }).ToList();

            //foreach (var y in con)
            //{ Console.WriteLine(y.name); }

           // return result.First();
        }
    }
    }

