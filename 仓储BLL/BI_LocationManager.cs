using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储DAL;
using 仓储Model;

namespace 仓储BLL
{
    public class BI_LocationManager:BaseBLL<BI_Location>
    {
        public BI_LocationManager():base(new BI_LocationService())
        {

        }
    }
}
