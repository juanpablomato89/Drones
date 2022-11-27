using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Request.Medicamento
{
    public class UpdateMedicamentoRequest: AddMedecamentoRequest
    {
        public int Id { get; set; }
    }
}
