using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using SFASystem.Domain;
using System.Security.Cryptography;
using SFASystem.Services;

namespace SFASystem.WebUtils.Security
{
    public class SFAMembershipProvider : MembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser user = null;
            Employee employee = new Employee();
            employee.Login = username;
            employee.PasswordSalt = CreateSalt(5);
            employee.PasswordHash = CreatePasswordHash(password, employee.PasswordSalt);
            employee.Active = true;
            employee.CreationDate = DateTime.Now;
            employee.LastActivityDate = DateTime.Now;
            EmployeeService.SaveEmployee(employee);
            status = MembershipCreateStatus.Success;
            user = new MembershipUser(this.Name, employee.Login, null, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            return user;
        }
        #region ...
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Employee employee = EmployeeService.GetEmployeeByLogin(username);
            if (employee != null)
            {
                string oldPassHash = CreatePasswordHash(oldPassword, employee.PasswordSalt);
                if (!oldPassHash.Equals(employee.PasswordHash))
                    throw new Exception("Podane hasło jest nieprawidłowe");
                string newPassSalt = CreateSalt(5);
                string newPassHash = CreatePasswordHash(newPassword, newPassSalt);

                employee.PasswordSalt = newPassSalt;
                employee.PasswordHash = newPassHash;
                EmployeeService.SaveEmployee(employee);
                return true;
                //employeeRepository.Update(employee);
            }
            else
                return false;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
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

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            Employee emp = EmployeeService.GetEmployeeByLogin(username);
            if (emp == null)
                return null;
            return new MembershipUser(this.Name, emp.Login, null, string.Empty, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
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

        #endregion

        public override bool ValidateUser(string username, string password)
        {
            Employee employee = EmployeeService.GetEmployeeByLogin(username);

            if (employee == null)
                return false;
            if (!employee.Active)
                return false;

            string passwordHash = CreatePasswordHash(password, employee.PasswordSalt);
            bool result = employee.PasswordHash.Equals(passwordHash);
            if (result)
            {
                return true;
            }
            return false;
        }

        #region Helper Methods

        private static string CreatePasswordHash(string Password, string Salt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Password + Salt, "SHA1");
        }

        private static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            provider.GetBytes(data);
            return Convert.ToBase64String(data);
        }


        #endregion
    }
}
