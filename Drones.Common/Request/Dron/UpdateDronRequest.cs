using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Common.Request.Dron
{
    public class UpdateDronRequest : AddDronRequest
    {
        public string Id { get; set; }
    }
}
