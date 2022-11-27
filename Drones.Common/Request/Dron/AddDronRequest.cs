using Drones.Data.Entities.Enums;
using Drones.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drones.Common.Request.Medicamento;

namespace Drones.Common.Request.Dron
{
    public class AddDronRequest
    {
        public AddDronRequest()
        {
            Medicamentos = new HashSet<AddMedecamentoRequest>();
        }
        public string NumeroSerie { get; set; }
        public ModeloEnum Modelo { get; set; }
        public decimal PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public EstadoEnum Estado { get; set; }
        public ICollection<AddMedecamentoRequest> Medicamentos { get; set; }
    }
}
