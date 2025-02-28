using CountriesServices;
using ServiceContracts.DTOs;

namespace CRUDTests
{
    public class CountriesService_AddCountryShould
    {
        [Fact]
        public void Add_NullCountryRequest_Throw_ArgumentNullException()
        {
            //Arange
            CountryAddRequest countryRequest = null;
            CountriesService countriesService = new CountriesService();

            //Act
            Action actual = () => countriesService.AddCountry(countryRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Add_CountryRequestWithNoName_Throw_ArgumentException()
        {
            //Arange
            CountryAddRequest countryRequest = new();
            CountriesService countriesService = new CountriesService();

            //Act
            Action actual = () => countriesService.AddCountry(countryRequest);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Add_CountryRequestWithExistingName_Throw_ArgumentException()
        {
            //Arange
            CountryAddRequest countryRequest = new() { Name = "Bulgaria" };
            CountryAddRequest countryRequest2 = new() { Name = "Bulgaria" };

            CountriesService countriesService = new CountriesService();

            //Act
            var response = countriesService.AddCountry(countryRequest);
            Action actual = () => countriesService.AddCountry(countryRequest2);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }
    }
}
