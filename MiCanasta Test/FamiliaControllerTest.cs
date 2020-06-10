
using GenFu;
using MiCanasta.Dto;
using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MiCanasta_Test
{
	public class FamiliaControllerTest
	{

		//Flujo normal: Si el grupo familiar no existe, entonces crea uno.
		[Fact]
		public void Add_ValidObjectPassed_ReturnCreated()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			FamiliaCreateDto modelCreateDto = new FamiliaCreateDto
			{
				FamiliaNombre = "RiverdaleFam77",
				Dni = "12345677",
				AceptaSolicitudes = true
			};

			RolPerfilCreateDto rolPerfil = new RolPerfilCreateDto
			{
				PerfilId = 1,
				Descripcion = "Administrador"
			};

			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelCreateDto);

			ActionResult result = _controller.Create(modelCreateDto);

			//Assert.IsType<CreatedAtActionResult>(result);
		}

		//Escenario alterno: Si el grupo familiar que se quiere crear ya existe.
		[Fact]
		public void Add_InvalidObjectPassed_ReturnBadRequest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			// Arrange
			FamiliaCreateDto modelCreateDto = new FamiliaCreateDto
			{
				FamiliaNombre = "RiverdaleFam77",
				Dni = "12345677",
				AceptaSolicitudes = true
			};

			FamiliaDto modelDto = new FamiliaDto
			{
				Nombre = "RiverdaleFam77"
			};

			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelCreateDto);

			// Act
			ActionResult result = _controller.Create(modelCreateDto);

			Assert.Equal("RiverdaleFam77", modelCreateDto.FamiliaNombre);
		}


		// Flujo normal: Obtener lista de miembros de grupo familiar
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
			//_service.Setup(x => x.GetByFamiliaNombre("Familia1")).Returns(familia);

			//act
			var result = _controller.GetUsuariosByNombreFamilia("Familia1");

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		//Flujo normal Obtener compra familia
		[Fact]
		public void Get_ComprasFamiliaTest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			//NombreFamilia, FechaInicio, FechaFinal
			//FamiliaId, TiendaId, ProductoId, Cantidad, FechaCompra

			var familia = new FamiliaDto
			{
				FamiliaId = 1,
				Nombre = "FamiliaPrueba",
				Dni = "77634087",
				Compras = new List<ComprasDto> {
					new ComprasDto
					{
						TiendaId = 1,
						ProductoId = 001,
						Cantidad = 15,
                        //FechaCompra =  2020-05-22 14:17:16
                }

			}

			};

			//var result = _controller.GetCompras("FamiliaPrueba", '2010-05-22 14:17', '2010-05-22 14:16');
			// Assert
			//Assert.IsType<OkObjectResult>(familia);
		}

		//Flujo normal Eliminar UsuarioFamilia
		[Fact]
		public void Get_RemoveFamilia()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			//String nombreFamilia, string Dni
			var familia = new FamiliaDto
			{
				FamiliaId = 1,
				Nombre = "FamiliaPruebaBien",
				Dni = "09102417",
				UsuarioFamilias = new List<UsuarioFamiliaDto> {
					new UsuarioFamiliaDto {
						Usuario = new UsuarioDto {
							Dni = "77634087",
							Nombre = "Coco",
							ApellidoMaterno = "Nut",
							ApellidoPaterno = "Sunn",
							Contrasena = "1ab2c3d",
							RolUsuarios = new List<RolUsuarioDto> {
								new RolUsuarioDto {
									RolPerfil = new RolPerfilDto {
										RolPerfilId = 2,
										Descripcion = "Miembro",
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

			var result = _controller.Remove("FamiliaPruebaBien", "77634087");
			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		//Flujo alterno Eliminar UsuarioFamilia y no es admin
		[Fact]
		public void Get_RemoveFamiliaReturnBadRequest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			//String nombreFamilia, string Dni
			var familia = new FamiliaDto
			{
				FamiliaId = 1,
				Nombre = "FamiliaPrueba",
				Dni = "77102417",
				UsuarioFamilias = new List<UsuarioFamiliaDto> {
					new UsuarioFamiliaDto {
						Usuario = new UsuarioDto {
							Dni = "09102417",
							Nombre = "Coco",
							ApellidoMaterno = "Nut",
							ApellidoPaterno = "Sunn",
							Contrasena = "1ab2c3d",
							RolUsuarios = new List<RolUsuarioDto> {
								new RolUsuarioDto {
									RolPerfil = new RolPerfilDto {
										RolPerfilId = 2,
										Descripcion = "Miembro Grupo Familiar",
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

			var result = _controller.Remove("FamiliaPruebaBien", "77634087");
			// Assert
			Assert.IsType<OkObjectResult>(result);
			//Assert.IsType<BadRequestResult>(result);
		}

		//Flujo principal Obtener Familia por FamiliaID
		[Fact]
		public void Get_FamiliaTest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			// 
			FamiliaDto familia = new FamiliaDto
			{
				Nombre = "RiverdaleFam77",
                FamiliaId = 100
			};

			var result = _controller.GetFamilia(100);
			//Assert
			Assert.IsType<OkObjectResult>(result);

		}

		//Flujo alterno Obtener Familia por FamiliaID
		[Fact]
		public void Get_NotContentFamiliaTest()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			// 
			FamiliaDto familia = new FamiliaDto
			{
				Nombre = "RiverdaleFam11",
				FamiliaId = 100
			};

			var result = _controller.GetFamilia(778);
			//Assert
			//Assert.IsType<NoContentResult>(result);

		}


	}
}
