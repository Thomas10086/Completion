using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class AdminManager : BaseBLL<Admin>
    {
        public AdminManager() : base(new AdminService())
        {

        }
    }
}
