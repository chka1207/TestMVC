using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Pass
    {
        public int PassID { get; set; }
        public int VaktID { get; set; }

        public int KrogID { get; set; }
        public virtual Krog Krog { get; set; }

        [Required()]
        [Display(Name ="Datum när passet startar")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Start { get; set; }

        [DataType(DataType.Time)]
        public DateTime Slut { get; set; }
    }
}