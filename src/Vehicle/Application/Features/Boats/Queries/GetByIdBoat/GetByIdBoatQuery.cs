
using Application.Features.Boats.Dtos;
using Application.Features.Buses.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Boats.Queries.GetByIdBoat;

public class GetByIdBoatQuery : IRequest<BoatDto>
{
    public int Id { get; set; }

    public class GetByIdBoatQueryHandler : IRequestHandler<GetByIdBoatQuery, BoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;
      
        public GetByIdBoatQueryHandler(IBoatRepository boatRepository,
                                        IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }


        public async Task<BoatDto> Handle(GetByIdBoatQuery request, CancellationToken cancellationToken)
        {
            
            Boat? Boat = await _boatRepository.GetAsync(b => b.Id == request.Id);
            BoatDto boatDto = _mapper.Map<BoatDto>(Boat);
            return boatDto;
        }
    }
}