using GenFu;
using MiCanasta.Dto;
using MiCanasta.MiCanasta;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MiCanasta_Test
{
    public class FamiliaControllerTest
    {
		private IEnumerable<MiCanasta.MiCanasta.Model.Usuario> GetFakeDataUsuario()
		{
			var i = 1;
			var persons = A.ListOf<MiCanasta.MiCanasta.Model.Usuario>(26);
			persons.ForEach(x => x.Dni = (i++).ToString());
			return persons.Select(_ => _);
		}

		[Fact]
		public void Get_UsuariosTest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			//Arrange
			var familia = new FamiliaDto
			{
				FamiliaId = 1,
				Nombre = "Familia1",
				Dni = "18976453",
				UsuarioFamilias = new List<UsuarioFamiliaDto> {
					new UsuarioFamiliaDto {
						Usuario = new UsuarioDto {
							Dni = "18976453",
							Nombre = "Pepito",
							ApellidoMaterno = "Pérez",
							ApellidoPaterno = "Cieza",
							Contrasena = "343rf2d",
							RolUsuarios = new List<RolUsuarioDto> {
								new RolUsuarioDto {
									RolPerfil = new RolPerfilDto {
										RolPerfilId = 1,
										Descripcion = "Administrador",
										Perfil = new PerfilDto {
											PerfilId = 1,
											Descripcion = "Grupo Familiar"
										}
									}
								}
							}
						}
					}
				}
			};

			var firstUser = familia.UsuarioFamilias.First().Usuario;
			_service.Setup(x => x.GetByFamiliaNombre("Familia1")).Returns(familia);

			//act
			var result = _controller.GetUsuariosByNombreFamilia("Familia1");

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}
    }
}
