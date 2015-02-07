using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Moq;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using ShopMaker.Web;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class ShopOwnerRegistrationServiceTest : BaseTest
    {
        public ShopOwnerRegistrationServiceTest()
        {
            _kernel.Bind<IShopOwnerRegistrationService>().To<ShopOwnerRegistrationService>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Signup_EmptyEmailAddress_ThrowsException()
        {
            // prepare
            string invalidEmail = string.Empty;
            string validPassword = "jalal1234";
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(invalidEmail, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Signup_NullEmailAddress_ThrowsException()
        {
            // prepare
            string invalidEmail = null;
            string validPassword = "jalal1234";
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(invalidEmail, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Signup_InvalidEmailAddress_ThrowsException()
        {
            // prepare
            string invalidEmail = "email@hello";
            string validPassword = "jalal1234";
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(invalidEmail, validPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Signup_ShortPassword_ThrowsException()
        {
            // prepare
            string validEmail = "email@hello.com";
            string invalidPassword = "a$kDq";
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(validEmail, invalidPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Signup_EmptyPassword_ThrowsException()
        {
            // prepare
            string validEmail = "email@hello.com";
            string invalidPassword = string.Empty;
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(validEmail, invalidPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Signup_NullPassword_ThrowsException()
        {
            // prepare
            string validEmail = "email@hello.com";
            string invalidPassword = null;
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(validEmail, invalidPassword);
        }

        [TestMethod]
        public void Signup_ValidEmailAndPassword_CallsRepositoryAddMethod()
        {
            // prepare
            string validEmail = "email@hello.com";
            string validPassword = "a$kDqX2";

            var repositoryMock = _kernel.GetMock<IMembershipRepository>();
            repositoryMock.Setup(x => x.Add(It.Is<ShopOwner>(y => y.EmailAddress == validEmail
                && !String.IsNullOrWhiteSpace(y.EncryptedPassword)))).Verifiable();

            _kernel.GetMock<IMembershipRepositoryFactory>().Setup(x => x.CreateMembershipRepository(UserTypeOptions.ShopOwner))
                .Returns(repositoryMock.Object);
            
            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.Signup(validEmail, validPassword);

            // assert
            repositoryMock.VerifyAll();
        }



        // new unit test for method verify sigup Email Address 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // wrong exception type used
        public void VerifySignupEmailAddress_EmptyVerificationCode_ThrowsException()
        {
            //prepare 
            string validEmail = "email@hello.com";
            string invalidVerificationCode = string.Empty;

            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.VerifySignupEmailAddress(validEmail, invalidVerificationCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))] // wrong exception type used
        public void VerifySignupEmailAddress_NullVerificationCode_ThrowsException() // name having ending underscore, why
        {
            //prepare 
            string validEmail = "email@hello.com";
            string invalidVerificationCode = null;

            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.VerifySignupEmailAddress(validEmail, invalidVerificationCode);
        }


        [TestMethod]
        public void VerifySignupEmailAddress_ValidVerificationCode() // name format violation
        {
            //prepare 
            string validEmail = "email@hello.com";
            string validVerificationCode = "123";

            var repositoryMock = _kernel.GetMock<IMembershipRepository>();

            _kernel.GetMock<IMembershipRepositoryFactory>().Setup(x => x.CreateMembershipRepository(UserTypeOptions.ShopOwner))
                .Returns(repositoryMock.Object);

            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();


            // act
            shopOwnerRegistrationService.VerifySignupEmailAddress(validEmail, validVerificationCode);

            // assert
            repositoryMock.VerifyAll();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsEmailAddressAlreadyUsed_ThrowsException() // why the name is voilating convension
        {
            //prepare
            string usedEmail = "email@hello.com";

            IShopOwnerRegistrationService shopOwnerRegistrationService = _kernel.Get<IShopOwnerRegistrationService>();

            // act
            shopOwnerRegistrationService.IsEmailAddressAlreadyUsed(usedEmail); // no mocking is used, you need to check in database to confirm email already used or not
        }
    }
}
