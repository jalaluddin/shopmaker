using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using ShopMaker.DAL;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Moq;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class AdminRepositoryTest : BaseTest
    {
        public AdminRepositoryTest()
        {
            _kernel.Bind<IMembershipRepository>().To<AdminRepository>();
        }

        [TestMethod]
        public void Add_AdminInstance_CallsStoredProcedureExecutionForAdminAccountAdd()
        {

            // prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();

            var adminMock = _kernel.GetMock<IUserAccount>();
            adminMock.SetupProperty(x => x.ID, IdentityGenerator.NewSequentialGuid());
            adminMock.SetupProperty(x => x.AccountCreationDateTime, DateTime.Now);
            adminMock.SetupProperty(x => x.AccountStatus, AccountStatusOptions.Active);            
            adminMock.SetupProperty(x => x.EmailAddress, "email@yahoo.com");
            adminMock.SetupProperty(x => x.FirstName, "Jalal");
            adminMock.SetupProperty(x => x.LastName, "Uddin");
            adminMock.SetupProperty(x => x.LastWrongPasswordAttemptDateTime, DateTime.Now.AddDays(-2));            
            adminMock.SetupProperty(x => x.MobileNumber, "8801737364773");
            adminMock.SetupProperty(x => x.EncryptedPassword, "testpass123");
            adminMock.SetupProperty(x => x.WrongPasswordAttempt, 0);


            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateParameter(It.IsAny<string>(), It.IsAny<object>()))
               .Returns(new SqlParameter("parameter", "parameter value"));

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand("AdminAccount_Add", It.IsAny<object[]>()))
                .Returns(new SqlCommand("AdminAccount_Add") { CommandType = System.Data.CommandType.StoredProcedure });



            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure
                    && y.CommandText == "AdminAccount_Add"))).Verifiable();
            
            
            // act
            membershipRepository.Add(adminMock.Object);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();


        }


        [TestMethod]
        public void Remove_AdminInstance_CallsStoredProcedureExecutionForAdminAccountRemove(){
            
            //prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateParameter(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(new SqlParameter("parameter", "parameter value"));

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand("AdminAccount_Remove", It.IsAny<object[]>()))
               .Returns(new SqlCommand("AdminAccount_Remove") { CommandType = System.Data.CommandType.StoredProcedure });

            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure
                    && y.CommandText == "AdminAccount_Remove"))).Verifiable();
            
            // act
            membershipRepository.Remove("email@yahoo.com");

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        }


        [TestMethod]
        public void Edit_AdminInstance_CallsStoredProcedureExecutionForAdminAccountEdit() {

            //prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();

            var adminMock2 = _kernel.GetMock<IUserAccount>();
            adminMock2.SetupProperty(x => x.ID, IdentityGenerator.NewSequentialGuid());
            adminMock2.SetupProperty(x => x.AccountCreationDateTime, DateTime.Now);
            adminMock2.SetupProperty(x => x.AccountStatus, AccountStatusOptions.Active);
            adminMock2.SetupProperty(x => x.EmailAddress, "email@yahoo.com");
            adminMock2.SetupProperty(x => x.FirstName, "Jalal");
            adminMock2.SetupProperty(x => x.LastName, "Uddin");
            adminMock2.SetupProperty(x => x.LastWrongPasswordAttemptDateTime, DateTime.Now.AddDays(-2));
            adminMock2.SetupProperty(x => x.MobileNumber, "8801737364773");
            adminMock2.SetupProperty(x => x.EncryptedPassword, "testpass123");
            adminMock2.SetupProperty(x => x.WrongPasswordAttempt, 0);


            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateParameter(It.IsAny<string>(), It.IsAny<object>()))
               .Returns(new SqlParameter("parameter", "parameter value"));

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand("AdminAccount_Edit", It.IsAny<object[]>()))
                .Returns(new SqlCommand("AdminAccount_Edit") { CommandType = System.Data.CommandType.StoredProcedure });



            _kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteCommand(
                It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure
                    && y.CommandText == "AdminAccount_Edit"))).Verifiable();


            // act
            membershipRepository.Edit(adminMock2.Object);

            // assert
            _kernel.GetMock<IDbCommandExecutionService>().VerifyAll();
        
        }

        [TestMethod]
        public void Get_AdminInstance_CallsStoredProcedureExecutionForAdminAccountGet()
        {
            //prepare
            IMembershipRepository membershipRepository = _kernel.Get<IMembershipRepository>();

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateParameter(It.IsAny<string>(), It.IsAny<object>()))
             .Returns(new SqlParameter("parameter", "parameter value"));

            _kernel.GetMock<IDbCommandFactory>().Setup(x => x.CreateCommand("AdminAccount_Get", It.IsAny<object[]>()))
                .Returns(new SqlCommand("AdminAccount_Get") { CommandType = System.Data.CommandType.StoredProcedure });

            //_kernel.GetMock<IDbCommandExecutionService>().Setup(x => x.ExecuteQuery<IUserAccount>(
               // It.Is<DbCommand>(y => y.CommandType == System.Data.CommandType.StoredProcedure
                  //  && y.CommandText == "AdminAccount_Edit"))).Verifiable();   
            
            
            

            // act
           var adminProfile =  membershipRepository.Get("email@yahoo.com");          

            // assert

            //_kernel.GetMock<IDbCommandExecutionService>().VerifyAll();

           //Assert.IsNotNull(adminProfile);
           //Assert.IsInstanceOfType(adminProfile,typeof(IUserAccount));

           

        }
        
    }
}
