using JT_InfoApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JT_InfoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController(IHolidayService _holidayService) : ControllerBase
    {
        [HttpGet]
        [Route("/get-holidays")]
        public async Task<IActionResult> GetHolidays([FromQuery] string country, [FromQuery] int year, [FromQuery] string? region = null)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(country))
                return BadRequest("Country code is required.");

                var holidays = await _holidayService.GetByCountryAndYearAsync(country, year, region);

            if (!holidays.Any())
                return NotFound("No holidays found for the given criteria.");

            return Ok(holidays);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
