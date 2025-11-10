using JT_InfoApi.Domain.Entities;

namespace JT_InfoApi.Domain.Interfaces
{ 
    public interface IHolidayRepository
    {
        Task<IEnumerable<JT_Public_Holiday>> GetByCountryAndYearAsync(string countryCode, int year, string? regionCode = null);
    }
}
