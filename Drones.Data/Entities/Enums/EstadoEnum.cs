using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Data.Entities.Enums
{
    public enum EstadoEnum
    {
        INACTIVO = 0,
        CARGANDO = 1,
        CARGADO = 2,
        ENTREGANDO_CARGA = 3,
        CARGA_ENTREGADA = 4,
        REGRESANDO = 5
    }
}
