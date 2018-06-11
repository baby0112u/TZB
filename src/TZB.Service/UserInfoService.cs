using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (SqlDbContext ctx = new SqlDbContext())
            {
                //检查手机号不能重复

                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                bool exists = bs.GetAll().Any(u => u.Mobile == mobile);
                if (exists)
                {
                    throw new ArgumentException("手机号已经存在");
                }
                UserInfo user = new UserInfo();
                user.Mobile = mobile;
                string salt = mobile;
                string pwdHash = MD5Helper.CalcMD5(salt + password);
                user.PasswordHash = pwdHash;
                user.PasswordSalt = salt;
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return user.Id;
            }
        }

        public bool CheckLogin(string mobile, string password)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetAll().SingleOrDefault(u => u.mobile == mobile);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    string dbPwdHash = user.PasswordHash;
                    string salt = user.PasswordSalt;
                    string userPwdHash = MD5Helper.CalcMD5(salt + password);
                    return dbPwdHash == userPwdHash;
                }
            }
        }

        private UserDTO ToDTO(UserInfo user)
        {
            UserDTO dto = new UserDTO();
            dto.CityId = user.CityId;
            dto.CreateDateTime = user.CreateDateTime;
            dto.Id = user.Id;
            dto.LastLoginErrorDateTime = user.LastLoginErrorDateTime;
            dto.LoginErrorTimes = user.LoginErrorTimes;
            dto.mobile = user.mobile;
            return dto;
        }

        public UserDTO GetById(long id)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetById(id);
                return user == null ? null : ToDTO(user);
            }
        }

        public UserDTO GetBymobile(string mobile)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetAll().SingleOrDefault(u => u.mobile == mobile);
                return user == null ? null : ToDTO(user);
            }
        }

        public void SetUserCityId(long userId, long cityId)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentException("用户id不存在" + userId);
                }
                user.CityId = cityId;
                ctx.SaveChanges();
            }
        }

        public void UpdatePwd(long userId, string newPassword)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                //检查手机号不能重复
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + userId);
                }
                string salt = user.PasswordSalt;// CommonHelper.CreateVerifyCode(5);
                string pwdHash = CommonHelper.CalcMD5(salt + newPassword);
                user.PasswordHash = pwdHash;
                user.PasswordSalt = salt;
                ctx.SaveChanges();
            }
        }

        public void IncrLoginError(long id)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                //检查手机号不能重复
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetById(id);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + id);
                }
                user.LoginErrorTimes++;
                user.LastLoginErrorDateTime = DateTime.Now;
                ctx.SaveChanges();
            }
        }

        public void ResetLoginError(long id)
        {
            using (SqlDbContext ctx = new SqlDbContext())
            {
                //检查手机号不能重复
                BaseService<UserInfo> bs = new BaseService<UserInfo>(ctx);
                var user = bs.GetById(id);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + id);
                }
                user.LoginErrorTimes = 0;
                user.LastLoginErrorDateTime = null;
                ctx.SaveChanges();
            }
        }

        public bool IsLocked(long id)
        {
            var user = GetById(id);
            //错误登录次数>=5，最后一次登录错误时间在30分钟之内
            return (user.LoginErrorTimes >= 5
                && user.LastLoginErrorDateTime > DateTime.Now.AddMinutes(-30));
        }
    }
}
