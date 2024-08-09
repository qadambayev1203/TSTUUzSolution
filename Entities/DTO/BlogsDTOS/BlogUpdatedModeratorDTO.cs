using Microsoft.AspNetCore.Http;

namespace Entities.DTO.BlogsDTOS
{
    public class BlogUpdatedModeratorDTO
    {
        public string title_short { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string text { get; set; }
        public DateTime? event_date { get; set; }
        public DateTime? event_end_date { get; set; }
        public IFormFile? img_up { get; set; }
        public int blog_category_id { get; set; }
        public int? position { get; set; }
        public bool favorite { get; set; }
    }
}
