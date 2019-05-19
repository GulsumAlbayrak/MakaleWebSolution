using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.DataAccessLayer
{
    public class Singleton
    {
        public static DatabaseContext db;
        private static object _obj = new object();
        protected Singleton()
        {
            ContextOlustur();
        }
        public static void ContextOlustur()
        {
            if (db==null)
            {
                lock (_obj) //multithread uygulamalarda context nesnesinin iki kere oluşturulmasının önüne geçmek için kilitleme işi yapar.
                {
                    if (db == null)
                        db = new DatabaseContext();
                }
              
            }

        }

    }
}
