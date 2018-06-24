﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.IService
{
    public interface IRoleService: IServiceSupport
    {
        //新增角色
        long AddNew(String roleName, string description);
        void Update(long roleId, String roleName, string description);
        void MarkDeleted(long roleId);
        Dto.Role GetById(long id);
        Dto.Role GetByName(string name);
        Dto.Role[] GetAll();
        //给用户adminuserId增加权限roleIds
        void AddRoleIds(long adminUserId, long[] roleIds);

        //更新权限，先删再加
        void UpdateRoleIds(long adminUserId, long[] roleIds);

        //获取用户的角色
        Dto.Role[] GetByAdminUserId(long adminUserId);
    }
}
