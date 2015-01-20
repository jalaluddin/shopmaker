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
    public class ShopOwnerTest : BaseTest
    {
        public ShopOwnerTest()
        {
            _kernel.Bind<IUserAccount>().To<ShopOwner>();
        }



        #region Test_For_MatchPassword_Method
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
        public void MatchPassword_PlainPassword_ValidationResult()
        {
            // prepare
            string PlainPassword = " ";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            bool IsValid = shopOwnerAccount.MatchPassword(PlainPassword);
            Assert.Equals(true, IsValid);
            // act

        } 
        #endregion

        #region Test_For_ChangeMembershipPlan_Method
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeMembershipPlan_NullNewPlan_ThrowsException()
        {
            // prepare

            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();


            // act
        }

        public void ChangeMembershipPlan_NewPlan_CurrentPlanAsNewPlan()
        {
            // prepare

            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();


            // act
        } 
        #endregion
        
        #region TestForEmailAddressProperty
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_NullEmail_ThrowsException()
        {
            string nullEmail = null;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.EmailAddress = nullEmail;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_EmptyEmail_ThrowsException()
        {
            string emptyEmail = string.Empty;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.EmailAddress = emptyEmail;
        }

        public void EmailAddress_InvalidFormatEmail_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void EmailAddress_EmailAlreadyExist_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_TooShortPassword_ThrowsException()
        {

            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            int PasswordLeghth = shopOwnerAccount.Password.Length;
            if (PasswordLeghth < 6)
                Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Password_TooLongPassword_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            int PasswordLeghth = shopOwnerAccount.Password.Length;
            if (PasswordLeghth > 20)
                Assert.Fail();
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ID_SetNullValue_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

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
