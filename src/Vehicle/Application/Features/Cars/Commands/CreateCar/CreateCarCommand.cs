using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public partial class CreateCarCommand : IRequest<CreateCarDto>
    {
        public int Wheel { get; set; }
        public bool HeadLight { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }
        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper,CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules= carBusinessRules;
            }

            public async Task<CreateCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
               await  _carBusinessRules.CarNameCanNotBeDuplicatedWhenInserted(request.Name);

                Car mappedCar = _mapper.Map<Car>(request);
                Car createdCar = await _carRepository.AddAsync(mappedCar);
                CreateCarDto createdCarDto = _mapper.Map<CreateCarDto>(createdCar);

                return createdCarDto;

            }
        }

    }
}

