using FunFox.PortalSystem.Application;
using FunFox.PortalSystem.Application.Repositories;
using FunFox.PortalSystem.Infrastructure.DbContexts;
using FunFox.PortalSystem.Infrastructure.Repositories;

namespace FunFox.PortalSystem.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AllPlantsRepository = new Lazy<IAllPlantsRepository>(() => new AllPlantsRepository(context)).Value;
        PlantMaterialsRepository = new Lazy<IPlantMaterialsRepository>(() => new PlantMaterialsRepository(context)).Value;
        ClassRepository = new Lazy<IClassRepository>(() => new ClassRepository(context)).Value;
    }

    public IAllPlantsRepository AllPlantsRepository { get; }
    public IPlantMaterialsRepository PlantMaterialsRepository { get; }
    public IClassRepository ClassRepository { get; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}