using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class CanhotoRequest
    {

        public string ImagemCanhoto { get; set; }

        public int ColaboradorId { get; set; }

        public int EmpresaId { get; set; }

        public int StatusId { get; set; }

        public Canhoto ToModel() => new Canhoto(ImagemCanhoto, ColaboradorId, EmpresaId, StatusId);
    }
}
