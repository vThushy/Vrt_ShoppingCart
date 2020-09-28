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


        public Product SetProductForTest
        {
            get
            {
                Product product = new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Frock",
                    Description = "A-Line frock",
                    Discount = 0,
                    Price = 1500,
                    DefaultImage = "1-DEF",
                    Size = "L",
                    BaseProduct = 1
                };
                return product;
            }
        }
        public List<Product> SetListOfProductForTest
        {
            get
            {
                List<Product> products = new List<Product>();
                products.Add(new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Frock",
                    Description = "A-Line frock",
                    Discount = 0,
                    Price = 1500,
                    DefaultImage = "1-DEF",
                    Size = "L",
                    BaseProduct = 1
                });
                products.Add(new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Frock",
                    Description = "Sleeveless frock",
                    Discount = 0,
                    Price = 1500,
                    DefaultImage = "2-DEF",
                    Size = "M",
                    BaseProduct = 1
                });
                return products;
            }
        }
        public List<Product> SetEmptyListOfProductForTest
        {
            get
            {
                List<Product> products = new List<Product>();
                return products;
            }
        }
        public ProductList SetProductListForTest
        {
            get
            {
                ProductList productList = new ProductList()
                {
                    NoOfProducts = 10,
                    ListOfProducts = SetListOfProductForTest
                };
                return productList;
            }
        }
        public ProductDetails SetProductDetailsForTest
        {
            get
            {
                ProductDetails productDetails = new ProductDetails()
                {
                    Id = 1,
                    ProductId = 1,
                    Size = ProductSize.L,
                    Color = "Maroon",
                    Attributes = "",
                    Image = "1-MAR"
                };
                return productDetails;
            }
        }
        public ProductList SetEmptyProductListForTest
        {
            get
            {
                ProductList productList = new ProductList()
                {
                    NoOfProducts = 0,
                    ListOfProducts = SetEmptyListOfProductForTest
                };
                return productList;
            }
        }



        public Payment SetPaymentForTest
        {
            get
            {
                Payment payment = new Payment()
                {
                    Id = 1,
                    OrderId = 1,
                    Amount = 1000,
                    PayMethod = PaymentMethod.Card,
                    Date = DateTime.Now,
                    Note = "notes"
                };
                return payment;
            }
        }
        public Payment SetEmptyPaymentForTest
        {
            get
            {
                Payment payment = new Payment();
                return payment;
            }
        }

        public List<Payment> SetListPaymentForTest
        {
            get
            {
                List<Payment> payment = new List<Payment>();
                payment.Add(new Payment()
                {
                    Id = 1,
                    OrderId = 1,
                    Amount = 1000,
                    PayMethod = PaymentMethod.Card,
                    Date = DateTime.Now,
                    Note = "notes"
                });
                payment.Add(new Payment()
                {
                    Id = 2,
                    OrderId = 1,
                    Amount = 1050,
                    PayMethod = PaymentMethod.Card,
                    Date = DateTime.Now,
                    Note = "notes"
                });
                return payment;
            }
        }

        public List<Payment> SetEmptyListOfPaymentForTest
        {
            get
            {
                List<Payment> payment = new List<Payment>();
                return payment;
            }
        }

     

    }
}
