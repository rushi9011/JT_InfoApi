using Microsoft.EntityFrameworkCore.Metadata;

namespace JT_InfoApi.Application.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CtyCode { get; set; }
        public string CtyDesc { get; set; }
    }
}
