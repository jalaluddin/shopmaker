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
            Assert.AreEqual("email@email.com", authenticationToken.EmailAddress,"email is required");
            
        }

        public void EmailAddress_IsEmailAddressAlreadyUsed_ThrowsException()
        {
            //prepare
            string usedEmail = "email@email.com";

            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.EmailAddress=usedEmail;
            Assert.AreEqual("email@email.com", authenticationToken.EmailAddress, "email is already used");
        }

        public void FirstName_EmptyFirstName_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.FirstName = String.Empty;
            Assert.AreEqual("fname", authenticationToken.FirstName, "First name is required");
        }

        public void LastName_EmptyLastName_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.LastName = String.Empty;
            Assert.AreEqual("Lname", authenticationToken.LastName, "Last name is required");
           
        }

        //not completed
        public void UserType_EmptyUserType_ThrowsException()
        {
            // prepare
            var authenticationToken = _kernel.Get<IAuthenticationToken>();

            // act
            authenticationToken.UserType = UserTypeOptions.Admin;
        }

        
    }
}
