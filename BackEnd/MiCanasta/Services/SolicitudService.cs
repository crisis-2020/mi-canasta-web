using MiCanasta.MiCanasta.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface SolicitudService
    {
        public List<SolicitudDto> GetAll();
        SolicitudDto GetById(string dni, string familiaNombre);
        public SolicitudDto Create(SolicitudCreateDto model);
        bool AceptaSolicitudes(SolicitudCreateDto model);

        NombreFamiliaDto ObtenerNombreFamilia(String FamiliaId);



    }

}
