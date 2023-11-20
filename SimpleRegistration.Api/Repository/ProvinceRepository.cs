using Microsoft.EntityFrameworkCore;
using SimpleRegistration.Api.Models;

namespace SimpleRegistration.Api.Repository;

public interface IProvinceRepository
{
    Task<List<Province>> GetProvinces(Guid countryId);
}

public class ProvinceRepository : IProvinceRepository
{
    private readonly ApplicationContext _context;

    public ProvinceRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Province>> GetProvinces(Guid countryId)
    {
        return await _context.Provinces.Where(p => p.CountryId == countryId).ToListAsync();
    }
}
