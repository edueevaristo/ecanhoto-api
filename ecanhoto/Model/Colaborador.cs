using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ecanhoto.Model
{
    public class Colaborador(string nome, string email, string senha, string dataNascimento, string cidade, int cep, string pais, string endereco, string urlPerfilFoto, string permissoes, bool usuarioAdmin)
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; } = nome;

        [Required, MinLength(10)]
        public string Email { get; set; } = email;

        [Required, MaxLength(50)]
        public string Senha { get; set; } = senha;

        [Required]
        public string DataNascimento { get; set; } = dataNascimento;

        [Required]
        public string Cidade { get; set; } = cidade;

        [Required]
        public int Cep { get; set; } = cep;

        [Required]
        public string Pais { get; set; } = pais;

        [Required]
        public string Endereco { get; set; } = endereco;

        public string? UrlPerfilFoto { get; set; } = urlPerfilFoto;

        public string? Permissoes { get; set; } = permissoes;

        public bool UsuarioAdmin { get; set; } = usuarioAdmin;

        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
