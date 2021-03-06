﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FormsAuthenticationMvc_Demo.Models
{
    public class CustomMembership : MembershipProvider
    {
        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            //ValidatePasswordEventArgs args =
            //           new ValidatePasswordEventArgs(username, password, true);
            //OnValidatingPassword(args);

            //if (args.Cancel)
            //{
            //    status = MembershipCreateStatus.InvalidPassword;
            //    return null;
            //}

            MembershipUser user = GetUser(username, true);

            //if (user == null)
            //{
            //    using (EmployeeContext context = new EmployeeContext())
            //    {
            //        var user = 
            //    }
            //        UserObj userObj = new UserObj();
            //    userObj.UserName = username;
            //    userObj.Password = GetMD5Hash(password);
            //    userObj.UserEmailAddress = email;

            //    User userRep = new User();
            //    userRep.RegisterUser(userObj);

            //    status = MembershipCreateStatus.Success;

            //    return GetUser(username, true);
            //}
            //else
            //{
            //    status = MembershipCreateStatus.DuplicateUserName;
            //}

            if (user == null)
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    User newUser = new User();
                    newUser.UserName = username;
                    newUser.UserPassword = HashPassword(password, "MD5");
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    status = MembershipCreateStatus.Success;
                }

                return GetUser(username, true);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;

                return null;
            };
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var user = (from us in db.Users
                            where string.Compare(username, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                            select us).SingleOrDefault();

                if (user == null)
                {
                    return null;
                }
                var selectedUser = new CustomMembershipUser(user);

                return selectedUser;
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            using (EmployeeContext db = new EmployeeContext())
            {
                var user = (from us in db.Users
                            where string.Compare(username, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                            && string.Compare(password, us.UserPassword, StringComparison.OrdinalIgnoreCase) == 0
                            select us).FirstOrDefault();

                return (user != null) ? true : false;
            }
        }

        public static string HashPassword(string password, string formst)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower();
        }
    }
}