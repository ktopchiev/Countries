using Entities;

namespace ServiceContracts.DTOs
{
    public class CountryAddRequest
    {
        public string Name { get; set; }
    }

    public static class CountryRequestExtension
    {
        public static Country ToCountry(this CountryAddRequest countryAddRequest)
        {
            return new Country() { Name = countryAddRequest.Name };
        }
    }
}
