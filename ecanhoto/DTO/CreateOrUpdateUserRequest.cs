using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.DTO
{
    public class CreateOrUpdateUserRequest
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public string DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public string? UrlPerfilFoto { get; set; }

        public User ToModel()
        {
            if (Id.HasValue)
            {
                return new User
                (
                    Id.Value,
                    Name,
                    Email,
                    EmpresaId,
                    Password,
                    IsActive,
                    IsAdmin,
                    DataNascimento,
                    UrlPerfilFoto,
                    DateTime.Now // Atualiza a data de inclusão
                );
            }
            else
            {
                return new User
                (
                    Name,
                    Email,
                    EmpresaId,
                    Password,
                    IsActive,
                    IsAdmin,
                    DataNascimento,
                    UrlPerfilFoto
                );
            }
        }
    }
}
