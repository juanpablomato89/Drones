using AutoMapper;
using Drones.Common.Request.Dron;
using Drones.Common.Request.Medicamento;
using Drones.Common.Response;
using Drones.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Drones.API.Controllers
{
    [Route("api/dron")]
    [ApiController]
    public class DronController : Controller
    {
        private readonly IDronesServices _dronesServices;
        private readonly IMapper _mapper;

        public DronController(IDronesServices dronesServices, IMapper mapper)
        {
            _dronesServices = dronesServices ?? throw new ArgumentNullException(nameof(dronesServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<DronResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAync()
        {
            var drones = await _dronesServices.Get();
            var result = _mapper.Map<DronResponse>(drones);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(DronResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddAsync([FromBody] AddDronRequest addDrones)
        {
           var dronesResult =  await _dronesServices.Create(addDrones);
            var result = _mapper.Map<DronResponse>(dronesResult);
            return Created("OK", result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _dronesServices.Remove(id);
            return Ok(result);
        }

        [HttpPut("cargar-dron/{numeroserie}")]
        [ProducesResponseType(typeof(DronResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CargarDronAsync([FromRoute]string numeroserie, [FromBody]AddMedecamentoRequest medicamento)
        {
            var result = await _dronesServices.CargarDronAsync(numeroserie, medicamento );
            var dronResult = _mapper.Map<DronResponse>(result);
            return Ok(dronResult);
        }

        [HttpGet("drons-avaiable")]
        [ProducesResponseType(typeof(List<DronResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CargarDronAsync()
        {
            var result = await _dronesServices.GetDronsAvaiableAsync();
            var dronResult = _mapper.Map<List<DronResponse>>(result);
            return Ok(dronResult);
        }

        [HttpGet("batery-level/{numeroSerie}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBateryLevelAsync([FromRoute]string numeroSerie)
        {
            var result = await _dronesServices.GetBateryLevelAsync(numeroSerie);

            if (result == -1)
            {
                return BadRequest("El Dron No existe");
            }

            return Ok(result);
        }

        [HttpGet("load-Weightl/{numeroSerie}")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLoadWeightlAsync([FromRoute] string numeroSerie)
        {
            var result = await _dronesServices.GetLoadWeightlAsync(numeroSerie);
            if (result == -1)
            {
                return BadRequest("El Dron No existe");
            }

            return Ok(result);
        }
    }
}
