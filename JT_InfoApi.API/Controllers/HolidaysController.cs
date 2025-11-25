using JT_InfoApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JT_InfoApi.Domain.Infrastructure;

using JT_InfoApi.Application.Dtos;

namespace JT_InfoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController(IHolidayService _holidayService, ILogger<HolidaysController> logger) : ControllerBase
    {
        [HttpPost]
        [Route("/get-holidays")]
        public async Task<IActionResult> GetHolidays([FromBody] HolidayRequestDto request)
        {
            if (!General.EatPork(request.CustCode.ToString(), request.Word, logger))

            {
                return BadRequest("Unauthorized");
            }
            return Ok(await _holidayService.GetByRegionAndYearAsync(request.Year, request.Region,request.CountryCode));
        }

        [HttpGet]
        [Route("/get-countries")]
        public async Task<IActionResult> GetAllCountries([FromQuery][Required] int custCode)
        {
            return Ok(await _holidayService.GetAllAsync());
        } 
    }
}
