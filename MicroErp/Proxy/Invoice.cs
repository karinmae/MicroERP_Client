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
        [XmlElement("Id")]
        public string ID { get; set; }

        [XmlElement("Date")]
        public string Datum { get; set; }

        [XmlElement("PaymentDate")]
        public string Faelligkeit { get; set; }

        [XmlElement("Number")]
        public string Nummer { get; set; }

        [XmlElement("IDContact")]
        public int IDKontakt { get; set; }

        [XmlElement("Firstname")]
        public string Vorname { get; set; }

        [XmlElement("Lastname")]
        public string Nachname { get; set; }

        [XmlElement("Billingadress")]
        public string Billingadress { get; set; }

        [XmlElement("Comment")]
        public string Kommentar { get; set; }

        [XmlElement("Message")]
        public string Nachricht { get; set; }

        [XmlElement("Article1")]
        public string Artikel1 { get; set; }

        [XmlElement("Amount1")]
        public string Menge1 { get; set; }

        [XmlElement("UnitPrice1")]
        public string Stueckpreis1 { get; set; }

        [XmlElement("Ust1")]
        public string Ust1 { get; set; }

        [XmlElement("Article2")]
        public string Artikel2 { get; set; }

        [XmlElement("Amount2")]
        public string Menge2 { get; set; }

        [XmlElement("UnitPrice2")]
        public string Stueckpreis2 { get; set; }

        [XmlElement("Ust2")]
        public string Ust2 { get; set; }

        [XmlElement("Article3")]
        public string Artikel3 { get; set; }

        [XmlElement("Amount3")]
        public string Menge3 { get; set; }

        [XmlElement("UnitPrice3")]
        public string Stueckpreis3 { get; set; }

        [XmlElement("Ust3")]
        public string Ust3 { get; set; }
    }
}