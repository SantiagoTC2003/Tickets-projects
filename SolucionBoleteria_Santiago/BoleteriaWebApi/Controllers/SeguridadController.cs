using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negocio;
using Entidades.MongoDB;

namespace BoleteriaWebApi.Controllers
{
    [ApiController]
    [Route("api/Seguridad")]
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(AgregarUsuario))]
        public bool AgregarUsuario(Usuario P_Usuario)
        {
            return Logica.Agregar(P_Usuario);
        }

        [HttpPost]
        [Route(nameof(EliminarUsuario))]
        public bool EliminarUsuario(Usuario P_Usuario)
        {
            return Logica.Eliminar(P_Usuario);
        }

        [HttpPost]
        [Route(nameof(ModificarUsuario))]
        public bool ModificarUsuario(Usuario P_Usuario)
        {
            return Logica.Modificar(P_Usuario);
        }

        [HttpGet]
        [Route(nameof(ConsultarUsuario))]
        public List<Usuario> ConsultarUsuario()
        {
            return Logica.Consultar();
        }
    }
}
