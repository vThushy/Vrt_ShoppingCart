using ShoppingCart.Controllers;
using ShoppingCart.Enum;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartTest
{
    public class Datas
    {
        public string SetUserNameForTest
        {
            get
            {
                return "vThushy";
            }
        }
        public CustomerRegObj SetCustomerRegObjForTest
        {
            get
            {
                CustomerRegObj customerRegObj = new CustomerRegObj()
                {
                    User = SetUserForTest,
                    Customer = SetCustomerForTest,
                    Address = SetAddressForTest
                };
                return customerRegObj;
            }
        }
        public ResponseUser SetResponseUserForTest
        {
            get
            {
                ResponseUser responseUser = new ResponseUser("vThushy", "DummyToken");
                return responseUser;
            }
        }
        public User SetUserForTest
        {
            get
            {
                User user = new User()
                {
                    UserName = "Thushy",
                    Password = "0Thushy",
                    UserRole = AccessRole.Admin,
                    ResetCode = "1"
                };
                return user;
            }

        }
        public Customer SetCustomerForTest
        {
            get
            {
                Customer customer = new Customer()
                {
                    UserName = "Thushy",
                    FirstName = "Thushy",
                    LastName = "Vimal",
                    //DateOfBirth = "",
                    Gender = Gender.Female,
                    Email = "vthushy@gmail.com",
                };
                return customer;
            }

        }
        public Address SetAddressForTest
        {
            get
            {
                Address address = new Address()
                {
                    Id = 1,
                    UserName = "Thushy",
                    AddressType = "Home",
                    AddressLine = "Kachchceri Road",
                    City = "Jaffna",
                    State = "Northern",
                    Country = "Sri Lanka",
                    ZipCode = "40000"
                };
                return address;
            }
        }

        public List<Address> SetListOfAddressForTest
        {
            get
            {
                var addresses = new List<Address>();
                addresses.Add(new Address()
                {
                    Id = 1,
                    UserName = "vThushy",
                    AddressType = "Home",
                    AddressLine = "Kachchceri Road",
                    City = "Jaffna",
                    State = "Northern",
                    Country = "Sri Lanka",
                    ZipCode = "40000"
                });
                addresses.Add(new Address()
                {
                    Id = 2,
                    UserName = "vThushy",
                    AddressType = "Work",
                    AddressLine = "Danister silva mw",
                    City = "Dematagoda",
                    State = "Western",
                    Country = "Sri Lanka",
                    ZipCode = "17000"
                });

                return addresses;
            }
        }

    }
}
