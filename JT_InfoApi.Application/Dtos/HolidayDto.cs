using System;

namespace JT_InfoApi.Application.Dtos
{
    public class HolidayDto
    {
        public int Id { get; set; }
        public string CtyCode { get; set; }

        public string RegionCode { get; set; }

        public DateOnly PHolDate { get; set; }

        public string PHolDesc { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
