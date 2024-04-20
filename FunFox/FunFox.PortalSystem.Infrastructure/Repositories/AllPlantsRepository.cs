using FunFox.PortalSystem.Application.Repositories;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Domain.ViewModels;
using FunFox.PortalSystem.Domain.ViewModels.Plant;
using FunFox.PortalSystem.Infrastructure.DbContexts;

namespace FunFox.PortalSystem.Infrastructure.Repositories;

public class AllPlantsRepository : GenericRepository<AllPlant>, IAllPlantsRepository
{
    public AllPlantsRepository(ApplicationDbContext context) : base(context)
    {
    }
}