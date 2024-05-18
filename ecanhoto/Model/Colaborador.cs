using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Colaborador(string nome, string email, string senha, string urlPerfilFoto, string permissoes, bool usuarioAdmin)
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; } = nome;

        [Required, MinLength(10)]
        public string Email { get; set; } = email;

        [Required, MaxLength(50)]
        public string Senha { get; set; } = senha;

        public string UrlPerfilFoto { get; set; } = urlPerfilFoto;
        public string? Permissoes { get; set; } = permissoes;
        public bool UsuarioAdmin { get; set; } = usuarioAdmin;
    }
}
