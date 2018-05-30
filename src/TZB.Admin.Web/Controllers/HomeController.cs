using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZB.Dto;
using TZB.Framework;

namespace TZB.Admin.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int pageIndex = 1,int pageSize = 10)
        {
            return View(new PageList
            {
                Status = 0,
                Msg = "成功",
                Data = new UserInfo { },
                PageInfo = new PageInfo { }
            });
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return Json(new PageList { });
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return Json(new AjaxResult { Status=1,Msg="fdsa",Data = null });
        }
    }
}