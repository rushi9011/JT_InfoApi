using System;

namespace JT_InfoApi.Application.Dtos
{
    public class HolidayDto
    {
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable <string> Info { get; set; }
    }
}
