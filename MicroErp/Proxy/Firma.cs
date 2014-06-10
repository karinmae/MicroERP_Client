using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp
{
    /* Firma */

    [XmlRoot("Firms")]
    public class FirmList
    {
        [XmlElement("Firm")]
        public List<Firma> Firma { get; set; }
    }

    public class Firma
    {
        [XmlElement("ID")]
        public string Id { get; set; }

        [XmlElement("UID")]
        public string UID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Adress")]
        public string Adresse { get; set; }

        [XmlElement("deliveryaddress")]
        public string Lieferadresse { get; set; }

        [XmlElement("billingaddress")]
        public string Rechnungsadresse { get; set; }
    }
}