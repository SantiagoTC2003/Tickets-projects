using System;

namespace Entidades
{
    public class TipoEvento
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }

        public TipoEvento()
        {
            Codigo = 0;
            Descripcion = string.Empty;
            Disponible = true;
        }
    }
}
