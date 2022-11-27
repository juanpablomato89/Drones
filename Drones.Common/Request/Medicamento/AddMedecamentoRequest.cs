using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Request.Medicamento
{
    public class AddMedecamentoRequest
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Peso Limite es requerido")]
        [Range(1,500)]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El Codigo es requerido")]
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
