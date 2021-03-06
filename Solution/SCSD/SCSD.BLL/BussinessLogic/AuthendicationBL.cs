﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCSD.DAL.DataLogic;
using SCSD.DTO.Model;

namespace SCSD.BLL.BussinessLogic
{
    public class AuthendicationBL
    {
        private AuthendicationDL _authendicationDL = null;
        public AuthendicationBL()
        {
            _authendicationDL = new AuthendicationDL();
        }

        public Dictionary<int, string> GetUserTypeBL()
        {
            try
            {
                return _authendicationDL.GetUserType();
            }
            catch
            {
                throw;
            }
        }

        public Dictionary<int, string> GetUserTypeGroupBL()
        {
            try
            {
                return _authendicationDL.GetUserGroupType();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUserNameBL(string UserName)
        {
            try
            {
                return _authendicationDL.CheckUserName(UserName);
            }
            catch
            {
                throw;
            }
        }

        public bool RegisterUserBL(Register register)
        {
            try
            {
                return _authendicationDL.RegisterUser(register);
            }
            catch
            {
                throw;
            }
        }

        public string CheckAuthenticationBL(LoginUser login)
        {
            try
            {
                return _authendicationDL.CheckAuthentication(login);
            }
            catch
            {
                throw;
            }
        }

        public string GetUserIdByUserNameBL(string UserName)
        {
            try
            {
                return _authendicationDL.GetUserIdByUserName(UserName);
            }
            catch
            {
                throw;
            }
        }
        public bool ChangePasswordBL(string UserId, string Password)
        {
            try
            {
                return _authendicationDL.ChangePassword(UserId, Password);
            }
            catch
            {
                throw;
            }
        }

        public UserDTO GetUserIdentityBL(string UserId)
        {
            try
            {
                return _authendicationDL.GetUserIdentity(UserId);
            }
            catch
            {
                throw;
            }
        }

        public UserDetail GetUserDetailBL(string userId)
        {
            try
            {
                return _authendicationDL.GetUserDetail(userId);
            }
            catch
            {
                throw;
            }
        }

        public string UpdateUserDeatilBL(UserDetail userDetail)
        {
            try
            {
                return _authendicationDL.UpdateUserDeatil(userDetail);
            }
            catch
            {
                throw;
            }
        }

        public Dictionary<string, string> UserListBL(string searchText, string fileId)
        {
            try
            {
                return _authendicationDL.UserList(searchText, fileId);
            }
            catch
            {
                throw;
            }
        }

        public List<UserDTO> GetUserIdentitysBL()
        {
            try
            {
                return _authendicationDL.GetUserIdentitys();
            }
            catch
            {
                throw;
            }
        }
    }
}
