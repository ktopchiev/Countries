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
            return new CountryResponse() { CountryId = country.CountryId, Name = country.Name };
        }
    }
}
