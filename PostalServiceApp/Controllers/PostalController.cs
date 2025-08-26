using Microsoft.AspNetCore.Mvc;
using PostalServiceApp.Services;

namespace PostalServiceApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostalController : ControllerBase
{
    private readonly IPostalService _postalService;

    public PostalController(IPostalService postalService)
    {
        _postalService = postalService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchPostalCodes([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q) || q.Length < 2)
        {
            return Ok(new List<object>());
        }

        var postalCodes = await _postalService.SearchPostalCodesAsync(q);
        var results = postalCodes.Select(pc => new
        {
            code = pc.Code,
            display = $"{pc.Code} - {pc.City}, {pc.State}",
            city = pc.City,
            state = pc.State,
            country = pc.Country
        });

        return Ok(results);
    }

    [HttpGet("{postalCode}/addresses")]
    public async Task<IActionResult> GetAddresses(string postalCode)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
        {
            return BadRequest("Postal code is required");
        }

        var addresses = await _postalService.GetAddressesByPostalCodeAsync(postalCode);
        return Ok(addresses);
    }
}