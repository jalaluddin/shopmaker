using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using ShopMaker.Web;
using Moq;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class AuthenticationTokenTest : BaseTest
    {
        public AuthenticationTokenTest()
        {
            _kernel.Bind<IAuthenticationToken>().To<AuthenticationToken>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailAddress_EmptyEmailAddress_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.EmailAddress = String.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstName_EmptyFirstName_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.FirstName = String.Empty;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastName_EmptyLastName_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.LastName = String.Empty;
        }
    }
}
