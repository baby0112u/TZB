using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZB.Dto;
using TZB.Entity;
using TZB.IService;
using TZB.SqlServerDB;
using TZB.Utils;

namespace TZB.Service
{
    public class UserInfoService : IUserInfoService
    {
        public long AddNew(string mobile, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string mobile, string password)
        {
            throw new NotImplementedException();
        }

        private Dto.UserInfo ToDTO(Entity.UserInfo user)
        {
            throw new NotImplementedException();
        }

        public Dto.UserInfo GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Dto.UserInfo GetBymobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public void SetUserCityId(long userId, long cityId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePwd(long userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void IncrLoginError(long id)
        {
            throw new NotImplementedException();
        }

        public void ResetLoginError(long id)
        {
            throw new NotImplementedException();
        }

        public bool IsLocked(long id)
        {
            throw new NotImplementedException();
        }

        Dto.UserInfo IUserInfoService.GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
