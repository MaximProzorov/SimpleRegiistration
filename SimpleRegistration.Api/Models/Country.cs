namespace SimpleRegistration.Api.Models;

public class Country
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public List<Province> Provinces { get; set; }
}
