using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp
{
    /* Firma */

    [XmlRoot("Firmen")]
    public class FirmList
    {
        [XmlElement("Firma")]
        public List<Firma> Firma { get; set; }
    }

    public class Firma
    {
        [XmlElement("Id")]
        public string ID { get; set; }

        [XmlElement("Uid")]
        public string UID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Adresse")]
        public string Adresse { get; set; }

        [XmlElement("deliveryaddress")]
        public string Lieferadresse { get; set; }

        [XmlElement("billingaddress")]
        public string Rechnungsadresse { get; set; }
    }
}