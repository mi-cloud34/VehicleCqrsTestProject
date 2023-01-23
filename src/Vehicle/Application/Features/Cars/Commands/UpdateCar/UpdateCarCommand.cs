using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommand : IRequest<UpdateCarDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

 

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper,CarBusinessRules carBusinessRules)
                                         
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules= carBusinessRules;
        }

        public async Task<UpdateCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            _carBusinessRules.CarNameCanNotBeDuplicatedWhenInserted(request.Name);
            Car mappedCar = _mapper.Map<Car>(request);
            Car updatedCar = await _carRepository.UpdateAsync(mappedCar);
            UpdateCarDto updatedCarDto = _mapper.Map<UpdateCarDto>(updatedCar);
            return updatedCarDto;
        }
    }
}