using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using ShopMaker.DAL;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using ShopMaker.DAL;
using Moq;
using System.Data.Common;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class AdminRepositoryTest : BaseTest
    {
        [TestMethod]
        public void Add_AdminInstance_CallsStoredProcedureExecutionForAdminAccountAdd()
        {
            // prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();
            Admin admin = new Admin();
            admin.ID = IdentityGenerator.NewSequentialGuid();
            admin.AccountCreationDateTime = DateTime.Now;
            admin.AccountStatus = AccountStatusOptions.Active;
            admin.EmailAddress = "email@yahoo.com";
            admin.FirstName = "Jalal";
            admin.LastName = "Uddin";
            admin.LastWrongPasswordAttemptDateTime = DateTime.Now.AddDays(-2);
            admin.MobileNumber = "8801737364773";
            admin.Password = "testpass123";
            admin.WrongPasswordAttempt = 0;

            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure
                    && y.CommandText == "AdminAccount_Add"
                    && y.Parameters.Count > 0))).Verifiable();

            // act
            membershipRepository.Add(admin);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        }
    }
}
