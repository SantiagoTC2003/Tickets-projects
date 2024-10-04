using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Tiquete
    {
        public string Codigo { get; set; }
        public DateTime FechaCrea { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Tiquete()
        {
            Codigo = string.Empty;
            FechaCrea = DateTime.MinValue;
            Descripcion = string.Empty;
            Precio = 0;
        }
    }
}
