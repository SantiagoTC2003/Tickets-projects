using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entidades.MongoDB
{
    public class Usuario
    {

        #region Propiedades

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("user")]
        public string NombreUsuario { get; set; }
        [BsonElement("pass")]
        public string Clave { get; set; }
        [BsonElement("state")]
        public bool Estado { get; set; }

        #endregion

        #region Constructor

        public Usuario()
        {
            ID = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Estado = true;
        }

        #endregion

    }
}
