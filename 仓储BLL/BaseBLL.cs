using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;

namespace 仓储BLL
{
    public class BaseBLL<T> where T : class
    {
        BaseDAL<T> _dal = null;

        public BaseBLL(BaseDAL<T> dal)
        {
            _dal = dal;
        }

        public List<T> GetAll()
        {
            return _dal.GetAll();
        }
        public T GetByPK(object pk)
        {
            return _dal.GetByPK(pk);
        }
        public bool Add(T info)
        {
            return _dal.Add(info);
        }
        public bool Update(T info)
        {
            return _dal.Update(info);
        }

        public bool Delete(object pk)
        {
            return _dal.Delete(pk);
        }
        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dal.Where(predicate);
        }
        public T GetObj(Expression<Func<T, bool>> predicate)
        {
            return _dal.GetObj(predicate);
        }
    }
}
