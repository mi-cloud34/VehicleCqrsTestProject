using Application.Features.Buses.Models;
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

namespace Application.Features.Buses.Queries.GetListBus
{
    public class GetListBusQuery : IRequest<BusListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBusQueryHandler : IRequestHandler<GetListBusQuery, BusListModel>
        {
            private readonly IBusRepository _busRepository;
            private readonly IMapper _mapper;

            public GetListBusQueryHandler(IBusRepository busRepository, IMapper mapper)
            {
                _busRepository = busRepository;
                _mapper = mapper;
            }

            public async Task<BusListModel> Handle(GetListBusQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Bus> buss = await _busRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                BusListModel mappedBusListModel = _mapper.Map<BusListModel>(buss);

                return mappedBusListModel;
            }
        }
    }
}
