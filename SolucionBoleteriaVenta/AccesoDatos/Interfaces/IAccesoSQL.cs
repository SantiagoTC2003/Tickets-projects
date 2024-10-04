using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Interfaces
{
    public interface IAccesoSQL
    {
        bool AgregarVenta(Venta P_Entidad);
        bool ModificarDisponibilidadEvento(Evento P_Entidad);
        List<Evento> ConsultarEvento(Evento P_Entidad);
    }
}
