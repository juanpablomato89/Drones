using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Static
{
    public static class MetodosAuxiliares
    {
        public static bool ValidateString(string cadema)
        {
            if (String.IsNullOrEmpty(cadema) || String.IsNullOrWhiteSpace(cadema))
            {
                return false;
            }

            return true;
        }
    }
}
