using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JT_InfoApi.Domain.Repositories
{
    public class HolidayRepository(AppDbContext _context) : IHolidayRepository
    {
        public async Task<IEnumerable<JT_Public_Holiday>> GetByCountryAndYearAsync(string countryCode, int year, string? regionCode = null)
        {
            year = year == 0 ? DateTime.Now.Year : year;

            var query = _context.JT_Public_Holidays
                .Where(h => h.CtyCode == countryCode && h.PHolDate.Year == year);

            if (!string.IsNullOrWhiteSpace(regionCode))
            {
                query = query.Where(h => h.CtyRegionCode == regionCode);
            }

            return await query
                .OrderBy(h => h.PHolDate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
