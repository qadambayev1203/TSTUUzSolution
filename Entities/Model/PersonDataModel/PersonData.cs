﻿using Entities.Model.PersonModel;
using Entities.Model.StatusModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model.PersonDataModel;

public class PersonData
{
    public int id { get; set; }
    [ForeignKey("Person")] public int? persons_id { get; set; }
    public Person? persons_ { get; set; }
    public string? biography_json { get; set; }
    public DateTime? birthday { get; set; }
    public string? degree { get; set; }
    public string? scientific_title { get; set; }
    public int? experience_year { get; set; }
    public string? phone_number1 { get; set; }
    public string? phone_number2 { get; set; }
    public string? orchid { get; set; }
    public string? scopus_id { get; set; }
    public string? address { get; set; }
    public int? languages_uz { get; set; }
    public int? languages_en { get; set; }
    public int? languages_ru { get; set; }
    public string? languages_any_title { get; set; }
    public int? languages_any { get; set; }
    [ForeignKey("Status")] public int? status_id { get; set; }
    public Status? status_ { get; set; }
}
