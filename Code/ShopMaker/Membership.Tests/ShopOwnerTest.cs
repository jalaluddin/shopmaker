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
    public class ShopOwnerTest : BaseTest
    {
        public ShopOwnerTest()
        {
            _kernel.Bind<IUserAccount>().To<ShopOwner>();
        }

        #region Test For MatchPassword Method

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchPassword_NullPassword_ThrowsException()
        {
            // prepare
            string invalidPassword = null;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.MatchPassword(invalidPassword);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchPassword_EmptyPassword_ThrowsException()
        {
            // prepare
            string invalidPassword = string.Empty;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.MatchPassword(invalidPassword);
        }

        [TestMethod]
        public void MatchPassword_WrongPassword_ResultFalse()
        {
            // prepare
            string PlainPassword = "133578";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.Password = "123456";
            // act
            bool isCorrect = shopOwnerAccount.MatchPassword(PlainPassword);

            // assert
            Assert.Equals(false, isCorrect);
        }

        [TestMethod]
        public void MatchPassword_CorrectPassword_ResultTrue()
        {
            // prepare
            string PlainPassword = "133578";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.Password = "133578";
            // act
            bool isCorrect = shopOwnerAccount.MatchPassword(PlainPassword);

            // assert
            Assert.Equals(true, isCorrect);
        } 

        #endregion

        #region Test For EmailAddress Property

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_NullEmail_ThrowsException()
        {
            // preapre
            string nullEmail = null;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.EmailAddress = nullEmail;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_EmptyEmail_ThrowsException()
        {
            // prepare
            string emptyEmail = string.Empty;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.EmailAddress = emptyEmail;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailAddress_AtTheRateMissingInEmailFormat_ThrowsException()
        {
            // prepare
            string invlaidEmail = "test.com";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.EmailAddress = invlaidEmail;           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailAddress_DomainExtensionMissingInEmailFormat_ThrowsException()
        {
            // prepare
            string invlaidEmail = "test@test";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.EmailAddress = invlaidEmail;
        }

        #endregion

        #region TestForPasswordProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_NullPassword_ThrowsException()
        {
            string nullPassword = null;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.Password = nullPassword;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_EmptyPassword_ThrowsException()
        {
            string emptyPassword = string.Empty;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.Password = emptyPassword;
        }

        #endregion

        #region TestForFirstNameProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_EmptyString_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void FirstName_TooLongName_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        
        #endregion

        #region TestForLastNameProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_EmptyString_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_TooLongName_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        
        #endregion

        #region TestForLastLoginDateTimeProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastLoginDateTime_SetNullDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastLoginDateTime_SetEpmtyDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        } 
        #endregion

        #region TestForMobileNumberProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MobileNumber_NullImput_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void MobileNumber_InputNumber_ValidationResult()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
        #endregion    

        #region TestForWrongPasswordAttemptProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WrongPasswordAttempt_SetNullValue_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
       
        #endregion

        #region TestForLastWrongPasswordAttemptDateTimeProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastWrongPasswordAttemptDateTime_SetNullDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        #endregion

        #region TestForIPAddressProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IPAddress_NullImput_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void IPAddress_InputNumber_ValidationResult()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
        #endregion

        #region TestForAccountCreationDateTimeProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AccountCreationDateTime_SetNullDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AccountCreationDateTime_SetEpmtyDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
        #endregion

        #region TestForAccountStatusProperty

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AccountStatus_SetNullDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AccountStatus_SetEpmtyDateTime_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
        #endregion

        #region TestForIDProperty

        // I think no unit test is needed for this;

        #endregion

        #region Test_For_IAddress_Interface

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IAddress_SetNullValue_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        #endregion

        #region Test_For_IMembershipPackage_Interface

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IMembershipPackage_SetNullValue_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        #endregion    
    
    }
}
