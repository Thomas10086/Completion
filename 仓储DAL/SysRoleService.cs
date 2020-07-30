using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储Model;

namespace 仓储DAL
{
    public class SysRoleService:BaseDAL<SysRole>
    {
        public List<SysRole> QureyAll() {
            BaseDAL<SysRole> dal = new BaseDAL<SysRole>();
            return dal.GetAll();
        }
    }
}
