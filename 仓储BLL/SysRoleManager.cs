using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class SysRoleManager:BaseBLL<SysRole>
    {
        public SysRoleManager() : base(new SysRoleService())
        {
            
        }
        public List<SysRole> QueryAll() {
            SysRoleService dal = new SysRoleService();
            return dal.GetAll();
        }

    }
}
