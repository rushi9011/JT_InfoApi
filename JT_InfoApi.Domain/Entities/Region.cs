using System.ComponentModel.DataAnnotations;

namespace JT_InfoApi.Domain.Entities
{
    public class Region
    {
        public string RegionCode { get; set; } = string.Empty;
        public string? CtyCode { get; set; }
        public string? CtyDesc { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public virtual Country Country { get; set; }
        public virtual ICollection<JT_Public_Holiday>? PublicHolidays { get; set; }
    }
}
