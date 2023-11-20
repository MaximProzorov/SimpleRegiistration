using Microsoft.AspNetCore.Mvc;
using SimpleRegistration.Api.Models;
using SimpleRegistration.Api.Repository;

namespace SimpleRegistration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly ILogger<ProvincesController> _logger;

    public ProvincesController(IProvinceRepository provinceRepository, ILogger<ProvincesController> logger)
    {
        _provinceRepository = provinceRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetProvincesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProvinces([FromQuery]Guid countryId)
    {
        try
        {
            var provinces = await _provinceRepository.GetProvinces(countryId);
            return Ok(provinces.Select(x => new GetProvincesResponse
            {
                ProvinceId = x.ProvinceId,
                Name = x.Name,
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"GetProvinces error.");
            return StatusCode(500, ex.Message);
        }
    }
}
