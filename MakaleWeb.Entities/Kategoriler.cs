using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities
{
    public class Kategoriler:BaseClass
    {
        [Required(ErrorMessage = "{0} alanı gereklidir."),
           StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Baslik { get; set; }

        [StringLength(150, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Aciklama { get; set; }

        public virtual List<Makaleler> Makaleler { get; set; }

    }
}
