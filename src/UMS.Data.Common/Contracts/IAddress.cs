namespace UMS.Data.Common
{
    using UMS.Data.Common.Enumerations;

    public interface IAddress
    {
        int Id { get; set; }

        string StreetName { get; set; }

        string District { get; set; }

        string Town { get; set; }

        string PostalCode { get; set; }

        string Country { get; set; }

        Continent Continent { get; set; }
    }
}
