using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
    public class ArbetatPass
    {
        public int ArbetatPassID { get; set; }
        public Vakt Vakt { get; set; }
        public Krog Krog { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
    }
}