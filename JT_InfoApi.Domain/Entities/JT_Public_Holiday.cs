using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JT_InfoApi.Domain.Entities
{
    public class JT_Public_Holiday
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string CtyCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string CtyDesc { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string CtyRegionCode { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "date")]
        public DateTime PHolDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string PHolDesc { get; set; } = string.Empty;

        [Column(TypeName = "datetime")]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}