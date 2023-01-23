
using Application.Features.Boats.Commands.CreateBoat;
using Application.Features.Boats.Commands.DeleteBoat;
using Application.Features.Boats.Commands.UpdateBoat;
using Application.Features.Boats.Dtos;
using Application.Features.Boats.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Boats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Boat, CreateBoatCommand>().ReverseMap();
        CreateMap<Boat, CreateBoatDto>().ReverseMap();
        CreateMap<Boat, UpdateBoatCommand>().ReverseMap();
        CreateMap<Boat, UpdateBoatDto>().ReverseMap();
        CreateMap<Boat, DeleteBoatCommand>().ReverseMap();
        CreateMap<Boat, DeleteBoatDto>().ReverseMap();
        CreateMap<Boat, BoatDto>().ReverseMap();
        CreateMap<Boat, BoatListDto>().ReverseMap();
        CreateMap<IPaginate<Boat>, BoatListModel>().ReverseMap();
    }
}