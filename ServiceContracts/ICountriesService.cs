using ServiceContracts.DTOs;

namespace ServiceContracts
{
    public interface ICountriesService
    {
        CountryResponse AddCountry(CountryRequest countryRequest);
    }
}
