using AccesoDatos.Interfaces;
using Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Negocio
{      
    public class BoleteriaVentaLN : IBoleteriaVentaLN
    {
        #region Miembro
        private readonly IAccesoSQL _iAccesoSQL;

        #endregion

        #region Propiedades
        private TransactionOptions TransaccionOptions { get; set; }

        #endregion

        #region Constructor

        public BoleteriaVentaLN(IAccesoSQL iAccesoSQL)
        {
            _iAccesoSQL = iAccesoSQL;
            TransaccionOptions = new TransactionOptions { Timeout = TransactionManager.DefaultTimeout, IsolationLevel = IsolationLevel.ReadUncommitted };
        }

        #endregion

        #region Metodos

        public bool VentaBoleto(Venta P_Venta)
        {
            bool resultado = false;

            //Aqui se inicia la transacción de las operaciones por ejecutarse
            using (TransactionScope objtransacion = new TransactionScope(TransactionScopeOption.Required, TransaccionOptions))
            {
                if(_iAccesoSQL.AgregarVenta(P_Venta)) //Si la ejecucion de guardar la venta fue correcta
                {
                    Evento objeventoconsulta = new Evento { Codigo = P_Venta.Evento.Codigo };

                    List<Evento> lstresultado = _iAccesoSQL.ConsultarEvento(objeventoconsulta); //Se obtiene la informacion general del evento
                    if(lstresultado != null && lstresultado.Count > 0) //Si encontro resultados 
                    {
                        Evento objevento = new Evento
                        {
                            Codigo = P_Venta.Evento.Codigo,
                            Disponibles = lstresultado.FirstOrDefault().Disponibles - P_Venta.NumeroAsiento //Aqui se obtiene el resultado de asientos restantes para el evento
                        };

                        if(_iAccesoSQL.ModificarDisponibilidadEvento(objevento)) //Si la modificación de espacios disponibles fue correcta                        
                            resultado = true;                        
                    }
                }

                if (resultado) //Si resultado es TRUE, quiere indicar que todo se realizo correctamente
                    objtransacion.Complete(); //Aplica los cambios en BD Real
            }

            return resultado;
        }

        #endregion
    }
}
