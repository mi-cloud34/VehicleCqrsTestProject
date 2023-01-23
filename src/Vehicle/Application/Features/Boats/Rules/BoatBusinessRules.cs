
using Application.Features.Boats.Constants;
using Application.Services;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Boats.Rules;

public class BoatBusinessRules : BaseBusinessRules
{
    private readonly IBoatRepository _boatRepository;

    public BoatBusinessRules(IBoatRepository boatRepository)
    {
        _boatRepository = boatRepository;
    }

    public async Task BoatIdShouldExistWhenSelected(int id)
    {
        Boat? result = await _boatRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(BoatMessages.BoatNotExists);
    }

    public async Task BoatNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Boat> result = await _boatRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(BoatMessages.BoatNameExists);
    }
}