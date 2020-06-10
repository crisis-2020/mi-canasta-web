using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
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
        public List<UsuarioDto> GetByFamiliaNombre(string familiaNombre);
        public FamiliaCreateDto Create(FamiliaCreateDto model);
        public Familia DesactivarSolicitudes(int idFamilia,FamiliaInfoSinListasDto familiaDto);
        public UsuarioFamiliaDto Remove(string UserDni);
        public void asignaRolUsuario(int IdFamilia, string Dni);
        public List<CompraDto> GetCompra(string FamiliaNombre, DateTime Inicio, DateTime Fin);
        public FamiliaDataDto GetById(int FamiliaId);
    }        
}