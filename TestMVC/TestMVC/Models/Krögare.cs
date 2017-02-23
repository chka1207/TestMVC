using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Krögare
    {
        public int KrögareID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }
        public string Mobilnummer { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual List<Krog> Krogar { get; set; }
    }
}