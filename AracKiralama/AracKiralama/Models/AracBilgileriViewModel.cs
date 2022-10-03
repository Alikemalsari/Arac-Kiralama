using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models
{
    public class AracBilgileriViewModel
    {
        [Key]
        public int Id { get; set; }
        public string AracAdi { get; set; }
        public string AracBilgisi { get; set; }
        public int Fiyati { get; set; }
        public string AracResmi { get; set; }
    }
}