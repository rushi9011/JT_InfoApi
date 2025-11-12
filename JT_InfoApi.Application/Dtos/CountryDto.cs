namespace JT_InfoApi.Application.Dtos
{
    public class CountryDto
    {
        public string CountryCode { get; set; }
        public string CountryDesc { get; set; }
        public List<RegionDto> Regions { get; set; }
    }

    public class RegionDto
    {
        public string RegionCode { get; set; }
        public string? CtyDesc { get; set; }
    }

}
