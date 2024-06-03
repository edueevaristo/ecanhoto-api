using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.DTO
{
    public class CreateOrUpdateUserRequest
    {
        // ID nao é necessário apra criar, mas é para atualizar
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

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

        public User ToModel()
        {
            return new User
            (
                Id = this.Id ?? 0,
                Name = this.Name,
                Email = this.Email,
                EmpresaId = this.EmpresaId,
                Password = this.Password,
                IsActive = this.IsActive,
                IsAdmin = this.IsAdmin
            );
        }
    }
}
