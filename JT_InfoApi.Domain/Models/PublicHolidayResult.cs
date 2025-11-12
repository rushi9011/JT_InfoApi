namespace JT_InfoApi.Domain.Models
{
    public class PublicHolidayResult
    {
        public int Id { get; set; }
        public string RegionCode { get; set; }
        public string CtyCode { get; set; }
        public DateTime PHolDate { get; set; }
        public string PHolDesc { get; set; }
        public DateTime LastUpdated { get; set; }
        public string CountryCode { get; set; }
        public string CountryDesc { get; set; }
    }

}
