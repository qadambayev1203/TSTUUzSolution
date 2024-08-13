using Microsoft.AspNetCore.Http;

namespace Entities.DTO.AppealsToRectorDTOS;

public class AppealToRectorCreatedDTO
{
    public int country_id { get; set; }
    public int? territorie_id { get; set; }
    public int? district_id { get; set; }
    public int? neighborhood_id { get; set; }
    public string addres { get; set; }
    public string fio_ { get; set; }
    public DateTime birthday { get; set; }
    public int gender_id { get; set; }
    public int employe_id { get; set; }
    public string telephone_number_one { get; set; }
    public string? telephone_number_two { get; set; }
    public string email { get; set; }
    public IFormFile? file_upload_ { get; set; }
    public string appeal { get; set; }
    public int captcha_numbers_sum { get; set; }
}
