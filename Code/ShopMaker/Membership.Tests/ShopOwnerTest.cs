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
    }
}
