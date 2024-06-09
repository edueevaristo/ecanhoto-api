using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class CanhotoRequest
    {

        public string? Imagem { get; set; }

        public int ColaboradorId { get; set; }

        public int EmpresaId { get; set; }

        public int StatusId { get; set; }

        public float Valor {  get; set; }

        public int ChaveNf { get; set; }

        public int NumNf { get; set; }

        public Canhoto ToModel() => new Canhoto(Imagem, ColaboradorId, EmpresaId, StatusId, Valor, ChaveNf, NumNf);
    }
}
