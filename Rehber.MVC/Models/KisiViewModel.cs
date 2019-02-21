using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class KisiViewModel
    {
        public int KisiId { get; set; }
        [MaxLength(20, ErrorMessage = "Ad alanı maksimum 20 karakter olabilir")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Adi { get; set; }
        [MaxLength(20, ErrorMessage = "Soyad alanı maksimum 20 karakter olabilir")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyadi { get; set; }
        [Range(10,60,ErrorMessage = "Yaş alanı 10 ile 60 arasında olabilir")]
        [Required(ErrorMessage = "Yaş alanı boş geçilemez")]
        public int Yas { get; set; }
    }
}