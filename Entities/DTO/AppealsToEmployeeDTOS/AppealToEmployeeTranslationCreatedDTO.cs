namespace Entities.DTO.AppealsToEmployeeDTOS;

public class AppealToEmployeeTranslationCreatedDTO
{
    public string? full_name { get; set; }
    public string? email { get; set; }
    public string? subject { get; set; }
    public string? message { get; set; }
    public int? language_id { get; set; }

    public int captcha_numbers_sum { get; set; }
}
