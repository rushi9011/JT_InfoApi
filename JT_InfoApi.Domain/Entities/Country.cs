using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT_InfoApi.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string CountryDesc { get; set; } = string.Empty;
        public virtual ICollection<Region> Regions { get; set; }
    }
}
