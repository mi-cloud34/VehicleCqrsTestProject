
using Application.Features.Boats.Dtos;
using Application.Features.Boats.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Boats.Commands.UpdateBoat;

public class UpdateBoatCommand : IRequest<UpdateBoatDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

 

    public class UpdateBoatCommandHandler : IRequestHandler<UpdateBoatCommand, UpdateBoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;
        private readonly BoatBusinessRules _boatBusinessRules;

        public UpdateBoatCommandHandler(IBoatRepository boatRepository, IMapper mapper,BoatBusinessRules boatBusinessRules)
                                         
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
             _boatBusinessRules=boatBusinessRules;
        }

        public async Task<UpdateBoatDto> Handle(UpdateBoatCommand request, CancellationToken cancellationToken)
        {
            _boatBusinessRules.BoatNameCanNotBeDuplicatedWhenInserted(request.Name);
            Boat mappedBoat = _mapper.Map<Boat>(request);
            Boat updatedBoat = await _boatRepository.UpdateAsync(mappedBoat);
            UpdateBoatDto updatedBoatDto = _mapper.Map<UpdateBoatDto>(updatedBoat);
            return updatedBoatDto;
        }
    }
}