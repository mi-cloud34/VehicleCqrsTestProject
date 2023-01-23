
using Application.Features.Cars.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetByIdCar;

public class GetByIdCarQuery : IRequest<CarDto>
{
    public int Id { get; set; }

    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
      
        public GetByIdCarQueryHandler(ICarRepository carRepository,
                                        IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<CarDto> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            
            Car? car = await _carRepository.GetAsync(b => b.Id == request.Id);
            CarDto carDto = _mapper.Map<CarDto>(car);
            return carDto;
        }
    }
}