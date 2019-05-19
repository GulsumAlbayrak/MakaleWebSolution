using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
    public class BLHatalar<T> where T:class
    {
        public List<string> Hata { get; set; }
        public T sonuc { get; set; }
        public BLHatalar()
        {
            Hata = new List<string>();
        }
    }
}
