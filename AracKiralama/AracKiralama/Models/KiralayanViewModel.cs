using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class KiralayanViewModel
    {
        [Key]
        public int Id { get; set; }
        public string IsimSoyisim { get; set; }
        public string Adres { get; set; }
        public double TCKN { get; set; }
        public double Tel1 { get; set; }
        public double Tel2 { get; set; }
        public string EMail { get; set; }
        public string KiralayacagiArac { get; set; }
    }
}