using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class SysRelationManager:BaseBLL<SysRelation>
    {
        public SysRelationManager() : base(new SysRelationService())
        {

        }
    }
}
