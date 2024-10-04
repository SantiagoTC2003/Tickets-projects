using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces
{
    public interface IBoleteriaVentaLN
    {
        public bool VentaBoleto(Venta P_Venta);
    }
}
