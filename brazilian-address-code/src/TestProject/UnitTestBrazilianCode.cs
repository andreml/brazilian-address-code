using App.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTestBrazilianCode
    {
        [Fact]
        public void ErrorValidateZipCodeRequest()
        {
            var address = new Address();
            address.zipCode = "032671AV";
            Assert.False(address.IsValid());
        }

        [Fact]
        public void SuccessValidateZipCodeRequest()
        {
            var address = new Address();
            address.zipCode = "01001-000";
            Assert.True(address.IsValid());
        }

        [Fact]
        public void SuccessSearchByZipCodeAdressExists()
        {
            var _addressService = new AddressService();
            var address = _addressService.GetAddressByZipCode("01001-000").Result;
            Assert.True(address.IsValidZipCode());
        }

        [Fact]
        public void ErrorSearchByZipCodeAddressNotExists()
        {
            var _addressService = new AddressService();
            Assert.True(_addressService.GetAddressByZipCode("99999-999").Result == null);
        }
    }
}
