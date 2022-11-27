using Drones.Data.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Data.Entities
{
    public class Dron
    {
        public Dron()
        {
            Medicamentos = new HashSet<Medicamento>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NumeroSerie { get; set; }
        public ModeloEnum Modelo { get; set; }
        public decimal PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public EstadoEnum Estado { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
