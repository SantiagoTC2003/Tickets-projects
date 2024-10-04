using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Evento
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int Capacidad { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public int Disponibles { get; set; }

        public Evento()
        {
            Codigo = 0;
            Fecha = DateTime.MinValue;
            Capacidad = 0;
            TipoEvento = new TipoEvento();
            Disponibles = 0;
        }
    }
}
