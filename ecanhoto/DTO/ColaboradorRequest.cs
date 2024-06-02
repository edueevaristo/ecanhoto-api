using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class ColaboradorRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string DataNascimento { get; set; }

        public string Cidade { get; set; }

        public int Cep { get; set; }

        public string Pais { get; set; }

        public string Endereco { get; set; }

        public string? UrlPerfilFoto { get; set; }

        public string? Permissoes { get; set; }

        public bool UsuarioAdmin { get; set; }

        public Colaborador ToModel() => new Colaborador(Nome, Email, Senha, DataNascimento, Cidade, Cep, Pais, Endereco, UrlPerfilFoto, Permissoes, UsuarioAdmin);
    }
}
