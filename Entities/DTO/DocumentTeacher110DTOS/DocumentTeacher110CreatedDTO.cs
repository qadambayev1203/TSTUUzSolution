namespace Entities.DTO.DocumentTeacher110DTOS;

public class DocumentTeacher110CreatedDTO
{
    public required string title { get; set; }
    public int parent_id { get; set; }
    public required bool indicator { get; set; }
    public required double max_score { get; set; }
    public string? description { get; set; }
    public List<DocumentSequenceItemDTO>? document_sequence { get; set; }
    public required bool avtor { get; set; }
}

