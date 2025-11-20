using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT_InfoApi.Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionCode { get; set; }
        public string? CtyName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<JT_Public_Holiday>? PublicHolidays { get; set; }
    }
}
