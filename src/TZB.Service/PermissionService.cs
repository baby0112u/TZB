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
            throw new NotImplementedException();
        }

        public long AddPermission(string permName, string description)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Dto.Permission GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Dto.Permission[] GetByRoleId(long roleId)
        {
            throw new NotImplementedException();
        }

        public void MarkDeleted(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermIds(long roleId, long[] permIds)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermission(long id, string permName, string description)
        {
            throw new NotImplementedException();
        }
    }
}
