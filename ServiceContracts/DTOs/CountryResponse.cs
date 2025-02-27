using Entities;

namespace ServiceContracts.DTOs
{
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? Name { get; set; }
    }

    public static class CountryResponseExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            CountryResponse countryResponse = new() { CountryId = country.CountryId, Name = country.Name };
            return countryResponse;
        }
    }
}
