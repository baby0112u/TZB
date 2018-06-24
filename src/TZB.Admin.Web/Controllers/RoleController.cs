using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZB.Admin.Web.Models;
using TZB.Framework;
using TZB.IService;

namespace TZB.Admin.Web.Controllers
{
    public class RoleController : Controller
    {
        public IRoleService roleSvc { get; set; }
        public IPermissionService perSvc { get; set; }
        // GET: Role
        public ActionResult List()
        {
            var roles = roleSvc.GetAll();
            return View(new AjaxResult() { Status = 0, Msg = "获取数据成功", Data = roles });
        }
        [HttpGet]
        public ActionResult Add()
        {
            var perms = perSvc.GetAll();
            return View(perms);
        }
        [HttpPost]
        public ActionResult Add(RolePermAddModel model)
        {
            long roleId = roleSvc.AddNew(model.Name, model.Description);
            perSvc.AddPermIds(roleId, model.PermissionIds);
            return Json(new AjaxResult() { Status = 0, Msg = "角色添加成功", Data = roleId });
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            RolePermEditGetModel model = new RolePermEditGetModel();
            model.AllPermissions = perSvc.GetAll();
            model.OwnPermissions = perSvc.GetByRoleId(id);
            model.Role = roleSvc.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RolePermEditPostModel model)
        {
            roleSvc.Update(model.Id, model.Name, model.Desc);
            perSvc.UpdatePermIds(model.Id, model.PermissionIds);
            return Json(new AjaxResult() { Status = 0 ,Msg = "角色修改成功！"});
        }
    }
}