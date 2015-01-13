using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using ShopMaker.Web;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using ShopMaker.DAL;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class UserAuthenticationServiceTest : BaseTest
    {
        public UserAuthenticationServiceTest()
        {
            _kernel.Bind<IAuthenticator>().To<UserAuthenticationService>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AuthenticateAdmin_EmptyEmailAddress_ThrowsException()
        {
            // prepare
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();
            string emptyEmail = string.Empty;
            string validPassword = "123456";

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(emptyEmail, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AuthenticateAdmin_EmptyPassword_ThrowsException()
        {
            // prepare
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();
            string validEmail = "abc@zyz.com";
            string emptyPassword = string.Empty;

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(validEmail, emptyPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AuthenticateAdmin_NullEmailAddress_ThrowsException()
        {
            // prepare
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();
            string nullEmail = null;
            string validPassword = "123456";

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(nullEmail, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AuthenticateAdmin_NullPassword_ThrowsException()
        {
            // prepare
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();
            string validEmail = "abc@zyz.com";
            string nullPassword = string.Empty;

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(validEmail, nullPassword);
        }

        [TestMethod]
        public void AuthenticateAdmin_ValidEmailAddressAndPassword_ReturnsValidAuthenticationToken()
        {
            // prepare
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();
            string validEmail = "abc@zyz.com";
            string validPassword = "123456";

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(validEmail, validPassword);

            // assert
            Assert.IsNotNull(token);
            Assert.AreEqual(validEmail, token.EmailAddress);
        }

        [TestMethod]
        public void AuthenticateAdmin_AdminFoundInRepository_ReturnsCorrectAuthenticationToken()
        {
            // prepare
            string validEmail = "abc@zyz.com";
            string validPassword = "123456";
            string validFirstName = "Jalal";
            string validLastName = "Uddin";

            var adminRepositoryMock = _kernel.GetMock<IMembershipRepository>();
            adminRepositoryMock.Setup(x => x.Get(validEmail)).Returns(new Admin() 
            { 
                EmailAddress = validEmail, 
                FirstName = validFirstName, 
                LastName = validLastName
            });

            var repositoryFactoryMock = _kernel.GetMock<IMembershipRepositoryFactory>();
            repositoryFactoryMock.Setup(x => x.CreateMembershipRepository(UserTypeOptions.Admin)).Returns(adminRepositoryMock.Object);
            IAuthenticator authenticator = _kernel.Get<IAuthenticator>();

            // act
            IAuthenticationToken token = authenticator.AuthenticateAdmin(validEmail, validPassword);

            // assert
            Assert.IsNotNull(token);
            Assert.AreEqual(validEmail, token.EmailAddress);
            Assert.AreEqual(validFirstName, token.FirstName);
            Assert.AreEqual(validLastName, token.LastName);
            Assert.AreEqual(UserTypeOptions.Admin, token.UserType);
        }
    }
}
