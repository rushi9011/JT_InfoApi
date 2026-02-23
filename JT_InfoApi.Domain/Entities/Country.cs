using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT_InfoApi.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CtyCode { get; set; } = string.Empty;
        public string CtyDesc { get; set; } = string.Empty;
        public ICollection<JT_Public_Holiday>? PublicHolidays { get; set; }
    }
}
