using AutoMapper;
using Drones.Common.Request.Dron;
using Drones.Common.Request.Medicamento;
using Drones.Common.Static;
using Drones.Data.Entities;
using Drones.Data.Entities.Enums;
using Drones.Data.MongoSettings.Interface;
using Drones.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp;

namespace Drones.Services.Impls
{
    public class DronesServices: IDronesServices
    {
        private readonly IMongoCollection<Dron> _DronesServices;
        private readonly IMapper _mapper;
        public DronesServices(IDronesMongoDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _DronesServices = database.GetCollection<Dron>(settings.DronesCollectionName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<List<Dron>> Get() 
        { 
           var drones = await _DronesServices.Find(dron => true).ToListAsync();
            return drones;
        }
        public async Task<Dron> GetByNumerSerieAsync(string numeroSerie) =>
            await _DronesServices.Find(d => d.NumeroSerie.Equals(numeroSerie)).FirstOrDefaultAsync();

        public async Task<Dron> GetDronByIdAsync(string id) =>
            await _DronesServices.Find(d => d.Id == id).FirstOrDefaultAsync();


        public async Task<Dron> Create(AddDronRequest AddDron)
        {
            var dronExist = await GetByNumerSerieAsync(AddDron.NumeroSerie);

            if (dronExist != null) throw new Exception("Ya existe un dron con ese numero de serie");

            var dron = _mapper.Map<Dron>(AddDron);
            await _DronesServices.InsertOneAsync(dron);
            return dron;
        }
        public async Task<Dron> Update(string id, UpdateDronRequest updateDron)
        {
            var dron = _mapper.Map<Dron>(updateDron);
            await _DronesServices.ReplaceOneAsync(d => d.Id == id, dron);
            return dron;
        }

        private async Task UpdateMedicamentos(string id, UpdateDefinition<Dron> update)
        {
            await _DronesServices.UpdateOneAsync(x => x.Id == id, update);
        }

        public async Task<bool> Remove(string id)
        {
            if (!MetodosAuxiliares.ValidateString(id) || GetDronByIdAsync(id) is null) return false;

            await _DronesServices.DeleteOneAsync(d => d.Id == id);

            return true;
        }

        public async Task<Dron> CargarDronAsync(string numeroSerie, AddMedecamentoRequest medicamento)
        {
            if (!MetodosAuxiliares.ValidateString(numeroSerie))
                throw new Exception("EL numero de serie es incorrecto");

            var dron = await GetByNumerSerieAsync(numeroSerie);

            if (dron is null)
            {
                throw new Exception("EL numero de serie no existe");
            }

            var pesoTotal = dron.Medicamentos.Sum(s => s.Peso) + medicamento.Peso;

            if (pesoTotal > dron.PesoLimite)
            {
                throw new Exception("No podemos cargar el nuevo medicamento, pues sobre pasa el Limite de Carga del Dron");
            }

            if (dron.Estado == EstadoEnum.CARGANDO && dron.CapacidadBateria > 25)
            {
                var medicamentoResult = _mapper.Map<Medicamento>(medicamento);
                UpdateDefinition<Dron> update = Builders<Dron>.Update
                    .Set(d => d.Estado, EstadoEnum.CARGADO)
                    .Push(u => u.Medicamentos, medicamentoResult);
                await UpdateMedicamentos(dron.Id, update);
            }
            else
            {
                throw new Exception("El Dron no esta listo para cargar nuevos medicamentos");
            }

            return await GetByNumerSerieAsync(numeroSerie);
        }

        public async Task<List<Dron>> GetDronsAvaiableAsync()
        {
            var drons = await _DronesServices.Find(d => d.CapacidadBateria > 25 && d.Estado == EstadoEnum.CARGANDO).ToListAsync();

            return drons;
        }

        public async Task<int> GetBateryLevelAsync(string numeroSerie)
        {
            var data = _DronesServices.Aggregate();
            var a1 =
                data.Project(
                    x =>
                    new
                    {
                        id = x.Id,
                        bateryLevel = x.CapacidadBateria,
                        IsTrue = x.NumeroSerie.ToLower().Equals(numeroSerie.ToLower().Trim())
                    }
                    );
            var a2 = a1.Match(x => x.IsTrue);
            var result = await a2.FirstOrDefaultAsync();

            if (result != null)
            {
                return result.bateryLevel;
            }

            return -1;            
        }

        public async Task<decimal> GetLoadWeightlAsync(string numeroSerie)
        {
            var data = _DronesServices.Aggregate();
            var a1 =
                data.Project(
                    x =>
                    new
                    {
                        Id = x.Id,
                        Medicamentos = x.Medicamentos,
                        IsTrue = x.Medicamentos.Any()
                    }
                    ); ;
            var a2 = a1.Match(x => x.IsTrue);
            var result = await a2.FirstOrDefaultAsync();

            if (result != null)
            {
                var weightTotal = result.Medicamentos.Sum(d => d.Peso);
                return weightTotal;
            }

            return -1;
        }
    }
}
