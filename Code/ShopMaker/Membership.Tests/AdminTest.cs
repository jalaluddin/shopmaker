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
        public void MatchPassword_NullPassword_ThrowsException()
        {
            string emptyPassword = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.MatchPassword(emptyPassword);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_NullField_ThrowsException()
        {
            string emptyEmail = string.Empty;
            IUserAccount adminAccount = _kernel.Get<IUserAccount>();

            adminAccount.EmailAddress = emptyEmail;
        }
    }
}
