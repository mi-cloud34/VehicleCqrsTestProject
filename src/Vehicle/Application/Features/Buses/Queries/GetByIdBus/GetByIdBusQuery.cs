using Application.Features.Buses.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Buses.Queries.GetByIdBus;

public class GetByIdBusQuery : IRequest<BusDto>
{
    public int Id { get; set; }

    public class GetByIdBusQueryHandler : IRequestHandler<GetByIdBusQuery, BusDto>
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;

        public GetByIdBusQueryHandler(IBusRepository busRepository,
                                        IMapper mapper)
        {
            _busRepository = busRepository;
            _mapper = mapper;
        }


        public async Task<BusDto> Handle(GetByIdBusQuery request, CancellationToken cancellationToken)
        {

            Bus? Bus = await _busRepository.GetAsync(b => b.Id == request.Id);
            BusDto BusDto = _mapper.Map<BusDto>(Bus);
            return BusDto;
        }
    }
}