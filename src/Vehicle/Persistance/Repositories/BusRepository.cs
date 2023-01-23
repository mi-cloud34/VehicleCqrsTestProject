


using Application.Services;
using Core.Persistance.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories;

public class BusRepository : EfRepositoryBase<Bus, BaseDbContext>, IBusRepository
{
    public BusRepository(BaseDbContext context) : base(context)
    {
    }
}