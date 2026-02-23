using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Interfaces;
using JT_InfoApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JT_InfoApi.Domain.Repositories
{
    public class HolidayRepository(AppDbContext _context) : IHolidayRepository
    {
        public async Task<IEnumerable<PublicHolidayResult>> GetByCountryAndYearAsync(int year, string countryCode)
        {
            year = year == 0 ? DateTime.Now.Year : year;

                return await _context.Set<PublicHolidayResult>()
                .FromSqlRaw("EXEC sp_GetPublicHolidaysByRegionAndYear @Year = {0}, @RegionCode = {1}, @CountryCode = {2}",
                    year, countryCode)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
