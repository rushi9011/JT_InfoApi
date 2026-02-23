using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            return Ok(await _holidayService.GetByCountryAndYearAsync(request.Year,request.CountryCode));
        }

        [HttpPost]
        [Route("/get-countries")]
        public async Task<IActionResult> GetAllCountries([FromBody]CountryRequestDto requestDto)
        {
            if (!General.EatPork(requestDto.CustCode.ToString(), requestDto.Word, logger))

            {
                return BadRequest("Unauthorized");
            }
            return Ok(await _holidayService.GetAllAsync());
        } 
    }
}
