using Domain.Entities;
using Infraestucture.Service;
using Xunit;

namespace TestProject
{
    public class UnitTestBrazilianCode
    {
        [Fact]
        public void ErrorValidateZipCodeRequest()
        {          
            Assert.False(Validator.IsValid("032671AV"));
        }

        [Fact]
        public void SuccessValidateZipCodeRequest()
        {
            Assert.True(Validator.IsValid("01001-000"));
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
