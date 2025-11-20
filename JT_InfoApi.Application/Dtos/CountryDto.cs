using Microsoft.EntityFrameworkCore.Metadata;

namespace JT_InfoApi.Application.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryDesc { get; set; }
        public List<RegionDto> Regions { get; set; }
    }

    public class RegionDto
    {
        public int Id { get; set; }
        public string RegionCode { get; set; }
        public string? CtyName { get; set; }
    }

}
