using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using JT_InfoApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JT_InfoApi.Domain.Repositories
{
    public class HolidayRepository(AppDbContext _context) : IHolidayRepository
    {
        public async Task<IEnumerable<PublicHolidayResult>> GetByCountryAndYearAsync(
        string countryCode,
        int year,
        string? regionCode = null)
        {
            year = year == 0 ? DateTime.Now.Year : year;

                return await _context.Set<PublicHolidayResult>()
                .FromSqlRaw("EXEC sp_GetPublicHolidaysByCountryAndYear @CountryCode = {0}, @Year = {1}, @RegionCode = {2}",
                    countryCode, year, regionCode)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.Include(x => x.Regions)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
