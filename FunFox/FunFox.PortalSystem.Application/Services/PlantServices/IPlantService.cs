using FunFox.PortalSystem.Domain.ViewModels.Plant;

namespace FunFox.PortalSystem.Application.Services.PlantServices;

public interface IPlantService
{
    Task<IEnumerable<PlantViewModel>> GetAllPlant(string planetName, string category);

    Task<IEnumerable<PlantCategoryViewModel>> GetAllPlantCategory();
}