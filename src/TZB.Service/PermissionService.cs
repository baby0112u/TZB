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
    public class PermissionService : IPermissionService
    {
        public void AddPermIds(long roleId, long[] permIds)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> roleBS
                    = new BaseService<Entity.Role>(ctx);
                var role = roleBS.GetById(roleId);
                if (role == null)
                {
                    throw new ArgumentException("roleId不存在" + roleId);
                }
                BaseService<Entity.Permission> permBS
                    = new BaseService<Entity.Permission>(ctx);
                var perms = permBS.GetAll()
                    .Where(p => permIds.Contains(p.Id)).ToArray();
                foreach (var perm in perms)
                {
                    role.Permissions.Add(perm);
                }
                ctx.SaveChanges();
            }
        }

        public long AddPermission(string permName, string description)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                // 不加id 更新描述就更不了了
                var existName = ctx.Permissions.Any(p => p.Name == permName);
                if (existName)
                {
                    throw new ArgumentException(permName + "权限已存在");
                }
                var per = new Entity.Permission();
                per.Name = permName;
                per.Description = description;
                ctx.Permissions.Add(per);
                ctx.SaveChanges();
                return per.Id;
            }
        }

        public Dto.Permission[] GetAll()
        {
            //throw new NotImplementedException();
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                return bs.GetAll().ToList().Select(p => ToDTO(p)).ToArray();
            }
        }

        private Dto.Permission ToDTO(Entity.Permission p)
        {
            Dto.Permission per = new Dto.Permission();
            per.CreateDateTime = p.CreateDateTime;
            per.Description = p.Description;
            per.Id = p.Id;
            per.Name = p.Name;
            return per;
        }

        public Dto.Permission GetById(long id)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                Entity.Permission per = bs.GetById(id);
                return per == null ? null : ToDTO(per);
            }
        }

        public Dto.Permission GetByName(string name)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                var pe = bs.GetAll().SingleOrDefault(p => p.Name == name);
                return pe == null ? null : ToDTO(pe);
            }
        }

        public Dto.Permission[] GetByRoleId(long roleId)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> bs = new BaseService<Entity.Role>(ctx);
                return bs.GetById(roleId).Permissions.ToList().Select(p => ToDTO(p)).ToArray();
            }
        }

        public int MarkDeleted(long id)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                return bs.MarkDeleted(id);
            }
        }

        public void UpdatePermIds(long roleId, long[] permIds)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Role> roleBS
                    = new BaseService<Entity.Role>(ctx);
                var role = roleBS.GetById(roleId);
                if (role == null)
                {
                    throw new ArgumentException("roleId不存在" + roleId);
                }
                role.Permissions.Clear();
                BaseService<Entity.Permission> permBS
                    = new BaseService<Entity.Permission>(ctx);
                var perms = permBS.GetAll()
                    .Where(p => permIds.Contains(p.Id)).ToList();
                foreach (var perm in perms)
                {
                    role.Permissions.Add(perm);
                }
                ctx.SaveChanges();
            }
        }

        public int UpdatePermission(long id, string permName, string description)
        {
            using (SqlServerDB.SqlDbContext ctx = new SqlServerDB.SqlDbContext())
            {
                BaseService<Entity.Permission> bs = new BaseService<Entity.Permission>(ctx);
                var per = bs.GetById(id);
                if(per == null)
                {
                    throw new ArgumentException("id不存在" + id);
                }
                // 不加id 更新描述就更不了了
                var existName = ctx.Permissions.Any(p => p.Name == permName&&p.Id !=id);
                if(existName)
                {
                    throw new ArgumentException(permName + "权限已存在");
                }
                per.Name = permName;
                per.Description = description;
                return  ctx.SaveChanges();
            }
        }
    }
}
