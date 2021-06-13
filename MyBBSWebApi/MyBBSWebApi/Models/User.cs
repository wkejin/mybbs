using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserNO { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int UserLevel { get; set; }
        public bool IsDeleted { get; set; }
    }
}
