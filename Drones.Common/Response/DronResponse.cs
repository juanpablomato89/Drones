using Drones.Data.Entities.Enums;
using Drones.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Response
{
    public class DronResponse
    {
        public DronResponse()
        {
            Medicamentos = new HashSet<MedicamentoResponse>();
        }
        public string Id { get; set; }
        public string NumeroSerie { get; set; }
        public ModeloEnum Modelo { get; set; }
        public decimal PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public EstadoEnum Estado { get; set; }
        public ICollection<MedicamentoResponse> Medicamentos { get; set; }
    }
}
