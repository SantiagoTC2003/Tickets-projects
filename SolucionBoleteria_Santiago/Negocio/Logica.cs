using System;
using System.Collections.Generic;
using AccesosDatos;
using Entidades;
using Entidades.MongoDB;

namespace Negocio
{
    public class Logica
    {

        public static bool Agregar(Usuario P_Usuario)
        {
            return AccesoMongoDB.Agregar(P_Usuario);
        }

        public static bool Eliminar(Usuario P_Usuario)
        {
            return AccesoMongoDB.Eliminar(P_Usuario);
        }

        public static bool Modificar(Usuario P_Usuario)
        {
            return AccesoMongoDB.Modificar(P_Usuario);
        }

        public static List<Usuario> Consultar()
        {
            return AccesoMongoDB.Consultar();
        }



    }
}
