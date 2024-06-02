using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Empresa(string nome, string telefone, string email, string cnpj, string razaoSocial, string localizacao, int quantidadeFuncionarios, string porteIndustrial, string conta, string enderecoCobranca, float receita)
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Nome { get; set; } = nome;

        [Required]
        public string Telefone { get; set; } = telefone;

        [Required]
        public string Email { get; set; } = email;

        [Required, MaxLength(50)]
        public string Cnpj { get; set; } = cnpj;

        [Required, MaxLength(50)]
        public string RazaoSocial { get; set; } = razaoSocial;

        [Required]
        public string Localizacao { get; set; } = localizacao;

        [Required]
        public int QuantidadeFuncionarios { get; set; } = quantidadeFuncionarios;

        [Required]
        public string PorteIndustrial { get; set; } = porteIndustrial;

        [Required] //Adicionado como string devido ao dígito
        public string Conta { get; set; } = conta;

        [Required]
        public string EnderecoCobranca { get; set; } = enderecoCobranca;

        [Required]
        public float Receita { get; set; } = receita;

        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
