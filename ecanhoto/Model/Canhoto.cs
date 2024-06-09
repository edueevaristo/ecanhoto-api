using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Canhoto(string imagemCanhoto, int colaboradorId, int empresaId, int statusId, float valorCanhoto, int chaveNf, int numNf)
    {
        [Key]
        public int Id { get; set; }

        public string? ImagemCanhoto { get; set; } = imagemCanhoto;

        public int ColaboradorId { get; set; } = colaboradorId;

        public int EmpresaId { get; set; } = empresaId;

        public int StatusId { get; set; } = statusId;

        public float ValorCanhoto { get; set; } = valorCanhoto;

        public int ChaveNf { get; set; } = chaveNf;
        
        public int NumNf { get; set; } = numNf;

        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
