namespace Entities.DTO.StatusDTOS;

public class StatusTranslationUpdatedDTO
{
    public string status { get; set; }
    public string? name { get; set; }
    public int status_id { get; set; }
    public int language_id { get; set; }
    public bool is_deleted { get; set; }
}
