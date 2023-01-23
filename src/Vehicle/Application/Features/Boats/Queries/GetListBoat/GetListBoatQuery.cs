using Application.Features.Boats.Models;
using Application.Features.Boats.Profiles;
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

namespace Application.Features.Boats.Queries.GetListBoat
{
    public class GetListBoatQuery : IRequest<BoatListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBoatQueryHandler : IRequestHandler<GetListBoatQuery, BoatListModel>
        {
            private readonly IBoatRepository _boatRepository;
            private readonly IMapper _mapper;

            public GetListBoatQueryHandler(IBoatRepository boatRepository, IMapper mapper)
            {
                _boatRepository = boatRepository;
                _mapper = mapper;
            }

            public async Task<BoatListModel> Handle(GetListBoatQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Boat> Boats = await _boatRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                BoatListModel mappedBoatListModel = _mapper.Map<BoatListModel>(Boats);

                return mappedBoatListModel;
            }
        }
    }
}
