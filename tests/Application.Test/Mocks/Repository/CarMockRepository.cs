

using Application.Services;
using Core.Test.Helpers;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

namespace Application.Tests.Mocks.Repositories
{
    public class CarMockRepository
    {
        public Mock<ICarRepository> GetRepository()
        {
            var Beverages = new List<Car>
            {
                new Car
                {

            Id = 1,
            Wheel = 4,
            HeadLight = false,
            Name = "Ferrari",
            Color = "white",
            Model = 2022,
        },
                new Car
                {
                  
            Id = 2,
            Wheel = 4,
            HeadLight = true,
            Name = "Bmw",
            Color = "Black",
            Model = 2019
                },
            };

            return MockRepositoryHelper.GetRepository<ICarRepository, Car>(Beverages);
        }
    }
}