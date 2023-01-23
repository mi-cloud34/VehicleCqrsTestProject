using Application.Features.Buses.Commands.CreateBus;
using Application.Features.Buses.Commands.DeleteBus;
using Application.Features.Buses.Commands.UpdateBus;
using Application.Features.Buses.Dtos;
using Application.Features.Buses.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Buses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bus, CreateBusCommand>().ReverseMap();
        CreateMap<Bus, CreateBusDto>().ReverseMap();
        CreateMap<Bus, UpdateBusCommand>().ReverseMap();
        CreateMap<Bus, UpdateBusDto>().ReverseMap();
        CreateMap<Bus, DeleteBusCommand>().ReverseMap();
        CreateMap<Bus, DeleteBusDto>().ReverseMap();
        CreateMap<Bus, BusDto>().ReverseMap();
        CreateMap<Bus, BusListDto>().ReverseMap();
        CreateMap<IPaginate<Bus>, BusListModel>().ReverseMap();
    }
}