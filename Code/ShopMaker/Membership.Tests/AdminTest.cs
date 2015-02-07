using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Moq;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using System.Text.RegularExpressions;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class AdminTest : BaseTest
    {
        public AdminTest()
        {
            _kernel.Bind<IUserAccount>().To<Admin>();   
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchPassword_EmptyPassword_ThrowsException()
        {
            // prepare
            string emptyPassword = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.MatchPassword(emptyPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchPassword_NullPassword_ThrowsException()
        {
            // prepare
            string emptyPassword = null;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.MatchPassword(emptyPassword);
        }
        
        [TestMethod]
        public void EmailAddress_GetEmailAddress_ReturnsEmailAddress()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            string email = adminAccount.EmailAddress;
        }

        [TestMethod]
        public void FirstName_GetFirstName_ReturnsFirstName()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            string firstName = adminAccount.FirstName;
        }

        [TestMethod]
        public void LastName_GetFirstName_ReturnsLastName()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            string lastName = adminAccount.LastName;
        }

        [TestMethod]
        public void LastLoginDateTime_GetLastLoginDateTime_ReturnsLastLoginDateTime()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            DateTime lastLoginDateTime = adminAccount.LastLoginDateTime;
        }

        [TestMethod]
        public void MobileNumber_GetMobileNumber_ReturnsMobileNumber()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            string mobileNumber = adminAccount.MobileNumber;
        }

        [TestMethod]
        public void WrongPasswordAttempt_GetWrongPasswordAttempt_ReturnsWrongPasswordAttempt()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            int wrongPasswordAttempt = adminAccount.WrongPasswordAttempt;
        }

        [TestMethod]
        public void LastWrongPasswordAttemptDateTime_GetLastWrongPasswordAttemptDateTime_ReturnsLastWrongPasswordAttemptDateTime()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            DateTime lastWrongPasswordAttemptDateTime = adminAccount.LastWrongPasswordAttemptDateTime;
        }

        [TestMethod]
        public void IPAddress_GetIPAddress_ReturnsIPAddress()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            string ipAddress = adminAccount.IPAddress;
        }

        [TestMethod]
        public void AccountCreationDateTime_GetAccountCreationDateTime_ReturnsAccountCreationDateTime()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            DateTime accountCreationDateTime = adminAccount.AccountCreationDateTime;
        }

        [TestMethod]
        public void AccountStatus_GetAccountStatus_ReturnsAccountStatus()
        {
            // prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            AccountStatusOptions accountStatus = adminAccount.AccountStatus;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_SetNullPassword_ThrowsException()
        {
            // prepare
            string nullPassword = null;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.Password = nullPassword;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_SetEmptyPassword_ThrowsException()
        {
            // prepare
            string emptyPassword = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.Password = emptyPassword;
        }

        [TestMethod]
        public void Password_SetValidPassword_SetsPassword()
        {
            // prepare
            string validPassword = "A73@kr1";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.Password = validPassword;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Password_SetInvalidPassword_ThrowsException()
        {
            // prepare
            string invalidPassword = "1";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.Password = invalidPassword;
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_SetEmptyFirstName_ThrowsException()
        {
            // prepare
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.FirstName = emptyField;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_SetNullFirstName_ThrowsException()
        {
            // prepare
            string nullField = null;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.FirstName = nullField;
        }
        
        [TestMethod]
        public void FirstName_SetValidFirstName_SetsFirstName()
        {
            // prepare
            string validField = "Anik";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            // act
            adminAccount.FirstName = validField;
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_SetEmptyLastName_ThrowsException()
        {
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.LastName = emptyField;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_SetNullLastName_ThrowsException()
        {
            string nullField = null;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.LastName = nullField;
        }

        [TestMethod]
        public void LastName_SetValidLastName_SetsLastName()
        {
            string validField = "Islam";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.LastName = validField;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MobileNumber_SetEmptyMobileNumber_ThrowsException()
        {
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MobileNumber = emptyField;
        }

        [TestMethod]
        public void MobileNumber_SetValidMobileNumber_SetsMobileNumber()
        {
            string validField = "01711111111";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MobileNumber = validField;
        }
    }
}
