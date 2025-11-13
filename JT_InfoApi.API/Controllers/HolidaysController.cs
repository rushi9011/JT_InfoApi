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
        public async Task<IActionResult> GetHolidays([FromQuery] string country, [FromQuery] int year, [FromQuery] string? region, [FromQuery][Required] int custCode)
        {
            return Ok(await _holidayService.GetByCountryAndYearAsync(country, year, region));
        }

        [HttpGet]
        [Route("/get-countries")]
        public async Task<IActionResult> GetAllCountries([FromQuery][Required] int custCode)
        {
            var result = await _holidayService.GetAllAsync();
            return Ok(result);
        } 
    }
}
