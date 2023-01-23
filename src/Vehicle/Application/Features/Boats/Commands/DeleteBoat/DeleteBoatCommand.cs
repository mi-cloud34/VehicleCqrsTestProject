using Application.Features.Boats.Dtos;
using Application.Features.Boats.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Boats.Commands.DeleteBoat;

public class DeleteBoatCommand : IRequest<DeleteBoatDto>
{
    public int Id { get; set; }


    public class DeleteBoatCommandHandler : IRequestHandler<DeleteBoatCommand, DeleteBoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;
        private readonly BoatBusinessRules _boatBusinessRules;

        public DeleteBoatCommandHandler(IBoatRepository boatRepository, IMapper mapper,BoatBusinessRules boatBusinessRules)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
            _boatBusinessRules = boatBusinessRules;
            
        }

        public async Task<DeleteBoatDto> Handle(DeleteBoatCommand request, CancellationToken cancellationToken)
        {
            _boatBusinessRules.BoatIdShouldExistWhenSelected(request.Id); 
            Boat mappedBoat = _mapper.Map<Boat>(request);
            Boat deletedBoat = await _boatRepository.DeleteAsync(mappedBoat);
            DeleteBoatDto deletedBoatDto = _mapper.Map<DeleteBoatDto>(deletedBoat);
            return deletedBoatDto;
        }
    }
}