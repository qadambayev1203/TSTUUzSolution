namespace Entities.DTO;

public class OAuth2UserDTO
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string EmployeeIdNumber { get; set; }
    public string Type { get; set; }
    public List<string> Roles { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public int UniversityId { get; set; }
    public string Phone { get; set; }

    // Bu maydonlar HEMIS foydalanuvchisining pasport raqami va Jshshir qiymatlari uchun
    public string PassportNumber { get; set; } // Pasport raqami
    public string Jshshir { get; set; } // Jshshir (O'zbekistondagi shaxsiy identifikatsion raqam)
}
