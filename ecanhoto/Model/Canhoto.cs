using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace ecanhoto.Model
{
    public class Canhoto(string imagemCanhoto, int colaboradorId, int empresaId, int statusId)
    {
        [Key]
        public int Id { get; set; }

        public string ImagemCanhoto { get; set; } = imagemCanhoto;

        public int ColaboradorId { get; set; } = colaboradorId;

        public int EmpresaId { get; set; } = empresaId;

        public int StatusId { get; set; } = statusId;

    }
}
