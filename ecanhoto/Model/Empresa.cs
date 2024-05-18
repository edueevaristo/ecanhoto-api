using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Empresa(string nome, string cnpj, string razaoSocial)
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Nome { get; set; } = nome;

        [Required, MaxLength(50)]
        public string Cnpj { get; set; } = cnpj;

        [Required, MaxLength(50)]
        public string RazaoSocial { get; set; } = razaoSocial;
    }
}
