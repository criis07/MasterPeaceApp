using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO;
using Project4.Application.Interfaces.Persistence.DataServices.Users.Queries;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.MarcasAutos.Queries
{
    public class MarcasAutosQueryHandler : IRequestHandler<MarcasAutosQuery, EndpointResult<IEnumerable<MarcasAutosDTO>>>
    {
        public readonly IMarcasAutosService _marcasAutosService;
        public readonly IMapper _mapper;

        public MarcasAutosQueryHandler(IMarcasAutosService marcasAutosService, IMapper mapper)
        {
            _marcasAutosService = marcasAutosService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<IEnumerable<MarcasAutosDTO>>> Handle(MarcasAutosQuery request, CancellationToken cancellationToken)
        {
            var autos = await _marcasAutosService.GetAllMarcasAutos();

            var autosDto = _mapper.Map<MarcasAutosDTO[]>(autos);

            return new EndpointResult<IEnumerable<MarcasAutosDTO>>(autosDto);
        }
    }
}
