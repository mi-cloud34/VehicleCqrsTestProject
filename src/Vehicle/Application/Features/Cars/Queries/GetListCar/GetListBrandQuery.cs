using Application.Features.Boats.Profiles;
using Application.Features.Cars.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetListCar
{
    public class GetListCarQuery : IRequest<CarListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, CarListModel>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetListCarQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Car> Cars = await _carRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CarListModel mappedCarListModel = _mapper.Map<CarListModel>(Cars);

                return mappedCarListModel;
            }
        }
    }
}
