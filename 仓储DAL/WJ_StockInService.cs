using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 仓储Model;

namespace 仓储DAL
{
    public class WJ_StockInService:BaseDAL<WJ_StockIn>
    {
        public List<WJ_StockIn> QueryId(string StoINum,int SSNum)
        {
            Completion db = new Completion();
            return db.WJ_StockIn.Where(x => x.StoINum.Contains(StoINum) && x.SSNum.Equals(SSNum)).ToList() ;
        }
    }
}
