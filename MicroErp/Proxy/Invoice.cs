using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp
{
    /* Invoice */

    [XmlRoot("Invoices")]
    public class InvoiceList
    {
        [XmlElement("Invoice")]
        public List<Invoice> Invoice { get; set; }
    }

    public class Invoice
    {
        [XmlElement("ID")]
        public string ID { get; set; }

        [XmlElement("Datum")]
        public string Datum { get; set; }

        [XmlElement("Faelligkeit")]
        public string Faelligkeit { get; set; }

        [XmlElement("Nummer")]
        public string Nummer { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Billingadress")]
        public string Billingadress { get; set; }

        [XmlElement("Kommentar")]
        public string Kommentar { get; set; }

        [XmlElement("Nachricht")]
        public string Nachricht { get; set; }

        [XmlElement("Artikel1")]
        public string Artikel1 { get; set; }

        [XmlElement("Menge1")]
        public string Menge1 { get; set; }

        [XmlElement("Stueckpreis1")]
        public string Stueckpreis1 { get; set; }

        [XmlElement("Ust1")]
        public string Ust1 { get; set; }

        [XmlElement("Artikel2")]
        public string Artikel2 { get; set; }

        [XmlElement("Menge2")]
        public string Menge2 { get; set; }

        [XmlElement("Stueckpreis2")]
        public string Stueckpreis2 { get; set; }

        [XmlElement("Ust2")]
        public string Ust2 { get; set; }

        [XmlElement("Artikel3")]
        public string Artikel3 { get; set; }

        [XmlElement("Menge3")]
        public string Menge3 { get; set; }

        [XmlElement("Stueckpreis3")]
        public string Stueckpreis3 { get; set; }

        [XmlElement("Ust3")]
        public string Ust3 { get; set; }
    }
}