using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Status(string nome, bool ativo)
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = nome;

        public bool Ativo { get; set; } = ativo;
    }
}
