using JT_InfoApi.Application.Dtos;
using JT_InfoApi.Domain.Entities;

namespace JT_InfoApi.Application.Interfaces
{
    public interface IHolidayService
    {
        Task<HolidayDto> GetByCountryAndYearAsync(int year, string countryCode);
        Task<IEnumerable<CountryDto>> GetAllAsync();
    }
}
