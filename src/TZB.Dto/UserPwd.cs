using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Dto
{
    public class UserPwd : BaseDto
    {
        /// <summary>
        /// UserId varchar2(10) not null, --工号 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// UserName VARCHAR2(50) not null, --用户账号 
        /// </summary>
        public string UserName { get; set; }

        public string PasswordSalt { get; set; }
        /// <summary>
        /// LoginErrTimes INTEGER default 0 not null,--登陆错误次数
        /// </summary>
        public int LoginErrTimes { set; get; } = 0;
        /// <summary>
        /// LastLoginErrtime DATE default SYSDATE not null,--最后一次错误登陆时间
        /// </summary>
        public DateTime LastLoginErrtime { get; set; } = DateTime.Now;


    }
}
