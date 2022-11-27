using Drones.Common.Request.Dron;
using Drones.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Services.Interfaces
{
    public interface IDronesServices
    {
        Task<List<Dron>> Get();
        Task<List<Dron>> Get(string numeroSerie);
        Task<Dron> Create(AddDronRequest AddDron);
        Task<Dron> Update(string id, UpdateDronRequest updateDron);

    }
}
