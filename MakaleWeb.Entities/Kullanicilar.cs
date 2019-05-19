using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities
{
   public class Kullanicilar:BaseClass
    {           
        [StringLength(25)]
        public string Ad { get; set; }
        [StringLength(25)]
        public string Soyad { get; set; }
        [Required, StringLength(25)]
        public string KullaniciAd { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Sifre { get; set; }
        public bool Aktif { get; set; }
        [Required]
        public Guid AktifGuid { get; set; }
        public bool Adminmi { get; set; }

        public virtual List<Makaleler> Makaleler { get; set; }
        public virtual List<Yorumlar> Yorumlar { get; set; }
        public virtual List<Begeniler> Begeniler { get; set; }




    }
}
