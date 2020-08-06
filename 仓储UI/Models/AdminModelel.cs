using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 仓储Model;

namespace 仓储UI.Models
{
    public class AdminModelel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string ZName { get; set; }

        public string RoleNum { get; set; }

        public string DepartNum { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Remark { get; set; }
    }
}