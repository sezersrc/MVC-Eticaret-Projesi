using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Eticaret.Business
{
    public class CrudeRepositorycs<T> : ConnectionBase, IData<T> where T : class

    {
        private readonly DbSet<T> Tabloset;

        public CrudeRepositorycs()
        {
            Tabloset = context.Set<T>();
        }

        public int Delete(T data)
        {
            Tabloset.Remove(data);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return Tabloset.FirstOrDefault(where);
        }

        public int Insert(T data)
        {
            Tabloset.Add(data);
            return Save();
        }

        public List<T> List()
        {
            return Tabloset.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return Tabloset.Where(where).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(T data)
        {
            Tabloset.Attach(data);
            context.Entry(data).State = EntityState.Modified;
            return Save();
        }
    }
}