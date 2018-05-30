using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Dto
{
    public class UserInfo : BaseDto
    {
        /// <summary>
        /// UserId varchar2(10) not null, --工号 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// UserName varchar2(100) not null, --姓名 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///  Gender varchar2(6), --性别  
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// IdCard varchar2(32), --身份证 
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// Birthday date, --状态更新日期  
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// QQ varchar2(12), --QQ号    
        /// </summary>              
        public string QQ { get; set; }
        /// <summary>
        ///  Mobile varchar2(15), --手机号   
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// Email varchar2(100), --邮箱
        /// </summary>          
        public string Email { get; set; }
        /// <summary>
        /// CompId varchar2(10) not null, --公司代码    
        /// </summary>              
        public string CompId { get; set; }
        /// <summary>
        /// CompName varchar2(100) not null, --公司名称   
        /// </summary>
        public string CompName { get; set; }
        /// <summary>
        /// OrgId varchar2(10) not null, --部门代码
        /// </summary>
        public string OrgId { get; set; }
        /// <summary>
        /// OrgName varchar2(100) not null, --部门名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// JobId varchar2(10) not null, --岗位代码   
        /// </summary>          
        public string JobId { get; set; }
        /// <summary>
        /// JobName varchar2(100) not null, --岗位名称    
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// RoleId varchar2(10) not null, --角色代码    
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// RoleName varchar2(100) not null, --角色名称    
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// UserLevel integer not null, --用户级别
        /// </summary>
        public int UserLevel { get; set; }
        /// <summary>
        /// Status varchar2(10) not null, --在职状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// RegisterDate date not null, --入职日期
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// UpdateTime date not null, --状态更新日期
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
