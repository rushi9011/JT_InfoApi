using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT_InfoApi.Domain.Entities
{
    public class JT_Public_Holiday
    {
        public int Id { get; set; }
        public DateTime PHolDate { get; set; }
        public string PHolDesc { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
        public int? CtyId { get; set; }
        public Country? Country { get; set; }
    }
}