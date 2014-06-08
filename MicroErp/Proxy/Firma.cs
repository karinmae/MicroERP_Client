using System.Collections.Generic;
using System.Xml.Serialization;

namespace MicroErp
{
    /* Firma */

    [XmlRoot("Firmen")]
    public class Firmlist
    {
        [XmlElement("Firma")]
        public List<Firma> Firma { get; set; }
    }

    public class Firma
    {
        [XmlElement("ID")]
        public string ID { get; set; }

        [XmlElement("UID")]
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