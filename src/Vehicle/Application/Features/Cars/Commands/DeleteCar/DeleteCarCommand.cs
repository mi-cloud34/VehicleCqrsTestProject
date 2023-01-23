using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;


namespace Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommand : IRequest<DeleteCarDto>
{
    public int Id { get; set; }


    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper,CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules= carBusinessRules;
        }

        public async Task<DeleteCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            _carBusinessRules.CarIdShouldExistWhenSelected(request.Id);
            Car mappedCar = _mapper.Map<Car>(request);
            Car deletedCar = await _carRepository.DeleteAsync(mappedCar);
            DeleteCarDto deletedCarDto = _mapper.Map<DeleteCarDto>(deletedCar);
            return deletedCarDto;
        }
    }
}