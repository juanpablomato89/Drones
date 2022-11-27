using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Request.Medicamento
{
    public class AddMedecamentoRequest
    {
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
