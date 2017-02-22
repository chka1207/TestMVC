using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Vakt
    {
        public int VaktID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        [DataType(DataType.PostalCode)]
        public string Postnummer { get; set; }
        public string Ort { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobilnummer { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}