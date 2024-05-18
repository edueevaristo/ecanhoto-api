using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class CanhotoResponse
    {
        public string ImagemCanhoto { get; set; }
        public int ColaboradorId { get; set; }
        public int EmpresaId { get; set; }
        public int StatusId { get; set; }

        public Colaborador? Colaborador { get; set; }
        public Empresa? Empresa { get; set; }
        public Status? Status { get; set; }


        public CanhotoResponse(Canhoto canhoto)
        {
            Colaborador = canhoto.Colaborador;
            Empresa = canhoto.Empresa;
            Status = canhoto.Status;

            ImagemCanhoto = canhoto.ImagemCanhoto;
            ColaboradorId = canhoto.ColaboradorId;
            EmpresaId = canhoto.EmpresaId;
            StatusId = canhoto.StatusId;

        }
    }
}
