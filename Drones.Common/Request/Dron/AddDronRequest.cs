using Drones.Data.Entities.Enums;
using Drones.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drones.Common.Request.Medicamento;
using System.ComponentModel.DataAnnotations;

namespace Drones.Common.Request.Dron
{
    public class AddDronRequest
    {

        [Required(ErrorMessage = "El numero de serie es requerido")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "El numero de serie no puede exceder los 100 caracteres")]
        [Display(Name = "Numero de Serie")]
        public string NumeroSerie { get; set; }

        public ModeloEnum Modelo { get; set; }

        [Required(ErrorMessage = "El Peso Limite es requerido")]
        [Range(0,500, ErrorMessage = "El Peso Limite no puede exceder los 500gr")]
        [Display(Name = "Peso Limite")]
        public decimal PesoLimite { get; set; }

        [Required(ErrorMessage = "La Carga de la Bateria es requerido")]
        [Range(0,100, ErrorMessage = "La Carga de la Bateria debe estar en el Rango de 0% hasta el 100% ")]
        public int CapacidadBateria { get; set; }
        public EstadoEnum Estado { get; set; }
    }
}
