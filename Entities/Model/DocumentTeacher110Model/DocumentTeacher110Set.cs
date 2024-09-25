using Entities.Model.FileModel;
using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities.Model.DocumentTeacher110Model;

public class DocumentTeacher110Set
{
    public int id { get; set; }
    [ForeignKey("Person")] public int? person_id { get; set; }
    public Person? person_ { get; set; }
    public int? old_year { get; set; }
    public int? new_year { get; set; }
    [ForeignKey("DocumentTeacher110")] public int? document_id { get; set; }
    public DocumentTeacher110? document_ { get; set; }
    [ForeignKey("Files")] public int? file_id { get; set; }
    public Files? file_ { get; set; }
    public string? comment { get; set; }
    public double? score { get; set; }
    public int? sequence_status { get; set; }
    public string? reason_for_rejection { get; set; }
    public bool? rejection { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
    [ForeignKey("User")] public int? assessor_id { get; set; }
    public User? assessor_ { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public DateTime? fixed_date { get; set; }
    public bool? avtor { get; set; }
    public int? number_authors { get; set; }
}
