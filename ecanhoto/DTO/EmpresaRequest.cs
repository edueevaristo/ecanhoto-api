using ecanhoto.Model;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.DTO
{
    public class EmpresaRequest
    {

        [Required]
        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        [MinLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [MinLength(5)]
        public string RazaoSocial{ get; set; }

        public Empresa ToModel() => new Empresa(Nome, Cnpj, RazaoSocial);
    }
}
