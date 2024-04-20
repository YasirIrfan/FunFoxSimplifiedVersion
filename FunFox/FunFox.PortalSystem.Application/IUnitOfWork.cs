using FunFox.PortalSystem.Application.Repositories;

namespace FunFox.PortalSystem.Application;

public interface IUnitOfWork
{
    IAllPlantsRepository AllPlantsRepository { get; }

    IPlantMaterialsRepository PlantMaterialsRepository { get; }
    IClassRepository ClassRepository { get; }

    Task<int> CompleteAsync();
}