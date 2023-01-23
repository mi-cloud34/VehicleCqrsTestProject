


using Application.Services;
using Core.Persistance.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories;

public class BoatRepository : EfRepositoryBase<Boat, BaseDbContext>, IBoatRepository
{
    public BoatRepository(BaseDbContext context) : base(context)
    {
    }
}