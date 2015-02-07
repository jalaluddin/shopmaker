using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using ShopMaker.DAL;
using Moq;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class ShopOwnerRepositoryTest : BaseTest
    {
        public ShopOwnerRepositoryTest()
        {
            _kernel.Bind<IMembershipRepository>().To<ShopOwnerRepository>();
        }

        [TestMethod]
        public void Add_ShopOwnerInstance_CallsStoredProcedureExecutionForShopOwnerAccountAdd()
        {
            // prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();

            var addressMock = _kernel.GetMock<IAddress>();
            addressMock.SetupProperty(x => x.AddressLine1, "Billing address line 1");
            addressMock.SetupProperty(x => x.City, "Dhaka");
            addressMock.SetupProperty(x => x.Country, "Bangladesh");
            addressMock.SetupProperty(x => x.ID, IdentityGenerator.NewSequentialGuid());
            addressMock.SetupProperty(x => x.Zipcode, "1213");

            var membershipMock = _kernel.GetMock<IMembershipPackage>();
            membershipMock.SetupProperty(x => x.Description, "Free membership for startups");
            membershipMock.SetupProperty(x => x.ID, IdentityGenerator.NewSequentialGuid());
            membershipMock.SetupProperty(x => x.MaxCategoryAllowed, 20);
            membershipMock.SetupProperty(x => x.MaxProductAllowed, 100);
            membershipMock.SetupProperty(x => x.MaxShopAllowed, 1);
            membershipMock.SetupProperty(x => x.Name, "Free");
            membershipMock.SetupProperty(x => x.Price, 0);
            membershipMock.SetupProperty(x => x.PriceDisplayText, "FREE!");

            var shopOwnerMock = _kernel.GetMock<IShopOwner>();
            shopOwnerMock.SetupProperty(x => x.ID, IdentityGenerator.NewSequentialGuid());
            shopOwnerMock.SetupProperty(x => x.AccountCreationDateTime, DateTime.Now);
            shopOwnerMock.SetupProperty(x => x.AccountStatus, AccountStatusOptions.Active);
            shopOwnerMock.SetupProperty(x => x.BillingAddress, addressMock.Object);
            shopOwnerMock.SetupProperty(x => x.EmailAddress, "email@yahoo.com");
            shopOwnerMock.SetupProperty(x => x.FirstName, "Jalal");
            shopOwnerMock.SetupProperty(x => x.LastName, "Uddin");
            shopOwnerMock.SetupProperty(x => x.LastWrongPasswordAttemptDateTime, DateTime.Now.AddDays(-2));
            shopOwnerMock.SetupProperty(x => x.MembershipPlan, membershipMock.Object);
            shopOwnerMock.SetupProperty(x => x.MobileNumber, "8801737364773");
            shopOwnerMock.SetupProperty(x => x.EncryptedPassword, "testpass123");
            shopOwnerMock.SetupProperty(x => x.WrongPasswordAttempt, 0);

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateParameter(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(new SqlParameter("parameter", "parameter value"));

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand("ShopOwnerAccount_Add", It.IsAny<object[]>()))
                .Returns(new SqlCommand("ShopOwnerAccount_Add") {  CommandType = System.Data.CommandType.StoredProcedure });

            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure 
                    && y.CommandText == "ShopOwnerAccount_Add"))).Verifiable();

            // act
            membershipRepository.Add(shopOwnerMock.Object);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_NullEmail_ThrowsException()
        {
            // preapre
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();
            string nullEmail = null;

            // act
            membershipRepository.Remove(nullEmail);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_EmptyEmail_ThrowsException()
        {
            // preapre
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();
            string emptyEmail = string.Empty;

            // act
            membershipRepository.Remove(emptyEmail);
        }

        [TestMethod]
        public void Remove_ValidEmail_CallsDbCommandExecutionServiceWithProperEmailArgument()
        {
            // preapre
            string commandText = "ShopOwnerAccount_Remove";

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand(commandText,
                It.IsAny<Object[]>())).Returns(new SqlCommand(commandText, null));

            _kernel.GetMock<IDbCommandExecutionService>()
                .Setup(x => x.ExecuteCommand(It.Is<DbCommand>(y => y.CommandText == commandText))).Verifiable();

            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();
            string validEmail = "info@devskill.com";

            // act
            membershipRepository.Remove(validEmail);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Edit_NullUserAccount_ThrowsException()
        {
            // preapre
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();
            IUserAccount userAccount = null;

            // act
            membershipRepository.Edit(userAccount);
        }
    }
}