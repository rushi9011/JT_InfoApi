using JT_InfoApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JT_InfoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController(IHolidayService _holidayService) : ControllerBase
    {
        [HttpGet]
        [Route("/get-holidays")]
        public async Task<IActionResult> GetHolidays([FromQuery] int year, [FromQuery][Required] int custCode, [FromQuery] string countryCode,[FromQuery] string? region = null)
        {
            return Ok(await _holidayService.GetByRegionAndYearAsync(year, region,countryCode));
        }

        [HttpGet]
        [Route("/get-countries")]
        public async Task<IActionResult> GetAllCountries([FromQuery][Required] int custCode)
        {
            return Ok(await _holidayService.GetAllAsync());
        } 
    }
}
