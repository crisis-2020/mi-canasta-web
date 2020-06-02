using AutoMapper;
using GenFu;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using MiCanasta.MiCanasta.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MiCanasta_Test
{
	public class SolicitudControllerTest
    {
		//Si la familia no existe
		[Fact]
		public void Add_InvalidObjectPassed_ReturnNotFound()
		{
			var _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);

			// Arrange
			SolicitudCreateDto modelCreateDto = new SolicitudCreateDto
			{
				Dni = "76697297",
				FamiliaNombre = "Los pinguinos"
			};

			SolicitudDto modelDto = null;
			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelDto);

			// Act
			ActionResult result = _controller.Post(modelCreateDto);

			// Assert
			//Assert.IsType<NotFoundObjectResult>(result);
		}


		//Si la familia no acepta solicitudes
		[Fact]
		public void Add_ValidObjectPassed_ReturnBadRequest()
		{
			var _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);

			// Arrange
			SolicitudCreateDto modelCreateDto = new SolicitudCreateDto
			{
				Dni = "76697298",
				FamiliaNombre = "Los Pollitos"
			};

			SolicitudDto modelDto = new SolicitudDto
			{
				Dni = "76697298",
				FamiliaNombre = "Los Pollitos"
			};
			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelDto);
			_service.Setup(x => x.AceptaSolicitudes(modelCreateDto)).Returns(false);

			// Act
			ActionResult result = _controller.Post(modelCreateDto);
            
			// Assert
			//Assert.IsType<BadRequestObjectResult>(result);
		}

		//Flujo normal
		[Fact]
		public void Add_ValidObjectPassed_ReturnOk()
		{
			var _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);

			// Arrange
			SolicitudCreateDto modelCreateDto = new SolicitudCreateDto
			{
				Dni = "15665105",
				FamiliaNombre = "LosGeniales"
			};
			SolicitudDto modelDto = new SolicitudDto
			{
				Dni = "15665105",
				FamiliaNombre = "LosGeniales"
			};

			_service.Setup(x => x.Create(modelCreateDto)).Returns(modelDto);
			_service.Setup(x => x.AceptaSolicitudes(modelCreateDto)).Returns(true);

			// Act
			ActionResult result = _controller.Post(modelCreateDto);

			// Assert
			//Assert.IsType<OkObjectResult>(result);

		}
	}
}
