using Microsoft.AspNetCore.Mvc;
using SimpleRegistration.Api.Models;
using SimpleRegistration.Api.Repository;

namespace SimpleRegistration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ICountryRepository countryRepository, ILogger<CountriesController> logger)
    {
        _countryRepository = countryRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetCountriesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCountries()
    {
        try
        {
            var countries = await _countryRepository.GetCountries();
            return Ok(countries.Select(x => new GetCountriesResponse()
            {
                CountryId = x.CountryId,
                Name = x.Name
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GetCountries error.");
            return StatusCode(500, ex.Message);
        }
    }
}
