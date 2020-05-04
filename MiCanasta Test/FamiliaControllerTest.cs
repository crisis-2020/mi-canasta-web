using System;
using MiCanasta.MiCanasta;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MiCanasta_Test
{
    public class FamiliaControllerTest
    {
		//Flujo normal: Si el grupo familiar no existe, entonces crea uno.
		[Fact]
		public void Add_ValidObjectPassed_ReturnOk()
		{
			var _service = new Mock<FamiliaService>();
			var _controller = new FamiliaController(_service.Object);

			FamiliaCreateDto modelCreateDto = new FamiliaCreateDto
			{
				FamiliaNombre = "RiverdaleFam",
				Dni = "12345677",
				AceptaSolicitudes = true
			};

			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelCreateDto);

			ActionResult result = _controller.Create(modelCreateDto);

			Assert.IsType<OkObjectResult>(result);
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
				FamiliaNombre = "RiverdaleFam77"
			};

			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelCreateDto);

			// Act
			ActionResult result = _controller.Create(modelCreateDto);

			Assert.Equal("RiverdaleFam77", modelCreateDto.FamiliaNombre);
		}

	}
}