using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartTest
{
    public class Datas
    {
        public Address SetAddressForTest
        {
            get
            {
                Address address = new Address()
                {
                    Id = 1,
                    UserName = "vThushy",
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
