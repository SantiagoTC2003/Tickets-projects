using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.MongoDB;
using MongoDB.Driver;

namespace AccesosDatos
{
    public class AccesoMongoDB
    {

        #region Atributos

        //Aqui se crea el string de conexion con MongoDB
        //Por seguridad, esta informacion deberia venir en el archivo de configuracion e inluso encriptada
        private static readonly string CadenaConexion = @"mongodb+srv://santiagotc0710:Bahamut953@cluster0.ijfx6fo.mongodb.net/Seguridad?retryWrites=true&w=majority";

        //Crear instancia para conectar a la base de datos
        private static MongoClient InstanciaBD;
        private static IMongoDatabase BaseDatos;

        //Crear una constante con el nombre de la base de datos
        private const string NombreBD = "Seguridad";

        #endregion

        #region Metodos

        #region Privados

        private static void EstablecerConexion()
        {
            try
            {

                //Inicializan las variables de instancia y base de datos
                InstanciaBD = new MongoClient(CadenaConexion);
                BaseDatos = InstanciaBD.GetDatabase(NombreBD);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Publicos

        /// <summary>
        /// Metodo para agregar un usuario en MongoDB
        /// </summary>
        /// <param name="P_Usuario">Entidad de tipo Usuario</param>
        /// <returns>True = Correcto | False = Error</returns>
        public static bool Agregar(Usuario P_Usuario)
        {
            bool Resultado = false;

            try
            {
                EstablecerConexion();

                //Se crea un objeto con el resultado de la base de datos de donde se obtiene la coleccion que se busca
                var Coleccion = BaseDatos.GetCollection<Usuario>("Usuario");

                //Ejecuta la accion
                Coleccion.InsertOne(P_Usuario);
                Resultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return Resultado;
        }

        /// <summary>
        /// Metodo para eliminar un usuario en MongoDB
        /// </summary>
        /// <param name="P_Usuario">Entidad de tipo Usuario</param>
        /// <returns>True = Correcto | False = Error</returns>
        public static bool Eliminar(Usuario P_Usuario)
        {
            bool Resultado = false;

            try
            {
                EstablecerConexion();

                //Se crea un objeto con el resultado de la base de datos de donde se obtiene la coleccion que se busca
                var Coleccion = BaseDatos.GetCollection<Usuario>("Usuario");

                //Ejecuta la accion
                Coleccion.DeleteOne(documento => documento.ID.Equals(P_Usuario.ID));
                Resultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return Resultado;
        }

        /// <summary>
        /// Metodo para modificar un usuario en MongoDB
        /// </summary>
        /// <param name="P_Usuario">Entidad de tipo Usuario</param>
        /// <returns>True = Correcto | False = Error</returns>
        public static bool Modificar(Usuario P_Usuario)
        {
            bool Resultado = false;

            try
            {
                EstablecerConexion();

                //Se crea un objeto con el resultado de la base de datos de donde se obtiene la coleccion que se busca
                var Coleccion = BaseDatos.GetCollection<Usuario>("Usuario");

                //Ejecuta la accion
                Coleccion.ReplaceOne(documento => documento.ID.Equals(P_Usuario.ID), P_Usuario);
                Resultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return Resultado;
        }

        /// <summary>
        /// Metodo para obtener los usuarios registrados en la base de datos
        /// </summary>
        /// <returns>Entidad lista de tipo usuario</returns>
        public static List<Usuario> Consultar()
        {
            try
            {
                EstablecerConexion();

                //Se crea un objeto con el resultado de la base de datos de donde se obtiene la coleccion que se busca
                var Coleccion = BaseDatos.GetCollection<Usuario>("Usuario");

                //Ejecuta la accion y retornar resultado
                return Coleccion.Find(documento => true).ToList().OrderBy(orden => orden.NombreUsuario).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }

        #endregion

        #endregion

    }
}
