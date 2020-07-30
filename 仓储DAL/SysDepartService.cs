using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储Model;

namespace 仓储DAL
{
    public class SysDepartService:BaseDAL<SysDepart>
    {
        public List<SysDepart> QueryAll() {
            BaseDAL<SysDepart> dal = new BaseDAL<SysDepart>();
            return dal.GetAll();
        }
    }
}
