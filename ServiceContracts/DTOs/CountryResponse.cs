using Entities;

namespace ServiceContracts.DTOs
{
    public class CountryResponse
    {
        public Guid? CountryId { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj == typeof(CountryResponse)) return false;

            CountryResponse response = (CountryResponse)obj;

            return CountryId == response.CountryId && Name == response.Name;
        }
    }

    public static class CountryResponseExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            if (country == null) return null;

            return new CountryResponse() { CountryId = country.CountryId, Name = country.Name };
        }
    }
}
