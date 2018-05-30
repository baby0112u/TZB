using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZB.Dto;
using TZB.EFService;
using TZB.Framework;
using TZB.Utils;

namespace TZB.Admin.Web.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: AdminUser
        public ActionResult Index()
        {
            UserInfo user = new UserInfo { Birthday = DateTime.Now, CompId = "1100", CompName = "北京分公司", CreateDateTime = DateTime.Now, Id = 1, RegisterDate = DateTime.Now, UpdateTime = DateTime.Now, UserName = "刘琦", UserLevel = 1004 };

            return View(user);
        }
        public ActionResult List()
        {
            return View(new PageList
            {
                Status = 0,
                Msg = "成功",
                Data = new UserInfo { },
                PageInfo = new PageInfo { }
            });
        }
        public ActionResult Insert()
        {
            int i;
            using (SqlDbContext ctx = new SqlDbContext())
            {
                TZB.Entity.UserPwd pwd = new TZB.Entity.UserPwd();
                pwd.LastLoginErrtime = DateTime.Now;
                pwd.LoginErrTimes = 0;
                pwd.PasswordSalt = "1828686****";
                pwd.UserId = "011239";
                pwd.UserName = "baby0112";
                pwd.PasswordHash = MD5Helper.CalcMD5(pwd.PasswordSalt + pwd.UserId);
                ctx.UserPwds.Add(pwd);
                i = ctx.SaveChanges();
            }
            return View(i);
        }
    }
}