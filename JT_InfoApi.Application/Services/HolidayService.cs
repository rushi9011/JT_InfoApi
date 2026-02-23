using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JT_InfoApi.Appplication.Services
{

    public class HolidayService(IHolidayRepository _holidayRepository) : IHolidayService
    {
        public async Task<HolidayDto> GetByCountryAndYearAsync(int year, string countryCode)
        {
            var holidays = await _holidayRepository.GetByCountryAndYearAsync(year, countryCode);

            return new HolidayDto
            {
                CountryCode = countryCode,
                TotalCount = holidays.Count(),
                Info = holidays.Select(x => $"{x.HolidayDate:yyyy-MM-dd}, {x.HolidayDescription}")
            };
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var result = await _holidayRepository.GetAllAsync();
            return result.Select(c => new CountryDto
            {
                Id  = c.Id,
                CountryCode = c.CountryCode
            });
        }
    }
}
