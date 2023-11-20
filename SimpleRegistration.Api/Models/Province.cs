namespace SimpleRegistration.Api.Models;

public class Province
{
    public Guid ProvinceId { get; set; }
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
}
