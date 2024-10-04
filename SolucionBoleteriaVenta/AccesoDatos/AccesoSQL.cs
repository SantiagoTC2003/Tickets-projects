using AccesoDatos.Interfaces;
using Dapper;
using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AccesoSQL : IAccesoSQL
    {
        #region Miembro 
        private readonly IConfiguration _iConfiguration;

        #endregion

        #region Constructor
        public AccesoSQL(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }
        
        #endregion

        #region Metodos

        public bool AgregarVenta(Venta P_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@NumFactura", P_Entidad.NumeroFactura, DbType.String, ParameterDirection.Input, 50);
            parametros.Add("@NumAsiento", P_Entidad.NumeroAsiento, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@FechaVenta", P_Entidad.Fecha, DbType.DateTime, ParameterDirection.Input);
            parametros.Add("@CodTiquete", P_Entidad.Tiquete.Codigo, DbType.String, ParameterDirection.Input, 50);
            parametros.Add("@CodEvento", P_Entidad.Evento.Codigo, DbType.Int32, ParameterDirection.Input);

            using (var conexionSQLServer = new SqlConnection(_iConfiguration.GetConnectionString("ConexionSQL")))
            {
                return conexionSQLServer.Execute("PA_AgregarVenta", parametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }
        public bool ModificarDisponibilidadEvento(Evento P_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodEvento", P_Entidad.Codigo, DbType.Int32, ParameterDirection.Input);            
            parametros.Add("@Disponibles", P_Entidad.Disponibles, DbType.Int32, ParameterDirection.Input);

            using (var conexionSQLServer = new SqlConnection(_iConfiguration.GetConnectionString("ConexionSQL")))
            {
                return conexionSQLServer.Execute("PA_ModificarDisponibilidadEvento", parametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }
        public List<Evento> ConsultarEvento(Evento P_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodEvento", P_Entidad.Codigo, DbType.Int32, ParameterDirection.Input);

            using (var conexionSQLSever = new SqlConnection(_iConfiguration.GetConnectionString("ConexionSQL")))
            {
                return (List<Evento>)conexionSQLSever.Query<Evento>("PA_ConsultarEvento", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}
