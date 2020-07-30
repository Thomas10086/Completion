using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 仓储Model;

namespace 仓储DAL
{
    public class BaseDAL<T> where T:class
    {
        Completion db = new Completion();
        public virtual List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
        public virtual T GetByPK(object pk)
        {
            return db.Set<T>().Find(pk);
        }
        public virtual List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).ToList();
        }
        public virtual T GetObj(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }
        public virtual bool Add(T info)
        {
            db.Set<T>().Add(info);
            return db.SaveChanges() > 0;
        }

        public virtual bool Update(T info)
        {
            db.Entry<T>(info).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public virtual bool Delete(object pk)
        {
            var info = db.Set<T>().Find(pk);
            if (info == null)
            {
                return false;
            }
            {
                db.Set<T>().Remove(info);
                return db.SaveChanges() > 0;
            }
        }
    }
}
