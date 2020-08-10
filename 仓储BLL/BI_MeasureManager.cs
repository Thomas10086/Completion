using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class BI_MeasureManager:BaseBLL<BI_Measure>
    {
        public BI_MeasureManager() : base(new BI_MeasureService()) { }

    }
}
