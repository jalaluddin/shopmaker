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
    public class MembershipRepositoryFactoryTest : BaseTest
    {
        public MembershipRepositoryFactoryTest()
        {
            _kernel.Bind<IMembershipRepositoryFactory>().To<MembershipRepositoryFactory>();
        }

        [TestMethod]
        public void CreateMembershipRepository_UserTypeOptionsShopOwner_ShopOwnerInstance()
        {
            // prepare
            var membershipRepositoryFactory = _kernel.Get<IMembershipRepositoryFactory>();

            // act
            var membershipInstance = membershipRepositoryFactory.CreateMembershipRepository(Web.UserTypeOptions.ShopOwner);

            // assert
            Assert.IsInstanceOfType(membershipInstance, typeof(ShopOwner));
        }

        [TestMethod]
        public void CreateMembershipRepository_UserTypeOptionsAdmin_AdminInstance()
        {
            // prepare
            var membershipRepositoryFactory = _kernel.Get<IMembershipRepositoryFactory>();

            // act
            var membershipInstance = membershipRepositoryFactory.CreateMembershipRepository(Web.UserTypeOptions.Admin);

            // assert
            Assert.IsInstanceOfType(membershipInstance, typeof(Admin));
        }
    }
}
