using AutoMapper;
using Drones.Common.Request.Dron;
using Drones.Data.Entities;
using Drones.Data.MongoSettings.Interface;
using Drones.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Dron>> Get(string numeroSerie) =>
            await _DronesServices.Find(d => d.NumeroSerie == numeroSerie).ToListAsync();
        public async Task<Dron> Create(AddDronRequest AddDron)
        {
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

    }
}
