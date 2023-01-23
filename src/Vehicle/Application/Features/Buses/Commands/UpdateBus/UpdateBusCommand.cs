using Application.Features.Buses.Dtos;
using Application.Features.Buses.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Buses.Commands.UpdateBus;

public class UpdateBusCommand : IRequest<UpdateBusDto>
{
    public int Id { get; set; }
    public string Name { get; set; }



    public class UpdateBusCommandHandler : IRequestHandler<UpdateBusCommand, UpdateBusDto>
    {
        private readonly IBusRepository _busRepository;
        private readonly IMapper _mapper;
        private readonly BusBusinessRules _busBusinessRules;

        public UpdateBusCommandHandler(IBusRepository busRepository, IMapper mapper,BusBusinessRules busBusinessRules)

        {
            _busRepository = busRepository;
            _mapper = mapper;
            _busBusinessRules=busBusinessRules;
        }

        public async Task<UpdateBusDto> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
        {
            _busBusinessRules.BusNameCanNotBeDuplicatedWhenInserted(request.Name);
            Bus mappedBus = _mapper.Map<Bus>(request);
            Bus updatedBus = await _busRepository.UpdateAsync(mappedBus);
            UpdateBusDto updatedBusDto = _mapper.Map<UpdateBusDto>(updatedBus);
            return updatedBusDto;
        }
    }
}