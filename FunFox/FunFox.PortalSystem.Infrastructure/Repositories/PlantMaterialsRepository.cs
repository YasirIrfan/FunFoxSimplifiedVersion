using FunFox.PortalSystem.Application.Repositories;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Infrastructure.DbContexts;

namespace FunFox.PortalSystem.Infrastructure.Repositories;

public class PlantMaterialsRepository: GenericRepository<PlantMaterial>, IPlantMaterialsRepository
{
    public PlantMaterialsRepository(ApplicationDbContext context) : base(context)
    {
    }
}