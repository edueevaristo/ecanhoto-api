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
    public string DataNascimento { get; set; }

    [Required]
    [EmailAddress]
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

    public DateTime DataInclusao { get; set; } = DateTime.Now;

    public string? UrlPerfilFoto { get; set; }

    public User() { }

    public User(string name, string email, int empresaId, string password, bool isActive, bool isAdmin, string dataNascimento, string? urlPerfilFoto)
    {
        Name = name;
        Email = email;
        EmpresaId = empresaId;
        Password = password;
        IsActive = isActive;
        IsAdmin = isAdmin;
        DataNascimento = dataNascimento;
        UrlPerfilFoto = urlPerfilFoto ?? "";
        DataInclusao = DateTime.Now;
    }

    public User(int id, string name, string email, int empresaId, string password, bool isActive, bool isAdmin, string dataNascimento, string? urlPerfilFoto, DateTime dataInclusao)
    {
        Id = id;
        Name = name;
        Email = email;
        EmpresaId = empresaId;
        Password = password;
        IsActive = isActive;
        IsAdmin = isAdmin;
        DataNascimento = dataNascimento;
        UrlPerfilFoto = urlPerfilFoto ?? "";
        DataInclusao = dataInclusao;
    }
}
