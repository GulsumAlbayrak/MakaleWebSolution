using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities
{
    public class Makaleler:BaseClass
    {
        [Required,StringLength(60)]
        public string Baslik { get; set; }
        [Required, StringLength(10000)]
        public string Metin { get; set; }
        public bool Taslakmi { get; set; }
        public int BegeniSayisi { get; set; }
        public int KategorilerID { get; set; }

        public virtual Kategoriler Kategori { get; set; }
        public virtual Kullanicilar Kullanici { get; set; }
        public virtual List<Yorumlar> Yorumlar { get; set; }
        public virtual List<Begeniler> Begeniler { get; set; }
    }
}
