
using Application.Features.Boats.Dtos;
using Application.Features.Boats.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Boats.Commands.CreateBoat
{
    public partial class CreateBoatCommand : IRequest<CreateBoatDto>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }
        public class CreateBoatCommandHandler : IRequestHandler<CreateBoatCommand, CreateBoatDto>
        {
            private readonly IBoatRepository _boatRepository;
            private readonly IMapper _mapper;
            private readonly BoatBusinessRules _boatBusinessRules;
           

            public CreateBoatCommandHandler(IBoatRepository boatRepository, IMapper mapper,BoatBusinessRules boatBusinessRules)
            {
                _boatRepository = boatRepository;
                _mapper = mapper;
                _boatBusinessRules = boatBusinessRules;
                
            }

            public async Task<CreateBoatDto> Handle(CreateBoatCommand request, CancellationToken cancellationToken)
            {

                   await   _boatBusinessRules.BoatNameCanNotBeDuplicatedWhenInserted(request.Name);
                Boat mappedBoat = _mapper.Map<Boat>(request);
                Boat createdBoat = await _boatRepository.AddAsync(mappedBoat);
                CreateBoatDto createdBoatDto = _mapper.Map<CreateBoatDto>(createdBoat);

                return createdBoatDto;

            }
        }

    }
}
