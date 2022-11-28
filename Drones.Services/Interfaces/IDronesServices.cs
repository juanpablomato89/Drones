using Drones.Common.Request.Dron;
using Drones.Common.Request.Medicamento;
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
        Task<Dron> GetByNumerSerieAsync(string numeroSerie);
        Task <Dron> Create(AddDronRequest AddDron);
        Task<Dron> Update(string id, UpdateDronRequest updateDron);
        Task<bool> Remove(string id);
        Task<Dron> GetDronByIdAsync(string id);
        Task<Dron> CargarDronAsync(string numeroSerie, AddMedecamentoRequest medicamento);
        Task<List<Dron>> GetDronsAvaiableAsync();
        Task<int> GetBateryLevelAsync(string numeroSerie);
        Task<decimal> GetLoadWeightlAsync(string numeroSerie);

    }
}
