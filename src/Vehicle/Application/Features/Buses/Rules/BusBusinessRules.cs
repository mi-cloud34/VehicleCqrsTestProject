using Application.Features.Buses.Constants;
using Application.Services;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Buses.Rules;

public class BusBusinessRules : BaseBusinessRules
{
    private readonly IBusRepository _busRepository;

    public BusBusinessRules(IBusRepository busRepository)
    {
        _busRepository = busRepository;
    }

    public async Task BusIdShouldExistWhenSelected(int id)
    {
        Bus? result = await _busRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(BusMessages.BusNotExists);
    }

    public async Task BusNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Bus> result = await _busRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(BusMessages.BusNameExists);
    }
}