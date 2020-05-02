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

		SolicitudController _controller;
		SolicitudService _service;

		public SolicitudControllerTest()
		{
			_service = new SolicitudServiceImpl();
			_controller = new SolicitudController(_service);
		}


		//Si la familia no existe
		[Fact]
		public void Add_InvalidObjectPassed_ReturnNotFound()
		{
			/* _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);*/

			// Arrange
			SolicitudCreateDto model = new SolicitudCreateDto
			{
				Dni = "76697297",
				FamiliaNombre = "Los pinguinos
			};

			// Act
			ActionResult result = _controller.Create(model);

			// Assert
			Assert.IsType<NotFoundObjectResult>(result);
		}


		//Si la familia no acepta solicitudes
		[Fact]
		public void Add_ValidObjectPassed_ReturnBadRequest()
		{
			/* _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);*/

			// Arrange
			SolicitudCreateDto model = new SolicitudCreateDto
			{
				Dni = "76697298",
				FamiliaNombre = "Los Pollitos"
			};


			// Act
			ActionResult result = _controller.Create(model);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}


		//Flujo normal
		[Fact]
		public void Add_ValidObjectPassed_ReturnOk()
		{
			/* _service = new Mock<SolicitudService>();
			var _controller = new SolicitudController(_service.Object);*/

			// Arrange
			SolicitudCreateDto model = new SolicitudCreateDto
			{
				Dni = "15665105",
				FamiliaNombre = "LosGeniales"
			};

			// Act
			ActionResult result = _controller.Create(model);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}
	}
}
