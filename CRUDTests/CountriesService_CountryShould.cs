using CountriesServices;
using ServiceContracts.DTOs;

namespace CRUDTests
{
    public class CountriesService_CountryShould
    {
        #region AddCountry
        [Fact]
        public void Add_Country_Return_CorrectProperties()
        {
            //Arange
            string countryName = "New Zealand";
            CountryAddRequest countryAddRequest = new() { Name = countryName };
            CountriesService countriesService = new();

            //Act
            CountryResponse countryResponse = countriesService.AddCountry(countryAddRequest);

            //Assert
            Assert.True(countryResponse.Name == countryName);
            Assert.True(countryResponse.CountryId != Guid.Empty);
        }

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
            string countryName = "Egypt";
            CountryAddRequest countryRequest = new() { Name = countryName };
            CountryAddRequest countryRequest2 = new() { Name = countryName };

            CountriesService countriesService = new CountriesService();

            //Act
            var response = countriesService.AddCountry(countryRequest);
            Action actual = () => countriesService.AddCountry(countryRequest2);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        public void Add_FewCountries_GetAllCountriesWithCorrectProperties()
        {
            //Arange
            string[] countryNames = ["India", "Chile"];
            CountriesService countriesService = new();
            List<CountryResponse> responses = new();

            //Act
            foreach (var country in countryNames)
            {
                responses.Add(countriesService.AddCountry(new CountryAddRequest() { Name = country }));
            }

            List<CountryResponse> countries = countriesService.GetAllCountries();

            //Assert
            foreach (var response in responses)
            {
                Assert.Contains(response, countries);
            }
        }
        #endregion
    }
}
