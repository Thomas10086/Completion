using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 仓储UI.Models
{
    public class AdmitModel
    {
        //[StringLength(20)]
        [Required(ErrorMessage = "账号为不能为空")]
        //  [StringLength(10,ErrorMessage ="长度在6~10之间",MinimumLength =6)] 

        public string UserName { get; set; }
        
        [Required(ErrorMessage = "密码为不能为空")]
        //  [StringLength(10,ErrorMessage ="长度在6~10之间",MinimumLength =6)] 

        public string PassWord { get; set; }
    }
}