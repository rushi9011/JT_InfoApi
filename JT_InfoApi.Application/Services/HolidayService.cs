using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JT_InfoApi.Appplication.Services
{

    public class HolidayService(IHolidayRepository _holidayRepository) : IHolidayService
    {
        public async Task<IEnumerable<HolidayDto>> GetByCountryAndYearAsync(string countryCode, int year, string regionCode = null)
        {
            var holidays = await _holidayRepository.GetByCountryAndYearAsync(countryCode, year, regionCode);
            return holidays.Select(x => new HolidayDto
            {
                Id = x.Id,
                CtyCode = x.CtyCode,
                RegionCode = x.RegionCode,
                LastUpdated = x.LastUpdated,
                PHolDate = x.PHolDate,
                PHolDesc = x.PHolDesc
            });
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var result = await _holidayRepository.GetAllAsync();
            return result.Select(c => new CountryDto
            {
                CountryCode = c.CountryCode,
                CountryDesc = c.CountryDesc,
                Regions = c.Regions?
            .Select(r => new RegionDto
            {
                RegionCode = r.RegionCode,
                CtyDesc = r.CtyDesc
            })
            .ToList()
            });
        }
    }
}
