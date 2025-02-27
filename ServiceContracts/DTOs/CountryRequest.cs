using Entities;

namespace ServiceContracts.DTOs
{
    public class CountryRequest
    {
        public string Name { get; set; }
    }

    public static class CountryRequestExtension
    {
        public static Country ToCountry(this CountryRequest countryRequest)
        {

            Country country = new() { Name = countryRequest.Name };

            return country;
        }
    }
}
