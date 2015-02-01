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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateOrPrvince_SetNullStateOrPrvince_ThrowsException()
        {
            // prepare
            string invalidStateOrPrvince = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.StateOrProvince = invalidStateOrPrvince;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateOrPrvince_SetEmptyStateOrPrvince_ThrowsException()
        {
            // prepare
            string invalidStateOrPrvince = string.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.StateOrProvince = invalidStateOrPrvince;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Country_SetNullCountry_ThrowsException()
        {
            // prepare
            string invalidCountry = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.Country = invalidCountry;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Country_SetEmptyCountry_ThrowsException()
        {
            // prepare
            string invalidCountry = String.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.Country = invalidCountry;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void City_SetEmptyCity_ThrowsException()
        {
            // prepare
            string invalidCity = String.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.City = invalidCity;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void City_SetNullCity_ThrowsException()
        {
            // prepare
            string invalidCity = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.City = invalidCity;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine2_SetNullAddressLine2_ThrowsException()
        {
            // prepare
            string invalidAddressLine2 = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.AddressLine2 = invalidAddressLine2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine2_SetEmptyAddressLine2_ThrowsException()
        {
            // prepare
            string invalidAddressLine2 = String.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.AddressLine2 = invalidAddressLine2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine1_SetNullAddressLine1_ThrowsException()
        {
            // prepare
            string invalidAddressLine1 = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.AddressLine1 = invalidAddressLine1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine1_SetEmptyAddressLine1_ThrowsException()
        {
            // prepare
            string invalidAddressLine1 = String.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.AddressLine1 = invalidAddressLine1;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ID_SetEmptyID_ThrowsException()
        {
            // prepare
            Guid invalidID = Guid.Empty;
            IAddress address = _kernel.Get<IAddress>();

            // act
            address.ID = invalidID;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Zipcode_GetEmptyZipcode_ThrowsException()
        {
            // prepare
            string invalidZipcode;
            IAddress address = _kernel.Get<IAddress>();

            // act
           invalidZipcode = address.Zipcode;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Zipcode_GetNullZipcode_ThrowsException()
        {
            // prepare
            string invalidZipcode;
            IAddress address = _kernel.Get<IAddress>();

            // act
             invalidZipcode=  address.Zipcode  ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateOrPrvince_GetNullStateOrPrvince_ThrowsException()
        {
            // prepare
            string invalidStateOrPrvince;
            IAddress address = _kernel.Get<IAddress>();

            // act
          invalidStateOrPrvince=  address.StateOrProvince  ;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StateOrPrvince_GetEmptyStateOrPrvince_ThrowsException()
        {
            // prepare
            string invalidStateOrPrvince ;
            IAddress address = _kernel.Get<IAddress>();

            // act
           invalidStateOrPrvince= address.StateOrProvince ;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Country_GetNullCountry_ThrowsException()
        {
            // prepare
            string invalidCountry ;
            IAddress address = _kernel.Get<IAddress>();

            // act
          invalidCountry = address.Country ;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Country_GetEmptyCountry_ThrowsException()
        {
            // prepare
            string invalidCountry;
            IAddress address = _kernel.Get<IAddress>();

            // act
             invalidCountry= address.Country ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void City_GetEmptyCity_ThrowsException()
        {
            // prepare
            string invalidCity ;
            IAddress address = _kernel.Get<IAddress>();

            // act
           invalidCity=  address.City ;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void City_GetNullCity_ThrowsException()
        {
            // prepare
            string invalidCity = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
           invalidCity= address.City  ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine2_GetNullAddressLine2_ThrowsException()
        {
            // prepare
            string invalidAddressLine2 ;
            IAddress address = _kernel.Get<IAddress>();

            // act
          invalidAddressLine2=  address.AddressLine2  ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine2_GetEmptyAddressLine2_ThrowsException()
        {
            // prepare
            string invalidAddressLine2 ;
            IAddress address = _kernel.Get<IAddress>();

            // act
            invalidAddressLine2= address.AddressLine2 ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine1_GetNullAddressLine1_ThrowsException()
        {
            // prepare
            string invalidAddressLine1 = null;
            IAddress address = _kernel.Get<IAddress>();

            // act
             invalidAddressLine1=address.AddressLine1 ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressLine1_GetEmptyAddressLine1_ThrowsException()
        {
            // prepare
            string invalidAddressLine1 ;
            IAddress address = _kernel.Get<IAddress>();

            // act
         invalidAddressLine1=   address.AddressLine1  ;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ID_GetEmptyID_ThrowsException()
        {
            // prepare
            Guid invalidID ;
            IAddress address = _kernel.Get<IAddress>();

            // act
           invalidID=  address.ID ;
        }

        
    }
}
