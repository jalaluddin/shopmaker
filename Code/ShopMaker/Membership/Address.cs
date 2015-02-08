using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.Membership
{
    public class Address : IEntity, IAddress
    {
        private Guid _id;
        public Guid ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;

                if (_id == Guid.Empty)
                {
                    throw new ArgumentNullException("ID  is Empty.");
                }
            
            }
        }


        private string _addressline1;
        public string AddressLine1
        {
            get
            {
                return _addressline1;
            }
            set
            {
                _addressline1 = value;
                if (String.IsNullOrEmpty(_addressline1))
                {
                    throw new ArgumentNullException("AddressLine1  is NullorEmpty.");
                }
            
            }
        }


        private string _addressline2;
        public string AddressLine2
        {
            get
            {
                return _addressline2; 
            }
            set
            {
                _addressline2 = value;
               
                if (String.IsNullOrEmpty(_addressline2))
                {
                    throw new ArgumentNullException("AddressLine2  is NullorEmpty.");
                }
            
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                if (String.IsNullOrEmpty(_city))
                {
                    throw new ArgumentNullException("City  is NullorEmpty.");
                }
            
            }
        }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                if (String.IsNullOrEmpty(_country))
                {
                    throw new ArgumentNullException("country  is NullorEmpty.");
                }
            }
        }


        private string _stateofprovince;
        public string StateOrProvince
        {
            get
            {
                return _stateofprovince;
            }
            set
            {
                _stateofprovince = value;
                if (String.IsNullOrEmpty(_stateofprovince))
                {
                    throw new ArgumentNullException("StateOrProvince  is NullorEmpty.");
                }
            
            }
        }

        private string _zipcode;
        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                _zipcode = value;

                if (String.IsNullOrEmpty(_zipcode))
                {
                    throw new ArgumentNullException("Zipcode  is NullorEmpty.");
                }
            }
        }
    }
}
