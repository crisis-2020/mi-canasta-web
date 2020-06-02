using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MiCanasta_Test
{
    public class ObtenerSolicitudControllerTest
    {

        [Fact]
        public void GetByDniTest_ReturnNotFound()
        {
            var _service = new Mock<SolicitudService>();
            var _controller = new SolicitudController(_service.Object);


            //// Arrange
            SolicitudBusquedaDto modelBusquedaDto = new SolicitudBusquedaDto
            {
                Dni = "123",
            };
            SolicitudBusquedaDto obj = null;
            
           _service.Setup(x => x.ObtenerNombreFamilia("123")).Returns(obj);


            // Act
            ActionResult result = _controller.GetById("123");
                  
            //Assert.IsType<NotFoundObjectResult>(result);
        }

        //Flujo normal
        [Fact]
        public void GetByDniTest_ReturnOk()
        {
            var _service = new Mock<SolicitudService>();
            var _controller = new SolicitudController(_service.Object);


            //// Arrange
            SolicitudBusquedaDto modelBusquedaDto = new SolicitudBusquedaDto
            {
                Dni = "123",
            };
            
            

            _service.Setup(x => x.ObtenerNombreFamilia("123")).Returns(modelBusquedaDto);


            // Act
            ActionResult result = _controller.GetById("123");

            Assert.IsType<OkObjectResult>(result);
        }

    };
}
