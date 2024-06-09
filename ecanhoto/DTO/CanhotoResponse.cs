using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class CanhotoResponse(Canhoto canhoto)
    {
        public string? ImagemCanhoto { get; set; } = canhoto.ImagemCanhoto;
        public int ColaboradorId { get; set; } = canhoto.ColaboradorId;
        public int EmpresaId { get; set; } = canhoto.EmpresaId;
        public int StatusId { get; set; } = canhoto.StatusId;
        public float ValorCanhoto { get; set; } = canhoto.ValorCanhoto;
        public int ChaveNf { get; set; } = canhoto.ChaveNf;
        public int NumNf { get; set; } = canhoto.NumNf;
        public string DataInclusao { get; set; } = Convert.ToString(canhoto.DataInclusao);
    }
}
