using MakaleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.DataAccessLayer
{
    public class Repository<T>:Singleton where T : class
    {
       // private DatabaseContext db;
        private DbSet<T> _objectset;
   
        public Repository()
        {
           // db = Singleton.ContextOlustur();
            _objectset = db.Set<T>();
        }

        private int Save()
        {
           return db.SaveChanges();
        }

        public int Insert(T obj)
        {
            _objectset.Add(obj);
            if(obj is BaseClass)
            {
                BaseClass bc = obj as BaseClass;
                DateTime dt = DateTime.Now;

                bc.OlusturmaTarihi = dt;
                bc.DegistirmeTarihi = dt;
                bc.DegistirenKullanici = "elifcengiz";
            }
            return Save();
        }

        public int Update(T obj)
        {
            if (obj is BaseClass)
            {
                BaseClass bc = new BaseClass();
         
                bc.DegistirmeTarihi = DateTime.Now;
                bc.DegistirenKullanici = "elifcengiz";
            }
            return Save();
        }

        public int Delete(T obj)
        {
            _objectset.Remove(obj);
            return Save();
        }

        public List<T> List()
        {
            return _objectset.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
           return _objectset.Where(where).ToList();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
           return _objectset.FirstOrDefault(where);
        }
        
        public IQueryable<T> ListQueryable()
        {
            return _objectset.AsQueryable<T>();
        }
    }
}
