﻿using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class CanhotoResponse
    {
        public string ImagemCanhoto { get; set; }
        public int ColaboradorId { get; set; }
        public int EmpresaId { get; set; }
        public int StatusId { get; set; }

        public CanhotoResponse(Canhoto canhoto)
        {
            ImagemCanhoto = canhoto.ImagemCanhoto;
            ColaboradorId = canhoto.ColaboradorId;
            EmpresaId = canhoto.EmpresaId;
            StatusId = canhoto.StatusId;

        }
    }
}
