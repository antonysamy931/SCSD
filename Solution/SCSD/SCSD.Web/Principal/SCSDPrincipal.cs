using SCSD.BLL.BussinessLogic;
using SCSD.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SCSD.Web
{
    public class SCSDPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get;
            private set;
        }

        public SCSDPrincipal(string UserId, string authType)
        {
            this.Identity = new SCSDIdentity(UserId, authType);
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public class SCSDIdentity : IIdentity
    {
        AuthendicationBL authenticationBL = new AuthendicationBL();

        public SCSDIdentity(string UserId, string authType)
        {
            UserDTO user = authenticationBL.GetUserIdentityBL(UserId);
            if (user != null)
            {
                this.AuthenticationType = authType;
                this.IsAuthenticated = true;
                this.Name = user.Name;
                this.UserId = user.UserId;
                this.UserGroupType = user.GroupType;
                this.UserType = user.UserType;
            }
            else
            {
                this.IsAuthenticated = false;
            }
        }
        public string AuthenticationType
        {
            get;
            set;
        }

        public bool IsAuthenticated
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string UserType
        {
            get;
            set;
        }

        public string UserGroupType
        {
            get;
            set;
        }
    }
}