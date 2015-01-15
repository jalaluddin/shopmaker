using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using ShopMaker.DAL;
using Moq;
using System.Data.Common;

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
            ShopOwner shopOwner = new ShopOwner();
            shopOwner.ID = IdentityGenerator.NewSequentialGuid();
            shopOwner.AccountCreationDateTime = DateTime.Now;
            shopOwner.AccountStatus = AccountStatusOptions.Active;
            shopOwner.BillingAddress = new Address() { AddressLine1 = "Billing address line 1", 
                City = "Dhaka", Country = "Bangladesh", ID = IdentityGenerator.NewSequentialGuid(), Zipcode = "1213" };
            shopOwner.EmailAddress = "email@yahoo.com";
            shopOwner.FirstName = "Jalal";
            shopOwner.LastName = "Uddin";
            shopOwner.LastWrongPasswordAttemptDateTime = DateTime.Now.AddDays(-2);
            shopOwner.MembershipPlan = null;
            shopOwner.MobileNumber = "8801737364773";
            shopOwner.Password = "testpass123";
            shopOwner.WrongPasswordAttempt = 0;

            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure 
                    && y.CommandText == "ShopOwnerAccount_Add" 
                    && y.Parameters.Count > 0))).Verifiable();

            // act
            membershipRepository.Add(shopOwner);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        }
    }
}
