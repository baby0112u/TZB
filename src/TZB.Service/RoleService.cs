using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.Dto;
using TZB.Entity;
using TZB.IService;

namespace TZB.Service
{
    public class RoleService : IRoleService
    {
        public long AddNew(string roleName,string description)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> bs = new BaseService<Entity.Role>(ctx);
                // 不加id 更新描述就更不了了
                var existName = ctx.Roles.Any(r => r.Name == roleName);
                if (existName)
                {
                    throw new ArgumentException(roleName + "角色已存在");
                }
                var role = new Entity.Role();
                role.Name = roleName;
                role.Description = description;
                ctx.Roles.Add(role);
                ctx.SaveChanges();
                return role.Id;
            }
        }

        public void AddRoleIds(long adminUserId, long[] roleIds)
        {
            throw new NotImplementedException();
        }

        public Dto.Role[] GetAll()
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> bs = new BaseService<Entity.Role>(ctx);
                return bs.GetAll().ToList().Select(r => ToDTO(r)).ToArray();
            }
        }

        private Dto.Role ToDTO(Entity.Role r)
        {
            Dto.Role role = new Dto.Role();
            role.CreateDateTime = r.CreateDateTime;
            role.Description = r.Description;
            role.Id = r.Id;
            role.Name = r.Name;
            return role;
        }

        public Dto.Role[] GetByAdminUserId(long adminUserId)
        {
            throw new NotImplementedException();
        }

        public Dto.Role GetById(long id)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> bs = new BaseService<Entity.Role>(ctx);
                var role = bs.GetById(id);
                return role == null ? null : ToDTO(role);
            }
        }

        public Dto.Role GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void MarkDeleted(long roleId)
        {
            throw new NotImplementedException();
        }

        public void Update(long roleId, string roleName, string description)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> roleBS = new BaseService<Entity.Role>(ctx);
                bool exists = roleBS.GetAll().Any(r => r.Name == roleName && r.Id != roleId);
                //正常情况不应该执行这个异常，因为UI层应该把这些情况处理好
                //这里只是“把好最后一关”
                if (exists)
                {
                    throw new ArgumentException("角色名已存在");
                }
                Entity.Role role = new Entity.Role();
                role.Id = roleId;
                ctx.Entry(role).State = System.Data.Entity.EntityState.Unchanged;
                role.Name = roleName;
                role.Description = description;
                ctx.SaveChanges();
            }
        }

        public void UpdateRoleIds(long adminUserId, long[] roleIds)
        {
            throw new NotImplementedException();
        }
    }
}
