using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class Krog
    {
        public int KrogID { get; set; }
        public string Namn { get; set; }
        public string Adress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }
        public Krögare Krögare { get; set; }
        

    }
}