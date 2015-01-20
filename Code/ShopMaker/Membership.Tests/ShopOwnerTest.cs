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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchPassword_NullPassword_ThrowsException()
        {
            // prepare
            string invalidPassword = string.Empty;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();

            // act
            shopOwnerAccount.MatchPassword(invalidPassword);
        }

        public void MatchPassword_PlainPassword_ValidationResult()
        {
            // prepare
            string PlainPassword = " ";
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            bool IsValid = shopOwnerAccount.MatchPassword(PlainPassword);
            Assert.Equals(true, IsValid);
            // act
            
        }

        public void ChangeMembershipPlan_NewPlan_CurrentPlanAsNewPlan()
        {
            // prepare

            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            

            // act
        }

        public void EmailAddress_NullEmail_ThrowsException()
        {
            string invalidEmail = null;
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
            shopOwnerAccount.EmailAddress = invalidEmail;
        }

        public void EmailAddress_InvalidFormatEmail_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void EmailAddress_EmailAlreadyExist_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void Password_NullPassword_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void Password_TooShortPassword_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
        public void Password_TooLongPassword_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void FirstName_EmptyString_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void FirstName_TooLongName_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void LastName_EmptyString_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void LastName_TooLongName_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void MobileNumber_NullImput_ThrowsException()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }

        public void MobileNumber_InputNumber_ValidationResult()
        {
            IUserAccount shopOwnerAccount = _kernel.Get<IUserAccount>();
        }
    }
}
