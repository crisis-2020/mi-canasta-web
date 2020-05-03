using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Services
{
    public interface FamiliaService 
    {
        public FamiliaDto Create(FamiliaCreateDto model);
        bool CrearGrupoFamiliar(FamiliaCreateDto model);
        //public RolUsuario AsignarRolUsuario(RolUsuario model);
        //public UsuarioFamilia 
    }        
}