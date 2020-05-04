using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Controllers;
using MiCanasta.MiCanasta.Model;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MiCanasta_Test
{
    public class UsuarioControllerTest
    {

        [Fact]
        public void PostValidarIngreso_WhenCalled_ReturnedUsuarioAcceso()
        {
            var _service = new Mock<UsuarioService>();
            var _controller = new UsuarioController(_service.Object);

            UsuarioLoginDto UsuarioWrongLogin = new UsuarioLoginDto { Dni = "12345671", Contrasena = "12345674" };
            UsuarioAccesoDto UsuarioResponse = new UsuarioAccesoDto {Dni="NotFound" };
            //
            _service.Setup(x => x.ValidateLogin(UsuarioWrongLogin.Dni,UsuarioWrongLogin.Contrasena)).Returns(UsuarioResponse);
            ActionResult<UsuarioAccesoDto> result = _controller.ValidarIngreso(UsuarioWrongLogin);
            //Assert
            Assert.IsType <NotFoundResult>(UsuarioResponse);
        }
    }
}
