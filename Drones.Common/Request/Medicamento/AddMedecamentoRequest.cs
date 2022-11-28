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
        [RegularExpression(@"^[a-zA-Z-_''-'\s]{1,}$", ErrorMessage = "Solo Letras y - _.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Peso Limite es requerido")]
        [Range(1,500)]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El Codigo es requerido")]
        [RegularExpression(@"^[0-9A-Z_''-'\s]{1,}$", ErrorMessage = "Solo Letras Mayusculuas, números, y _.")]
        public string Codigo { get; set; }
        public string Imagen { get; set; }
    }
}
