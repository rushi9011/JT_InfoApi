using JT_InfoApi.Application.Dtos;

namespace JT_InfoApi.Application.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDto>> GetByCountryAndYearAsync(string countryCode, int year, string? regionCode = null);
    }
}
