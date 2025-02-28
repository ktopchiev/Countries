using CountriesServices;
using ServiceContracts.DTOs;

namespace CRUDTests
{
    public class CountriesService_CountryShould
    {
        private readonly CountriesService _countriesService;

        public CountriesService_CountryShould()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        [Fact]
        public void Add_Country_Return_CorrectProperties()
        {
            //Arange
            string countryName = "New Zealand";
            CountryAddRequest countryAddRequest = new() { Name = countryName };

            //Act
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            //Assert
            Assert.True(countryResponse.Name == countryName);
            Assert.True(countryResponse.CountryId != Guid.Empty);
        }

        [Fact]
        public void Add_NullCountryRequest_Throw_ArgumentNullException()
        {
            //Arange
            CountryAddRequest countryRequest = null;

            //Act
            Action actual = () => _countriesService.AddCountry(countryRequest);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Add_CountryRequestWithNoName_Throw_ArgumentException()
        {
            //Act
            Action actual = () => _countriesService.AddCountry(new CountryAddRequest());

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Add_CountryRequestWithExistingName_Throw_ArgumentException()
        {
            //Arange
            string countryName = "Egypt";
            CountryAddRequest countryRequest = new() { Name = countryName };
            CountryAddRequest actualCountryRequest = new() { Name = countryName };

            //Act
            _countriesService.AddCountry(countryRequest);
            Action actual = () => _countriesService.AddCountry(actualCountryRequest);

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
            List<CountryResponse> responses = new();

            //Act
            foreach (var country in countryNames)
            {
                responses.Add(_countriesService.AddCountry(new CountryAddRequest() { Name = country }));
            }

            List<CountryResponse> countries = _countriesService.GetAllCountries();

            //Assert
            foreach (var response in responses)
            {
                Assert.Contains(response, countries);
            }
        }
        #endregion
    }
}
