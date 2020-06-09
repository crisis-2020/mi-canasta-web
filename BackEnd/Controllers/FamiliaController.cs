using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.Persistence;
using System.Linq;
using MiCanasta.MiCanasta.Exceptions;
using System;
using MiCanasta.MiCanasta.Model;
using System.Diagnostics;
using MiCanasta.Dto;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("familias")]
    public class FamiliaController: ControllerBase
    {
        private readonly FamiliaService _familiaService;
        public FamiliaController(FamiliaService FamiliaService)
        {
            _familiaService = FamiliaService;
        }

        [HttpPost]
        public ActionResult Create(FamiliaCreateDto model)
        {
            try
            {
                return Created("Se ha creado el grupo familiar", _familiaService.Create(model));

            }
            catch (ExistingFamilyException ExistingFamilyException)
            {
                return BadRequest(ExistingFamilyException.ExceptionDto);
            }
        }

        [HttpGet("{nombreFamilia}/usuarios")]
        public ActionResult GetUsuariosByNombreFamilia(string nombreFamilia)
        {
            try
            {
                return Ok(_familiaService.GetByFamiliaNombre(nombreFamilia));
            }
            catch (FamilyNotFoundException) {
                return NoContent();
            }
        }

        [HttpGet("{NombreFamilia}/historiales")]
        public ActionResult GetHistoriales(string NombreFamilia, DateTime FechaInicio, DateTime FechaFinal) {
                return Ok(_familiaService.GetHistorial(NombreFamilia, FechaInicio, FechaFinal));
        }

        [HttpDelete("{NombreFamilia}/usuarios/{Dni}")]
        public ActionResult Remove(string NombreFamilia, string Dni)
        {
            try
            {
                return Ok(_familiaService.Remove(Dni));
            }
            catch (Exception) {
                return BadRequest();
            }
        }
        
        [HttpPut("/{IdFamilia}")]
        public ActionResult DesactivarSolicitudes(FamiliaInfoSinListasDto familiaDto)
        {
            try
            {
                _familiaService.DesactivarSolicitudes(familiaDto);
            }
            catch (FamilyNotFoundException FamilyNotFoundException)
            {
                return BadRequest(FamilyNotFoundException.ExceptionDto);
            }
            return Ok("Se desactivó realizar solicitudes y se eliminaron las existentes");
        }

        [HttpPut("{IdFamilia}/usuarios/{Dni}/RolesPorUsuario")]
        public ActionResult asignarRolUsuario(int IdFamilia, string Dni)
        {
            try
            {
                _familiaService.asignaRolUsuario(IdFamilia,Dni);
                return Ok("El rol fue modificado");
            }
            catch (UserNotFoundException userNotFoundException)
            {
                return BadRequest(userNotFoundException.ExceptionDto);
            }
        }

        [HttpGet("{FamiliaId}")]
        public ActionResult GetFamilia(int FamiliaId)
        {
            try 
            {
                return Ok(_familiaService.GetById(FamiliaId));
            }
            catch (Exception) 
            {
                return NoContent();
            }
        }
    }
}        