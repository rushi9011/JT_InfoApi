using System.ComponentModel.DataAnnotations;

namespace JT_InfoApi.Domain.Entities
{
    public class Country
    {
        public string CountryCode { get; set; } = string.Empty;
        public string CountryDesc { get; set; } = string.Empty;
        public virtual ICollection<Region> Regions { get; set; }
    }
}
