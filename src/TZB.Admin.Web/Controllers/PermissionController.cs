using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZB.Framework;
using TZB.IService;

namespace TZB.Admin.Web.Controllers
{
    public class PermissionController : Controller
    {
        public IPermissionService PermSvc { get; set; }
        // GET: Permission
        public ActionResult List()
        {
            var perms = PermSvc.GetAll();
            AjaxResult result = new AjaxResult() { Status = 0, Msg = "获取权限列表成功!", Data = perms };
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string desc, string name)
        {
            long id = PermSvc.AddPermission(name, desc);
            AjaxResult result = new AjaxResult();
            if (id > 0)
            {
                result.Status = 0;
                result.Msg = "新增成功！";
                result.Data = id;
            }
            else
            {
                result.Status = 1;
                result.Msg = "新增失败";
            }
            return Json(result);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var perm = PermSvc.GetById(id);
            return View(perm);
        }

        [HttpPost]
        public ActionResult Edit(long id, string desc, string name)
        {
            int record = PermSvc.UpdatePermission(id, name, desc);
            AjaxResult result = new AjaxResult() ;
            if(record == 1)
            {
                result.Status = 0;
                result.Msg = "更新成功！";
            }
            else
            {
                result.Status = 1;
                result.Msg = "更新失败";
            }
            return Json(result);
        }
        /// <summary>
        /// 可能会有多个同时删除的，所以MarkDeleted还是返回int
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long id)
        {
            int i = PermSvc.MarkDeleted(id);
            if (i == 0)
            {

                return Json(new AjaxResult() { Status = 1, Msg = "删除失败！" });
            }
            else
            {
                return Json(new AjaxResult() { Status = 0,Msg = "删除成功！"});
            }
        }
    }
}