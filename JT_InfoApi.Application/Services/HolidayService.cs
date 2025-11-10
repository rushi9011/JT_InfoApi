using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain.Interfaces;

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
                CtyRegionCode = x.CtyRegionCode,
                LastUpdated = x.LastUpdated,
                PHolDate = x.PHolDate,
                PHolDesc = x.PHolDesc
            });
        }


    }
}
