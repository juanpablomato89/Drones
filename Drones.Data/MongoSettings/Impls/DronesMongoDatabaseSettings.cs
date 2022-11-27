using Drones.Data.MongoSettings.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Data.MongoSettings.Impls
{
    public class DronesMongoDatabaseSettings : IDronesMongoDatabaseSettings
    {
        public string DronesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
