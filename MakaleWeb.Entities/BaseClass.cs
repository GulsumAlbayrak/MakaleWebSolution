using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.Entities
{
    public class BaseClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public DateTime OlusturmaTarihi { get; set; }
        [Required]
        public DateTime DegistirmeTarihi { get; set; }
        [Required,StringLength(25)]
        public string DegistirenKullanici { get; set; }
    }
}
