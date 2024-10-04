using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoleteriaVenta.Controllers
{
    [ApiController]
    [Route("api/BoleteriaVenta")]
    public class BoleteriaVentaController : Controller
    {
        private readonly IBoleteriaVentaLN _iBoleteriaVentaLN;

        public BoleteriaVentaController(IBoleteriaVentaLN iBoleteriaVentaLN)
        {
            _iBoleteriaVentaLN = iBoleteriaVentaLN;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(VentaBoleto))]
        public bool VentaBoleto([FromBody]Venta P_Venta)
        {
            return _iBoleteriaVentaLN.VentaBoleto(P_Venta);
        }

    }
}
