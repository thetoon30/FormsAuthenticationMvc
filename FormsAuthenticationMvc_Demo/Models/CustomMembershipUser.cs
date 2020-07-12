using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FormsAuthenticationMvc_Demo.Models
{
    public class CustomMembershipUser : MembershipUser
    {
        #region User Properties  
        public int UserId { get; set; }
        #endregion

        public CustomMembershipUser(User user) : base("CustomMembership", user.UserName, user.Id, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.Id;
        }
    }
}