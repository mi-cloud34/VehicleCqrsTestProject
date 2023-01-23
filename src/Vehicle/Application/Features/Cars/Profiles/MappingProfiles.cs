


using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreateCarDto>().ReverseMap();
        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, UpdateCarDto>().ReverseMap();
        CreateMap<Car, DeleteCarCommand>().ReverseMap();
        CreateMap<Car, DeleteCarDto>().ReverseMap();
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Car, CarListDto>().ReverseMap();
        CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();
    }
}