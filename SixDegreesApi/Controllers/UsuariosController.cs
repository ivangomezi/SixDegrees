using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SixDegressDatos;
using SixDegreesEntidades;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SixDegreesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosDatos _usuariosDatos;
        public UsuariosController(UsuariosDatos usuariosDatos)
        {
            this._usuariosDatos = usuariosDatos ?? throw new ArgumentNullException(nameof(usuariosDatos));
        }

        // GET api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            try
            {
                var response = await _usuariosDatos.Get();
                if (response == null) { return NotFound(); }
                return response;
            }
            catch (Exception ex)
            {

                List<Usuarios> obj = new List<Usuarios>();
                Usuarios us = new Usuarios();
                us.error = ex.Message.ToString();
                obj.Add(us);
                return obj;
            }

        }
    }
}
