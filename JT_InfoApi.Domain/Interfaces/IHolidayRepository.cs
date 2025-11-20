using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Models;

namespace JT_InfoApi.Domain.Interfaces
{ 
    public interface IHolidayRepository
    {
        Task<IEnumerable<PublicHolidayResult>> GetByRegionAndYearAsync(int year, string regionCode, string countryCode);
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
