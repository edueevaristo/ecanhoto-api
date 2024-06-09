using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int EmpresaId { get; set; }

    [JsonIgnore]
    public Empresa Empresa { get; set; }

    [JsonIgnore]
    [Required]
    public string Password { get; set; }

    public bool IsActive { get; set; }

    public bool IsAdmin { get; set; }

    // Construtor com parâmetros
    public User(string name, string email, int empresaId, string password, bool isActive, bool isAdmin)
    {
        Name = name;
        Email = email;
        EmpresaId = empresaId;
        Password = password;
        IsActive = isActive; // Define um valor padrão para IsActive, se necessário
        IsAdmin = isAdmin;
    }

    //public User() { } // EF Core

    // Overload de User para casos de Update
    public User(int? id, string name, string email, int empresaId, string password, bool isActive, bool isAdmin)
    {
        Id = id ?? 0; 
        Name = name;
        Email = email;
        EmpresaId = empresaId;
        Password = password;
        IsActive = isActive;
        IsAdmin = isAdmin;
    }
}
