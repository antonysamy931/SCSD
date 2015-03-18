using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCSD.DTO.Model;

namespace SCSD.DAL.DataLogic
{
    public class AuthendicationDL
    {
        private SCSDEntities1 _entity = null;
        public AuthendicationDL()
        {
            _entity = new SCSDEntities1();
        }

        public Dictionary<int, string> GetUserType()
        {
            try
            {
                Dictionary<int, string> UserTypes = new Dictionary<int, string>();
                var userTypes = _entity.UserTypes.Where(x => x.Active == true).ToList();
                foreach (var item in userTypes)
                {
                    UserTypes.Add(item.Id, item.Name);
                }
                return UserTypes;
            }
            catch
            {
                throw;
            }
        }

        public Dictionary<int, string> GetUserGroupType()
        {
            try
            {
                Dictionary<int, string> UserGrouptype = new Dictionary<int, string>();
                var userGroupType = _entity.UserGroupTypes.Where(x => x.Active == true).ToList();
                foreach (var item in userGroupType)
                {
                    UserGrouptype.Add(item.Id, item.Name);
                }
                return UserGrouptype;
            }
            catch (Exception e) { throw; }

        }

        public bool CheckUserName(string UserName)
        {
            try
            {
                return _entity.UserAuthentications.Any(x => x.UserName == UserName);
            }
            catch
            {
                throw;
            }
        }

        public bool RegisterUser(Register register)
        {
            bool result = false;
            try
            {
                User user = new User();
                user.Active = true;
                user.Age = Convert.ToInt32(register.Age);
                user.CreatedAt = DateTime.Now.ToString();
                user.DOB = register.DOB;
                user.Gender = register.Gender;
                user.Marital = register.Marital;
                user.Name = register.Name;
                user.UserId = Guid.NewGuid().ToString();

                _entity.Users.Add(user);
                _entity.SaveChanges();

                MappingUserType mappingUserType = new MappingUserType();
                mappingUserType.Active = true;
                mappingUserType.UserId = user.UserId;
                mappingUserType.UserTypeId = Convert.ToInt32(register.UserType);
                _entity.MappingUserTypes.Add(mappingUserType);

                MappingUserGroup mappingUserGroup = new MappingUserGroup();
                mappingUserGroup.Active = true;
                mappingUserGroup.UserId = user.UserId;
                mappingUserGroup.UserGroupId = Convert.ToInt32(register.UserGroupType);
                _entity.MappingUserGroups.Add(mappingUserGroup);

                UserAuthentication userAuthentication = new UserAuthentication();
                userAuthentication.Active = true;
                userAuthentication.Password = register.Password;
                userAuthentication.UserId = user.UserId;
                userAuthentication.UserName = register.UserName;
                _entity.UserAuthentications.Add(userAuthentication);
                _entity.SaveChanges();
                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }

        public string CheckAuthentication(LoginUser login)
        {
            try
            {
                return _entity.UserAuthentications.Where(x => x.UserName == login.UserName && x.Password == login.Password).Select(x => x.UserId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public string GetUserIdByUserName(string UserName)
        {
            try
            {
                return _entity.UserAuthentications.Where(x => x.UserName == UserName).Select(x => x.UserId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public bool ChangePassword(string UserId, string Password)
        {
            try
            {
                var Record = _entity.UserAuthentications.Where(x => x.UserId == UserId).FirstOrDefault();
                if (Record != null)
                {
                    Record.Password = Password;
                }
                _entity.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public UserDTO GetUserIdentity(string userId)
        {
            try
            {
                return (from o in _entity.Users
                        join u in _entity.UserAuthentications
                        on o.UserId equals u.UserId
                        join ut in _entity.MappingUserTypes
                        on o.UserId equals ut.UserId
                        join t in _entity.UserTypes
                        on ut.UserTypeId equals t.Id
                        join gt in _entity.MappingUserGroups
                        on o.UserId equals gt.UserId
                        join g in _entity.UserGroupTypes
                        on gt.UserGroupId equals g.Id
                        where o.UserId == userId
                        select
                        new UserDTO
                        {
                            UserId = o.UserId,
                            Name = o.Name,
                            UserType = t.Name,
                            GroupType = g.Name
                        }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<UserDTO> GetUserIdentitys()
        {
            try
            {
                return (from o in _entity.Users
                        join u in _entity.UserAuthentications
                        on o.UserId equals u.UserId
                        join ut in _entity.MappingUserTypes
                        on o.UserId equals ut.UserId
                        join t in _entity.UserTypes
                        on ut.UserTypeId equals t.Id
                        join gt in _entity.MappingUserGroups
                        on o.UserId equals gt.UserId
                        join g in _entity.UserGroupTypes
                        on gt.UserGroupId equals g.Id
                        select
                        new UserDTO
                        {
                            UserId = o.UserId,
                            Name = o.Name,
                            UserType = t.Name,
                            GroupType = g.Name
                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        public UserDetail GetUserDetail(string userId)
        {
            try
            {
                UserDetail userdetail = new UserDetail();

                var user = (from o in _entity.Users
                            join u in _entity.UserAuthentications
                            on o.UserId equals u.UserId
                            join ut in _entity.MappingUserTypes
                            on o.UserId equals ut.UserId
                            join gt in _entity.MappingUserGroups
                            on o.UserId equals gt.UserId
                            where o.UserId == userId
                            select new { o, u, ut, gt }).FirstOrDefault();
                userdetail.Age = user.o.Age.Value.ToString();
                userdetail.DOB = user.o.DOB.ToString();
                userdetail.Gender = user.o.Gender.ToString();
                userdetail.Marital = user.o.Marital.ToString();
                userdetail.Name = user.o.Name.ToString();
                userdetail.UserGroupType = user.gt.UserGroupId.ToString();
                userdetail.UserId = user.o.UserId.ToString();
                userdetail.UserName = user.u.UserName;
                userdetail.UserType = user.ut.UserTypeId.ToString();
                return userdetail;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateUserDeatil(UserDetail userDetail)
        {
            try
            {
                var user = _entity.Users.Where(x => x.UserId == userDetail.UserId).FirstOrDefault();
                if (user != null)
                {
                    user.Age = Convert.ToInt32(userDetail.Age);
                    user.DOB = userDetail.DOB;
                    user.Gender = userDetail.Gender;
                    user.Marital = userDetail.Marital;
                    user.Name = userDetail.Name;
                }

                var mappingUserType = _entity.MappingUserTypes.Where(x => x.UserId == userDetail.UserId).FirstOrDefault();
                if (mappingUserType != null)
                {
                    mappingUserType.UserTypeId = Convert.ToInt32(userDetail.UserType);
                }

                var mappingUserGroupType = _entity.MappingUserGroups.Where(x => x.UserId == userDetail.UserId).FirstOrDefault();
                if (mappingUserGroupType != null)
                {
                    mappingUserGroupType.UserGroupId = Convert.ToInt32(userDetail.UserGroupType);
                }
                _entity.SaveChanges();

                return "success";
            }
            catch
            {
                throw;
            }
        }

        public Dictionary<string, string> UserList(string searchText, string fileId)
        {
            try
            {
                var users = (from o in _entity.Users
                             where !(from u in _entity.MappingUsers where u.FileId == fileId select u.ChildUser).Contains(o.UserId) && o.UserId != searchText
                             select o).ToList();
                Dictionary<string, string> UserList = new Dictionary<string, string>();
                foreach (var item in users)
                {
                    if (item.UserId != searchText)
                    {
                        UserList.Add(item.UserId, item.Name);
                    }
                }
                return UserList;
            }
            catch
            {
                throw;
            }
        }
    }
}
