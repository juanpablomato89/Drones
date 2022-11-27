using AutoMapper;
using Drones.Common.Request.Dron;
using Drones.Common.Request.Medicamento;
using Drones.Common.Response;
using Drones.Data.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Net;

namespace Drones.API.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddDronRequest, Dron>()
                .ForMember(d => d.Estado, opts => opts.MapFrom(source => source.Estado))
                .ForMember(d => d.NumeroSerie, opts => opts.MapFrom(source => source.NumeroSerie))
                .ForMember(d => d.PesoLimite, opts => opts.MapFrom(source => source.PesoLimite))
                .ForMember(d => d.CapacidadBateria, opts => opts.MapFrom(source => source.CapacidadBateria))
                .ForMember(d => d.Medicamentos, opts => opts.MapFrom(source => source.Medicamentos));

            CreateMap<Dron, DronResponse>();
            CreateMap<Medicamento, MedicamentoResponse>();

            CreateMap<AddMedecamentoRequest, Medicamento>()
                .ForMember(d => d.Peso, opts => opts.MapFrom(source => source.Peso))
                .ForMember(d => d.Nombre, opts => opts.MapFrom(source => source.Nombre))
                .ForMember(d => d.Codigo, opts => opts.MapFrom(source => source.Codigo))
                .ForMember(d => d.Imagen, opts => opts.MapFrom(source => source.Imagen));
        }

    }
}