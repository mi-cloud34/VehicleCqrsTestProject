using Application.Features.Buses.Dtos;
using Application.Features.Buses.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Buses.Commands.DeleteBus;

public class DeleteBusCommand : IRequest<DeleteBusDto>
{
    public int Id { get; set; }


    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusCommand, DeleteBusDto>
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;
        private readonly BusBusinessRules _busBusinessRules;


        public DeleteBusCommandHandler(IBusRepository busRepository, IMapper mapper,BusBusinessRules busBusinessRules)
        {
            _busRepository = busRepository;
            _mapper = mapper;
            _busBusinessRules=busBusinessRules;
        }

        public async Task<DeleteBusDto> Handle(DeleteBusCommand request, CancellationToken cancellationToken)
        {
            _busBusinessRules.BusIdShouldExistWhenSelected(request.Id);
            Bus mappedBus = _mapper.Map<Bus>(request);
            Bus deletedBus = await _busRepository.DeleteAsync(mappedBus);
            DeleteBusDto deletedBusDto = _mapper.Map<DeleteBusDto>(deletedBus);
            return deletedBusDto;
        }
    }
}