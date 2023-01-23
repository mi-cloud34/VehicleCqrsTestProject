using Application.Features.Buses.Dtos;
using Application.Features.Buses.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Buses.Commands.CreateBus
{
    public partial class CreateBusCommand : IRequest<CreateBusDto>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }
        public class CreateBusCommandHandler : IRequestHandler<CreateBusCommand, CreateBusDto>
        {
            private readonly IBusRepository _busRepository;
            private readonly IMapper _mapper;
            private readonly BusBusinessRules _busBusinessRules;


            public CreateBusCommandHandler(IBusRepository busRepository, IMapper mapper,BusBusinessRules busBusinessRules)
            {
                _busRepository = busRepository;
                _mapper = mapper;
                _busBusinessRules = busBusinessRules;
            }

            public async Task<CreateBusDto> Handle(CreateBusCommand request, CancellationToken cancellationToken)
            {

              await  _busBusinessRules.BusNameCanNotBeDuplicatedWhenInserted(request.Name);
                Bus mappedBus = _mapper.Map<Bus>(request);
                Bus createdBus = await _busRepository.AddAsync(mappedBus);
                CreateBusDto createdBusDto = _mapper.Map<CreateBusDto>(createdBus);

                return createdBusDto;

            }
        }

    }
}
