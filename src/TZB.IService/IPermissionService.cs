using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.IService
{
    public interface IPermissionService : IServiceSupport
    {
        long AddPermission(string permName, string description);
        int UpdatePermission(long id, string permName, string description);
        int MarkDeleted(long id);

        Dto.Permission GetById(long id);
        Dto.Permission[] GetAll();
        Dto.Permission GetByName(String name);//GetByName("User.Add")

        //获取角色的权限
        Dto.Permission[] GetByRoleId(long roleId);

        //给角色roleId增加权限项id permIds
        void AddPermIds(long roleId, long[] permIds);

        //更新角色role的权限项：先删除再添加
        void UpdatePermIds(long roleId, long[] permIds);
    }
}
