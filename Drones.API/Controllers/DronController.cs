using AutoMapper;
using Drones.Common.Request.Dron;
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
    }
}
