using Application.Features.Cars.Constants;
using Application.Services;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules : BaseBusinessRules
{
    private readonly ICarRepository _carRepository;

    public CarBusinessRules(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task CarIdShouldExistWhenSelected(int id)
    {
        Car? result = await _carRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(CarMessages.CarNotExists);
    }

    public async Task CarNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Car> result = await _carRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(CarMessages.CarNameExists);
    }
}