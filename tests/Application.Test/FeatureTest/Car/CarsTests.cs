using System.Threading;
using System.Threading.Tasks;
using Application.Features.Cars.Profiles;
using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Queries.GetByIdCar;
using Application.Features.Cars.Queries.GetListCar;
using Application.Features.Cars.Rules;

using Application.Tests.Mocks.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using Moq;
using Xunit;
using static Application.Features.Cars.Commands.CreateCar.CreateCarCommand;
using static Application.Features.Cars.Commands.DeleteCar.DeleteCarCommand;
using static Application.Features.Cars.Commands.UpdateCar.UpdateCarCommand;
using static Application.Features.Cars.Queries.GetByIdCar.GetByIdCarQuery;
using static Application.Features.Cars.Queries.GetListCar.GetListCarQuery;
using Application.Services;

namespace Application.Tests.FeaturesTests.Cars
{
    public class CarsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICarRepository> _mockCarRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public CarsTests()
        {
            _mockCarRepository = new CarMockRepository().GetRepository();

            _carBusinessRules = new CarBusinessRules(_mockCarRepository.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task AddCarWhenDuplicated()
        {
            CreateCarCommandHandler handler = new(_mockCarRepository.Object, _mapper, _carBusinessRules);
            CreateCarCommand command = new();
            command.Name = "Bmw";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task AddCarWhenNotDuplicated()
        {
            CreateCarCommandHandler handler = new(_mockCarRepository.Object, _mapper, _carBusinessRules);
            CreateCarCommand command = new();
            command.Name = "Ferrari";

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal("Ferrari", result.Name);

        }


       

       

        public Mock<ICarRepository> Get_mockCarRepository()
        {
            return _mockCarRepository;
        }

      

        [Fact]
        public async Task GetAllCars()
        {
            GetListCarQueryHandler handler = new(_mockCarRepository.Object, _mapper);
            GetListCarQuery query = new();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 3
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdCarWhenExistsCar()
        {
            GetByIdCarQueryHandler handler = new(_mockCarRepository.Object, _mapper);
            GetByIdCarQuery query = new();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Equal("Bmw", result.Name);
        }

        [Fact]
        public async Task GetByIdCarWhenNotExistsCar()
        {
            GetByIdCarQueryHandler handler = new(_mockCarRepository.Object, _mapper);
            GetByIdCarQuery query = new();
            query.Id =2;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}