using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT_InfoApi.Application.Dtos
{
    public class HolidayRequestDto
    {
        [Required]
        public int CustCode { get; set; }
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public string? Word { get; set; }
    }
}
