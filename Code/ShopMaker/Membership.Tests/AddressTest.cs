using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proggasoft.Utility;
using Ninject;
using Moq;
using Ninject.MockingKernel.Moq;

namespace ShopMaker.Membership.Tests
{
    [TestClass]
    public class AddressTest : BaseTest
    {
        public AddressTest()
        {
            _kernel.Bind<IAddress>().To<Address>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Zipcode_SetEmptyZipcode_ThrowsException()
        {
            // prepare
            string invalidZipcode = string.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.Zipcode = invalidZipcode;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Zipcode_SetNullZipcode_ThrowsException()
        {
            // prepare
            string invalidZipcode = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.Zipcode = invalidZipcode;
        }
    }
}
