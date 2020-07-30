using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class SysDepartManager:BaseBLL<SysDepart>
    {
        public SysDepartManager() : base(new SysDepartService())
        {

        }
        public List<SysDepart> QueryAll() {
            SysDepartService dal = new SysDepartService();
            return dal.GetAll();
        }
    }
}
