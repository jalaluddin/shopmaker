using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Moq;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;

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
            string emptyPassword = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MatchPassword(emptyPassword);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_EmptyField_ThrowsException()
        {
            string emptyEmail = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.EmailAddress = emptyEmail;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AccountStatus_ReturnCurrentStatus()
        {
            string Act = "active";
		    string Bloc = "Blocked";
		    string Exp = "Expired";
		    string Unver = "Unverified";

          //prepare
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();
            
            //act
            AccountStatusOptions token = adminAccount.AccountStatus;

           //assert
            Assert.AreEqual(Act,token);
            Assert.AreEqual(Bloc, token);
            Assert.AreEqual(Exp, token);
            Assert.AreEqual(Unver, token);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_NullField_ThrowsException()
        {
            string nullPassword = null;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.Password = nullPassword;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_EmptyField_ThrowsException()
        {
            string emptyPassword = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.Password = emptyPassword;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_ValidPassword()
        {
            string validPassword = "12345";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.Password = validPassword;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_inValidPassword()
        {
            
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_EmptyField_ThrowsException()
        {
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.FirstName = emptyField;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_ValidField()
        {
            string validField = "Anik";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.FirstName = validField;
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_EmptyField_ThrowsException()
        {
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.LastName = emptyField;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_ValidField()
        {
            string validField = "Islam";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.LastName = validField;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MobileNumber_EmptyField_ThrowsException()
        {
            string emptyField = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MobileNumber = emptyField;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MobileNumber_ValidField()
        {
            string validField = "01711111111";
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MobileNumber = validField;
        }

    }
}
