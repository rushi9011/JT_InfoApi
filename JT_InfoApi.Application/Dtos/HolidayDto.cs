using System;

namespace JT_InfoApi.Application.Dtos
{
    public class HolidayDto
    {
        public int Id { get; set; }
        public string CtyCode { get; set; } = string.Empty;

        public string CtyRegionCode { get; set; }

        public DateTime PHolDate { get; set; }

        public string PHolDesc { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
