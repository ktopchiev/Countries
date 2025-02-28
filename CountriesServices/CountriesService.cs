using ServiceContracts.DTOs;
using ServiceContracts;
using Entities;

namespace CountriesServices
{
    public class CountriesService : ICountriesService
    {
        private List<Country> _countries;

        public CountriesService()
        {
            _countries = new();
        }

        public CountryResponse AddCountry(CountryAddRequest countryAddRequest)
        {
            if (countryAddRequest == null) throw new ArgumentNullException();

            if (String.IsNullOrEmpty(countryAddRequest.Name)) throw new ArgumentException();

            Country country = countryAddRequest.ToCountry();

            if (_countries.Any(c => c.Name == country.Name)) throw new ArgumentException("Country with that name already exist");

            _countries.Add(country);

            return country.ToCountryResponse();
        }
    }
}
