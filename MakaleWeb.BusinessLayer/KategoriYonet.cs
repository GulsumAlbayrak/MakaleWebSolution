using MakaleWeb.DataAccessLayer;
using MakaleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
    public class KategoriYonet
    {
        private Repository<Kategoriler> rep_kat = new Repository<Kategoriler>();

        public List<Kategoriler> KategoriGetir()
        {
          return rep_kat.List();
        }

        public Kategoriler IDKategoriGetir(int id)
        {
            return rep_kat.Find(x => x.ID == id);
        }
    }
}
