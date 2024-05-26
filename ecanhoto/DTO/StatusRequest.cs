using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.DTO
{
    public class StatusRequest
    {
        [Required]
        [MinLength(5)]
        public required string Nome { get; set; }

        [Required]
        public required bool Ativo { get; set; }

        public Status ToModel() => new(Nome, Ativo);
    }
}