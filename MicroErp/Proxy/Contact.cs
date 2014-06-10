using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp
{
    /* Contact */

    [XmlRoot("Contacts")]
    public class ContactsList
    {
        [XmlElement("Contact")]
        public List<Contact> contact { get; set; }
    }

    public class Contact
    {
        [XmlElement("Id")]
        public string ID { get; set; }

        [XmlElement("Titel")]
        public string Titel { get; set; }

        [XmlElement("Firstname")]
        public string Vorname { get; set; }

        [XmlElement("Lastname")]
        public string Nachname { get; set; }

        [XmlElement("Suffix")]
        public string Suffix { get; set; }

        [XmlElement("Birthday")]
        public string Geburtsdatum { get; set; }

        [XmlElement("Adresse")]
        public string Adresse { get; set; }

        [XmlElement("deliveryaddress")]
        public string Lieferadresse { get; set; }

        [XmlElement("billingaddress")]
        public string Rechnungsadresse { get; set; }
    }
}