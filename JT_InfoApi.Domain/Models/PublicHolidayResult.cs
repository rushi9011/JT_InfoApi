namespace JT_InfoApi.Domain.Models
{
    public class PublicHolidayResult
    {
        public int PublicHolidayId { get; set; }   
        public DateTime HolidayDate { get; set; }
        public string HolidayDescription { get; set; }        
        public DateTime LastUpdated { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
    }

}
