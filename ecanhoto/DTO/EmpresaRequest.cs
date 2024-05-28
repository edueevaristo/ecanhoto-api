using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.DTO
{
    public class EmpresaRequest
    {

        [Required]
        [MinLength(5)]
        public required string Nome { get; set; }

        [Required]
        public required string Telefone { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(14)]
        public required string Cnpj { get; set; }

        [Required]
        [MinLength(5)]
        public required string RazaoSocial { get; set; }

        [Required]
        public required string Localizacao {  get; set; }

        [Required]
        public required int QuantidadeFuncionarios { get; set; }

        [Required]
        public required string PorteIndustrial { get; set; }

        [Required] //Adicionado como string devido ao dígito
        public required string Conta { get; set; }

        [Required]
        public required string EnderecoCobranca { get; set; }

        [Required]
        public required float Receita { get; set; }

        public Empresa ToModel() => new Empresa(Nome, Telefone, Email, Cnpj, RazaoSocial, Localizacao, QuantidadeFuncionarios, PorteIndustrial, Conta, EnderecoCobranca, Receita);
    }
}
