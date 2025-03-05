using ServiceContracts.DTOs;

namespace ServiceContracts
{
    public interface ICountriesService
    {
        CountryResponse AddCountry(CountryAddRequest countryAddRequest);
        List<CountryResponse> GetAllCountries();
        CountryResponse GetCountryById(Guid? id);
    }
}
