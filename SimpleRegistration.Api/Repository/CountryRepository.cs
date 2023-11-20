using Microsoft.EntityFrameworkCore;
using SimpleRegistration.Api.Models;

namespace SimpleRegistration.Api.Repository;

public interface ICountryRepository
{
    Task<List<Country>> GetCountries();
}

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationContext _context;

    public CountryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetCountries()
    {
        return await _context.Countries.ToListAsync();
    }
}
