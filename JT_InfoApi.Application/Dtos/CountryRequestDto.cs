using System.ComponentModel.DataAnnotations;

namespace JT_InfoApi.Application.Dtos
{
    public class CountryRequestDto
    {
        [Required]
        public int CustCode { get; set; }
        public string? Word { get; set; }
    }
}
