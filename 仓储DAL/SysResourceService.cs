using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using 仓储Model;

namespace 仓储DAL
{
    public class SysResourceService:BaseDAL<SysResource>
    {
        /// <summary>
        /// 菜单栏
        /// </summary>
        /// <returns></returns>
        public List<SysResource> LeftQeruy() {
            Completion db = new Completion();
            List<SysResource> list=db.SysResource.Where(x=>x.ResNum.EndsWith("1000")).OrderByDescending(x=>x.CreateTime).ToList();
            return list;
        }
    }
}
