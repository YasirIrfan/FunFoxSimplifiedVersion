using System.Dynamic;
using FunFox.PortalSystem.Application.Services.PlantServices;
using FunFox.PortalSystem.Domain.ViewModels.Plant;
//using FunFox.PortalSystem.ViewModels;

namespace FunFox.PortalSystem.Controllers;

public class PlantController : Controller
{
    private readonly IPlantService _plantService;

    public PlantController(IPlantService plantService)
    {
        _plantService = plantService;
    }

    // GET: PlanetController
    public async Task<ActionResult> Index()
    {
        ViewBag.plantList = await _plantService.GetAllPlant(null!, null!);
        ViewBag.planetCategories = await _plantService.GetAllPlantCategory();
        return View();
    }

    public async Task<IActionResult> PlantsSearch(PlantSearchViewModel plantSearch)
    {
        var plantList = await _plantService.GetAllPlant(plantSearch.PlantName, plantSearch.PlantCategory);
        return PartialView("_PlantList", plantList);
    }

}
