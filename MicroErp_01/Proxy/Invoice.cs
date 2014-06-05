using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp_01
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

        [XmlElement("Kommentar")]
        public string Kommentar { get; set; }

        [XmlElement("Nachricht")]
        public string Nachricht { get; set; }

        [XmlElement("Menge")]
        public string Menge { get; set; }

        [XmlElement("Stueckpreis")]
        public string Stueckpreis { get; set; }

        [XmlElement("Ust")]
        public string Ust { get; set; }
    }
}