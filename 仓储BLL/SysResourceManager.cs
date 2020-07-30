using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class SysResourceManager:BaseBLL<SysResource>
    {
        public SysResourceManager() : base(new SysResourceService())
        {

        }
        public List<SysResource> QueryLeft() {
            SysResourceService dal = new SysResourceService();
            return dal.LeftQeruy();
        }
    }
}
