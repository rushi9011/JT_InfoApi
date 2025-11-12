using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Models;

namespace JT_InfoApi.Domain.Interfaces
{ 
    public interface IHolidayRepository
    {
        Task<IEnumerable<PublicHolidayResult>> GetByCountryAndYearAsync(string countryCode, int year, string? regionCode = null);
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
