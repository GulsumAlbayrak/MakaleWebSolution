using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities
{
   public class Yorumlar:BaseClass
    {
        [Required, StringLength(3000)]
        public string Metin { get; set; }

        public virtual Makaleler Makale { get; set; }
        public virtual Kullanicilar Kullanici { get; set; }
    }
}
