using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JT_InfoApi.Appplication.Services
{

    public class HolidayService(IHolidayRepository _holidayRepository) : IHolidayService
    {
        public async Task<IEnumerable<HolidayDto>> GetByRegionAndYearAsync(int year, string regionCode, string countryCode)
        {
            var holidays = await _holidayRepository.GetByRegionAndYearAsync(year, regionCode, countryCode);
            return holidays.Select(x => new HolidayDto
            {
                Id = x.PublicHolidayId,
                CtyCode = x.RegionCode,
                RegionCode = x.RegionCode,
                LastUpdated = x.LastUpdated,
                PHolDate = DateOnly.FromDateTime(x.HolidayDate),
                PHolDesc = x.HolidayDescription
            });
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var result = await _holidayRepository.GetAllAsync();
            return result.Select(c => new CountryDto
            {
                Id  = c.Id,
                CountryCode = c.CountryCode,
                CountryDesc = c.CountryDesc,
                Regions = c.Regions?
             .Select(r => new RegionDto
             {
                 Id = r.Id,
                RegionCode = r.RegionCode,
                CtyName = r.CtyName
             })
            .ToList()
            });
        }
    }
}
