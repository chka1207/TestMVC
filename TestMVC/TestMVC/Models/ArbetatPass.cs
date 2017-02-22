using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class ArbetatPass
    {
        public int ArbetatPassID { get; set; }
        public Vakt Vakt { get; set; }
        public Krog Krog { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        [DataType(DataType.Time)]
        public DateTime Start { get; set; }
        [DataType(DataType.Time)]
        public DateTime Slut { get; set; }
    }
}