using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Venta
    {
        public string NumeroFactura { get; set; }
        public int NumeroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public Tiquete Tiquete { get; set; }
        public Evento Evento { get; set; }

        public Venta()
        {
            NumeroFactura = string.Empty;
            NumeroAsiento = 0;
            Fecha = DateTime.MinValue;
            Tiquete = new Tiquete();
            Evento = new Evento();
        }
    }
}
