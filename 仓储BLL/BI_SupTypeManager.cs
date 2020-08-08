using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class BI_SupTypeManager:BaseBLL<BI_SupType>
    {
        public BI_SupTypeManager() : base(new BI_SupTypeService())
        {

        }
    }
}
