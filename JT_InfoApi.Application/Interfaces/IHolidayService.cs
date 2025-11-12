using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Domain.Entities;

namespace JT_InfoApi.Application.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDto>> GetByCountryAndYearAsync(string countryCode, int year, string? regionCode = null);
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }
}
