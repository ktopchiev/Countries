namespace Entities
{
    public class Country
    {
        public Country()
        {
            CountryId = Guid.NewGuid();
        }

        public Guid CountryId { get; }

        public string? Name { get; set; }
    }
}
